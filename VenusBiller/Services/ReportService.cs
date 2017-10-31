using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using VenusBiller.Reports;
using VenusBiller.Reports.Entities;
using VenusBiller.Services.Dao;

namespace VenusBiller.Services
{
    public class ReportService
    {
        public void GenerateReportBillWise(BillWiseReportCriteria billWiseReportCriteria)
        {
            List<BillWiseRecord> bills = ReportDao.GetBillsMatchingCriteria(billWiseReportCriteria);
            var textToWrite = new StringBuilder();
            textToWrite.Append("           VENUS DISTRIBUTORS");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("Bill-wise Sales Report");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("(" + billWiseReportCriteria.StartDate.ToString("dd/MMM/yyyy") + " - " +
                               billWiseReportCriteria.EndDate.ToString("dd/MMM/yyyy") + ")");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("-------------------------------------------------------------------------------");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("Sl       Bill     Bill Date     Bill Amt    CUSTOMER NAME                      ");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("-------------------------------------------------------------------------------");
            textToWrite.Append(Environment.NewLine);
            int i = 1;
            double totalBillAmount = 0.0;
            foreach (BillWiseRecord bill in GetBillsOrderedBySortType(bills, billWiseReportCriteria.SortType))
            {
                textToWrite.Append(i.ToString(CultureInfo.InvariantCulture).PadRight(9));
                textToWrite.Append(bill.BillNumber.ToString(CultureInfo.InvariantCulture).PadRight(9));
                textToWrite.Append(bill.BillDate.ToString("dd-MM-yyyy").PadRight(14));
                textToWrite.Append(Math.Round(bill.BillAmount).ToString("#.00").PadRight(12));
                textToWrite.Append(bill.CustomerName.ToString(CultureInfo.InvariantCulture).PadRight(35));
                totalBillAmount += bill.BillAmount;
                textToWrite.Append(Environment.NewLine);
                i++;
            }
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("-------------------------------------------------------------------------------");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("                      Total :   " + totalBillAmount.ToString("#.00").PadRight(12));
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("-------------------------------------------------------------------------------");
            BillingUtilities.WriteBillToFile(textToWrite, billWiseReportCriteria.PrintAfterGeneration, "BillWise.txt");
        }

        public void GenerateReportItemWise(ItemWiseReportCriteria itemWiseReportCriteria)
        {
            List<ItemWiseRecord> bills = ReportDao.GetBillsMatchingCriteria(itemWiseReportCriteria);
            var textToWrite = new StringBuilder();
            textToWrite.Append("           VENUS DISTRIBUTORS");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("Item-Wise sales ");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("(" + itemWiseReportCriteria.StartDate.ToString("dd/MMM/yyyy") + " - " +
                               itemWiseReportCriteria.EndDate.ToString("dd/MMM/yyyy") + ")");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append(
                "-------------------------------------------------------------------------------------------------");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append(
                "Sl/No    Date          Bill No  Item Description                       Itemcode            Qty   ");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append(
                "-------------------------------------------------------------------------------------------------");
            textToWrite.Append(Environment.NewLine);
            int i = 1;
            foreach (ItemWiseRecord item in GetItemsOrderedBySortType(bills, itemWiseReportCriteria.SortType))
            {
                textToWrite.Append(i.ToString(CultureInfo.InvariantCulture).PadRight(9));
                textToWrite.Append(item.BillDate.ToString("dd-MM-yyyy").PadRight(14));
                textToWrite.Append(item.BillNumber.ToString(CultureInfo.InvariantCulture).PadRight(9));
                textToWrite.Append(item.ItemName.Trim().PadRight(39));
                textToWrite.Append(item.ItemCode.PadRight(19));
                textToWrite.Append(item.Quantity.ToString().PadRight(5));
                textToWrite.Append(Environment.NewLine);
                i++;
            }
            textToWrite.Append(
                "-------------------------------------------------------------------------------------------------");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append(
                "                                                                          Total :         " +
                bills.Sum(b => b.Quantity));
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append(
                "-------------------------------------------------------------------------------------------------");
            BillingUtilities.WriteBillToFile(textToWrite, itemWiseReportCriteria.PrintAfterGeneration, "ItemWise.txt");
        }

