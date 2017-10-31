#region

using System;
using System.Linq;
using System.Text;
using Humanizer;
using VenusBiller.Entities;
using VenusBiller.Services.Dao;

#endregion

namespace VenusBiller.Services
{
    public class BillService
    {
        public void SaveBill(Bill bill)
        {
            BillDao.Save(bill);
        }

        public int GetNextBillNumber()
        {
            int lastBillNumber = BillDao.GetLastBillNumber();
            if (lastBillNumber != -1)
            {
                return lastBillNumber + 1;
            }
            throw new InvalidOperationException("Unable to find next bill number !");
        }

        public void SaveAndPrintBill(Bill bill)
        {
            SaveBill(bill);
            PrintBill(bill);
        }

        private void PrintBill(Bill bill)
        {
            var textToWrite = GetTextToWrite(bill);
            BillingUtilities.WriteBillToFile(textToWrite, true, "Bill.txt");
        }

        private StringBuilder GetTextToWrite(Bill bill)
        {
            var textToWrite = new StringBuilder();
            textToWrite.Append("                                            VENUS DISTRIBUTORS");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("                                  Puthiyavila, Puthiyavila P.O, Kayamkulam");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("                                        Ph: 0 9745741550, 0479 2430221");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("                                             GSTIN: 32BOMPR3730R1ZB");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("                                               TAX INVOICE[CASH]");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("Invoice No :" + bill.BillNumnber.PadRight(5));
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("Date       :" + bill.BillDate.ToString("dd-MM-yyyy"));
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("--------------------------------------------------------------------------------------------------------------------------------------");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("Sl | Item Description        |HSN/     | Qty |  Rate   |    Amount|Discount|TaxableAmt|    GST      |   CESS      |  Total    ");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("No |                         |SAC      |     |         |          |        |          | Rate| Amount| Rate| Amount|  Amount   ");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("---|-------------------------|---------|------------|---------|----------|--------|----------|-----|-------|------|-------------------");
            textToWrite.Append(Environment.NewLine);
            var totalTaxableAmount = 0.0;
            var totalDiscountAmount = 0.0;
            var totalGstAmount = 0.0;
            var totalCessAmount = 0.0;
            var totalAmount = 0.0;
            foreach (var item in bill.Items.OrderBy(i => i.ItemNumber))
            {
                textToWrite.Append(item.ItemNumber.ToString().PadRight(3));
                var itemName = item.Name.Length > 25 ? item.Name.Substring(0, 24) : item.Name;
                textToWrite.Append("|"+itemName.PadRight(25));
                textToWrite.Append("|" + item.HsnOrSac.PadRight(9));
                textToWrite.Append("| " + item.Quantity.ToString("0.00").PadLeft(7) + " NOS");
                textToWrite.Append("| " + item.Rate.ToString("0.00").PadRight(8));
                textToWrite.Append("| " + (item.Rate*item.Quantity).ToString("0.00").PadRight(9));
                var itemAmount = item.Rate*item.Quantity;
                totalAmount += itemAmount;
                var itemDiscountAmount = item.Rate * item.Quantity * item.DiscountPercent / 100 + item.SpecialDiscountAmount;
                totalDiscountAmount += itemDiscountAmount;
                var taxableAmount = item.Rate*item.Quantity - itemDiscountAmount;
                totalTaxableAmount += taxableAmount;
                var itemGst = taxableAmount*item.GstPercent/100;
                totalGstAmount += itemGst;
                totalCessAmount += item.CessAmount;
                textToWrite.Append("| " + itemDiscountAmount.ToString("0.00").PadRight(7));
                textToWrite.Append("| " + (taxableAmount).ToString("0.00").PadRight(9));
                textToWrite.Append("|" + (item.GstPercent/2).ToString("0.00").PadLeft(5));
                textToWrite.Append("|" + (itemGst/2).ToString("0.00").PadLeft(8));
                textToWrite.Append("|" + (item.GstPercent / 2).ToString("0.00").PadLeft(5));
                textToWrite.Append("|" + (itemGst / 2).ToString("0.00").PadLeft(8));
                textToWrite.Append("|" + item.CessPercent.ToString("0.00").PadLeft(5));
                textToWrite.Append("|" + item.CessAmount.ToString("0.00").PadLeft(8));
                textToWrite.Append("|" + (itemGst + taxableAmount + item.CessAmount).ToString("0.00").PadLeft(10));
                textToWrite.Append(Environment.NewLine);
                textToWrite.Append("   |" + "MRP : " + Math.Round(item.MaximumRetailPrice, 2).ToString("0.00").PadRight(8) + "|".PadLeft(12));
                textToWrite.Append("         |            |         |          |        |          |     |        |     |        |     |        |");
                textToWrite.Append(Environment.NewLine);
            }
            textToWrite.Append("   |                         |         |            |         |          |        |          |     |        |     |        |     |        |");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("---|-------------------------|---------|------------|---------|----------|--------|----------|-----|--------|-----|--------|-----|--------|----------");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("   |Total                    |         |            |         |"
                               + Math.Round(totalAmount, 2).ToString("0.00").PadLeft(10)
                               + "|"
                               + Math.Round(totalDiscountAmount, 2).ToString("0.00").PadLeft(8)
                               + "|"
                               + Math.Round(totalTaxableAmount, 2).ToString("0.00").PadLeft(10)
                               + "|     |"
                               + Math.Round(totalGstAmount/2, 2).ToString("0.00").PadLeft(8)
                               + "|     |"
                               + Math.Round(totalGstAmount/2, 2).ToString("0.00").PadLeft(8)
                               + "|     |"
                               + Math.Round(totalCessAmount, 2).ToString("0.00").PadLeft(8)
                               + "|"
                               +
                               Math.Round(totalTaxableAmount + totalGstAmount + totalCessAmount, 2)
                                   .ToString("0.00")
                                   .PadLeft(10));
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("                                                              ---------------------------------------------------------------------------------------");
            textToWrite.Append(Environment.NewLine);
            var finalRoundedBillAmount = bill.NetAmount + bill.RoundOffAmount;
            var amountInWords = ConvertAmountToString(finalRoundedBillAmount);
            textToWrite.Append(amountInWords.PadRight(129));
            textToWrite.Append("Round off : ");
            textToWrite.Append(bill.RoundOffAmount.ToString("0.00"));
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("Grand Total : ".PadLeft(141));
            textToWrite.Append(finalRoundedBillAmount.ToString("0.00"));
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("-----------------------------------------------------------------------------------------------------------------------------------------------------");
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("Gst%    Cess%   Sale Amt  Gst Amt  Cess Amt ");
            textToWrite.Append(Environment.NewLine);
            foreach (var taxGroup in bill.Items.GroupBy( p => new {p.GstPercent, p.CessPercent}))
            {
                textToWrite.Append(taxGroup.Key.GstPercent.ToString("0.00").PadRight(8));
                textToWrite.Append(taxGroup.Key.CessPercent.ToString("0.00").PadRight(8));
                var saleAmount =
                    taxGroup.Sum(item => (item.Rate*item.Quantity )-(item.Rate * item.Quantity * item.DiscountPercent / 100 + item.SpecialDiscountAmount));
                var gstAmount = saleAmount*taxGroup.Key.GstPercent/100;
                var cessAmount = taxGroup.Sum(item => item.CessAmount);
                textToWrite.Append(saleAmount.ToString("0.00").PadRight(10));
                textToWrite.Append(gstAmount.ToString("0.00").PadRight(9));
                textToWrite.Append(cessAmount.ToString("0.00").PadRight(9));
                textToWrite.Append(Environment.NewLine);
            }
            textToWrite.Append(Environment.NewLine);
            textToWrite.Append("                                                                                                                               For VENUS DISTRIBUTORS");
            return textToWrite;
        }

        private string ConvertAmountToString(double finalRoundedBillAmount)
        {
            var amountInWords = string.Empty;
            try
            {
                var inWords = ((int) finalRoundedBillAmount).ToWords();
                amountInWords = "( Rupees " + inWords + " only. )";
            }
            catch
            {
            }
            return amountInWords;
        }
    }
}