        public void GenerateSalesRegisterReport(SalesRegisterReportCriteria criteria)
        {
            List<ItemDetailRecord> bills = ReportDao.GetItemDetailsInDateRange(criteria);
            var itemsGroupedByBillNumberAndTax = bills.
                GroupBy(item => new
                {
                    item.BillNumber,
                    item.BillDate,
                    /*item.TaxPercentage,*/
                    item.GstIn,
                    item.CustomerName
                })
                .Select(x =>
                    new
                    {
                        x.Key.GstIn,
                        x.Key.BillNumber,
                        x.Key.BillDate,
                        //x.Key.TaxPercentage,
                        x.Key.CustomerName,
                        Items = x.ToList(),
                    });

            #region Header

            var textToWrite = new StringBuilder();
            textToWrite.Append("           VENUS DISTRIBUTORS");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("Puthiyavila, Puthiyavila P.O, Kayamkulam");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("Ph: 0 9745741550, 0479 2430221");
            textToWrite.Append(Environment.NewLine);
            var salesType = criteria.SalesType == SalesType.B2B
                ? "B 2 B"
                : criteria.SalesType == SalesType.B2C ? "B 2 C" : "B 2 B & B 2 C";
            textToWrite.Append("GSTR-1 " + salesType);
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("{" + criteria.StartDate.ToString("dd/MMM/yyyy") + " - " +
                               criteria.EndDate.ToString("dd/MMM/yyyy") + "}");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append(
                "------------------------------------------------------------------------------------------------------------------------------------------------");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append(
                "GSTIN              Inv No   Inv Date      Customer Name                           Taxable        CGST        SGST        CESS        State");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append(
                "------------------------------------------------------------------------------------------------------------------------------------------------");
            textToWrite.Append(Environment.NewLine);

            #endregion Header

            double totalTaxable = 0;
            double totalTax = 0;
            double totalCess = 0;
            foreach (var group in itemsGroupedByBillNumberAndTax.OrderBy(g => g.BillDate))
            {
                double itemTotal = 0;
                double cessTotal = 0;
                double gstTotal = 0;
                foreach (ItemDetailRecord item in group.Items)
                {
                    double itemPrice = item.Rate*item.Quantity - item.DiscountAmount - item.SpecialDiscountAmount;
                    double gst = itemPrice*item.TaxPercentage/100;
                    double cess = itemPrice*item.CessPercentage/100;
                    itemTotal = itemTotal + itemPrice + gst + cess;
                    cessTotal += cess;
                    gstTotal += gst;
                }

                totalTaxable += itemTotal;
                totalTax += gstTotal;
                totalCess += cessTotal;
                textToWrite.Append(group.GstIn.PadRight(19)
                                   + group.BillNumber.PadRight(9)
                                   + group.BillDate.ToString("dd-MM-yyyy").PadRight(14)
                                   + group.CustomerName.PadRight(40)
                                   //+ group.TaxPercentage.ToString(CultureInfo.InvariantCulture).PadRight(6)
                                   + Math.Round(itemTotal, 2).ToString(CultureInfo.InvariantCulture).PadRight(15)
                                   + Math.Round(gstTotal/2, 2).ToString(CultureInfo.InvariantCulture).PadRight(12)
                                   + Math.Round(gstTotal/2, 2).ToString(CultureInfo.InvariantCulture).PadRight(12)
                                   + Math.Round(cessTotal, 2).ToString(CultureInfo.InvariantCulture).PadRight(12)
                                   + "32"
                    );
                textToWrite.Append(Environment.NewLine);
            }
            textToWrite.Append(
                "------------------------------------------------------------------------------------------------------------------------------------------------");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("Total:                                                                            "
                               + Math.Round(totalTaxable, 2).ToString(CultureInfo.InvariantCulture).PadRight(15) +
                               Math.Round(totalTax/2, 2).ToString(CultureInfo.InvariantCulture).PadRight(12) +
                               Math.Round(totalTax/2, 2).ToString(CultureInfo.InvariantCulture).PadRight(12) +
                               Math.Round(totalCess, 2).ToString(CultureInfo.InvariantCulture).PadRight(12));

            textToWrite.Append(Environment.NewLine);
            textToWrite.Append(
                "------------------------------------------------------------------------------------------------------------------------------------------------");

            BillingUtilities.WriteBillToFile(textToWrite, criteria.PrintAfterGeneration, "SalesRegister.txt");
        }

        private IEnumerable<BillWiseRecord> GetBillsOrderedBySortType(IEnumerable<BillWiseRecord> bills,
            SortType sortType)
        {
            switch (sortType)
            {
                case SortType.BillDate:
                    return bills.OrderBy(b => b.BillDate);
                case SortType.BillAmount:
                    return bills.OrderBy(b => b.BillAmount);
                case SortType.TaxAmount:
                    return bills.OrderBy(b => b.TaxAmount);
                default:
                    return bills.OrderBy(b => b.BillNumber);
            }
        }

        private IEnumerable<ItemWiseRecord> GetItemsOrderedBySortType(IEnumerable<ItemWiseRecord> bills,
            SortType sortType)
        {
            switch (sortType)
            {
                case SortType.BillDate:
                    return bills.OrderBy(b => b.BillDate);
                case SortType.BillAmount:
                    return bills.OrderBy(b => b.BillAmount);
                case SortType.TaxAmount:
                    return bills.OrderBy(b => b.TaxAmount);
                case SortType.ItemCode:
                    return bills.OrderBy(b => b.ItemCode);

                default:
                    return bills.
                        OrderBy(b => b.BillNumber);
            }
        }

        public void GenerateMonthlySummary(DateTime startDate, DateTime endDate, bool sendToPrinter)
        {
            var itemDetails = ReportDao.GetItemDetailsInDateRange(startDate, endDate);
            var textToWrite = new StringBuilder();
            textToWrite.Append("                                                                             VENUS DISTRIBUTORS");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("                                                                    Puthiyavila, Puthiyavila P.O, Kayamkulam");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("                                                                    MONTHLY SUMMARY");
            textToWrite.Append("(" + startDate.ToString("dd/MMM/yyyy") + " - " +
                               endDate.ToString("dd/MMM/yyyy") + ")");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("Date      |    Bill Amt|");
            var taxCategories = new SortedList<double,double>();
            foreach (var taxGroup in itemDetails.GroupBy(item => item.TaxPercentage).OrderBy(tax => tax.Key))
            {
                var taxRate = (Math.Round(taxGroup.Key, 0) + "%|").PadLeft(12);
                textToWrite.Append(taxRate);
                textToWrite.Append("Tax Amt|".PadLeft(11));
                taxCategories.Add(taxGroup.Key, taxGroup.Key);
            }
            textToWrite.Append("Total Tax|Bill No        |");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            textToWrite.Append(Environment.NewLine);

            foreach (var monthGroup in itemDetails.GroupBy(item => item.BillDate.Month).OrderBy(o => o.Key))
            {
                var totaltax = 0.0;
                var billStart = monthGroup.OrderBy(item => item.BillNumber).First().BillNumber;
                var billEnd = monthGroup.OrderBy(item => item.BillNumber).Last().BillNumber;
                var billMonth = monthGroup.First().BillDate.ToString("yyyyMM");
                textToWrite.Append((billMonth + "    |").PadRight(10));
                var totalBillAmountForMonth = monthGroup.Sum(
                    item =>
                        CalculateItemPrice(item.Rate, item.Quantity, item.TaxPercentage, item.CessPercentage,
                            item.DiscountAmount, item.SpecialDiscountAmount));
                textToWrite.Append((Math.Round(totalBillAmountForMonth, 2) + "|").PadLeft(13));
                foreach (var taxCategory in taxCategories)
                {
                    var billAmountInTaxBracket = monthGroup.Where(m => m.TaxPercentage == taxCategory.Key)
                        .Sum(
                            item =>
                                CalculateItemPrice(item.Rate, item.Quantity, item.TaxPercentage, item.CessPercentage,
                                    item.DiscountAmount, item.SpecialDiscountAmount));
                    var taxAmountInTaxBracket = monthGroup.Where(m => m.TaxPercentage == taxCategory.Key).
                        Sum(
                            item =>
                                CalculateItemTax(item.Rate, item.Quantity, item.TaxPercentage, item.CessPercentage,
                                    item.DiscountAmount, item.SpecialDiscountAmount));
                    totaltax += taxAmountInTaxBracket;
                    textToWrite.Append((Math.Round(billAmountInTaxBracket, 2) + "|").PadLeft(12));
                    textToWrite.Append((Math.Round(taxAmountInTaxBracket, 2) + "|").PadLeft(11));
                }
                textToWrite.Append((Math.Round(totaltax, 2) + "|").PadLeft(10));
                textToWrite.Append((billStart + "-" + billEnd).PadRight(15));
                textToWrite.Append(Environment.NewLine);
            }
            textToWrite.Append("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("Total     |".PadRight(10));
            var sumOfTotalAmounts = itemDetails
                .Sum(
                    item =>
                        CalculateItemPrice(item.Rate, item.Quantity, item.TaxPercentage, item.CessPercentage,
                            item.DiscountAmount, item.SpecialDiscountAmount));
            textToWrite.Append((Math.Round(sumOfTotalAmounts, 2) + "|").PadLeft(13));
            var sumOfTaxes = 0.0;
            foreach (var taxCategory in taxCategories)
            {
                var billAmount = itemDetails.Where(m => m.TaxPercentage == taxCategory.Key)
                    .Sum(
                        item =>
                            CalculateItemPrice(item.Rate, item.Quantity, item.TaxPercentage, item.CessPercentage,
                                item.DiscountAmount, item.SpecialDiscountAmount));
                var taxAmountInTaxBracket = itemDetails.Where(m => m.TaxPercentage == taxCategory.Key).
                    Sum(
                        item =>
                            CalculateItemTax(item.Rate, item.Quantity, item.TaxPercentage, item.CessPercentage,
                                item.DiscountAmount, item.SpecialDiscountAmount));
                sumOfTaxes += taxAmountInTaxBracket;
                textToWrite.Append((Math.Round(billAmount, 2) + "|").PadLeft(12));
                textToWrite.Append((Math.Round(taxAmountInTaxBracket, 2) + "|").PadLeft(11));

            }
            textToWrite.Append((Math.Round(sumOfTaxes, 2) + "|").PadLeft(10));
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            BillingUtilities.WriteBillToFile(textToWrite, sendToPrinter, "MonthSum.txt");
        }

        private double CalculateItemPrice(double rate, int quantity, double gstPercent, double cessPercent,
            double discount, double specialDiscount)
        {
            var totalDiscount = discount + specialDiscount;
            var rateAfterDiscount = rate*quantity - totalDiscount;
            var gst = rateAfterDiscount*gstPercent/100;
            var cess = rate*cessPercent/100;
            var itemPrice = rateAfterDiscount + gst + cess;
            return itemPrice;
        }

        private double CalculateItemTax(double rate, int quantity, double gstPercent, double cessPercent,
            double discount, double specialDiscount)
        {
            var totalDiscount = discount + specialDiscount;
            var rateAfterDiscount = rate * quantity - totalDiscount;
            var gst = rateAfterDiscount * gstPercent / 100;
            return gst;
        }
    }
}