#region

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Humanizer;
using Microsoft.Reporting.WinForms;
using VenusBiller.Entities;
using VenusBiller.Reports.Entities;
using VenusBiller.Services.Dao;

#endregion

namespace VenusBiller.Services
{
    public class BillService
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

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
            try
            {
                SaveBill(bill);
                PrintBill(bill);
            }
            catch (Exception e)
            {
                var error = "Error while saving/printing !" + Environment.NewLine;
                error += e.Message;
                error += Environment.NewLine;
                error += e.StackTrace;
                throw new Exception(error);
            }
        }

        public void SaveModifiedBill(Bill bill)
        {
            try
            {
                DeleteOldBill(bill);

            }
            catch (Exception e)
            {
                var error = "Error while saving/printing !" + Environment.NewLine;
                error += e.Message;
                error += Environment.NewLine;
                error += e.StackTrace;
                throw new Exception(error);
            }
            SaveBill(bill);
        }

        public void SaveAndPrintModifiedBill(Bill bill)
        {
            SaveModifiedBill(bill);
            PrintBill(bill);
        }

        private void DeleteOldBill(Bill bill)
        {
            BillDao.DeleteBill(bill.BillNumnber);
        }

        private string ConvertAmountToString(double finalRoundedBillAmount)
        {
            string amountInWords = string.Empty;
            try
            {
                string inWords = ((int) finalRoundedBillAmount).ToWords();
                amountInWords = "( Rupees " + inWords + " only. )";
            }
            catch
            {
            }
            return amountInWords;
        }

        private Stream CreateStream(string name,
            string fileNameExtension, Encoding encoding,
            string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        private void Export(LocalReport report)
        {
            string deviceInfo =
                @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>11.7in</PageWidth>
                <PageHeight>8.3in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
                out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            var pageImage = new
                Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            var adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int) ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int) ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            var printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            printDoc.PrintPage += PrintPage;
            m_currentPageIndex = 0;
            printDoc.Print();
        }

        private void PrintBill(Bill bill)
        {
            var printableBillItemBindingSource = new BindingSource();
            var printableBillBindingSource = new BindingSource();
            var printableBillBindingSource2 = new BindingSource();
            PrintableBill data = CreatePrintableBillFromBill(bill);
            printableBillBindingSource.DataSource = data;
            printableBillItemBindingSource.DataSource = data.Items;
            printableBillBindingSource2.DataSource = data.TaxCatogories;
            var report = new LocalReport { ReportPath = @"Report1.rdlc" };
            report.DataSources.Add(
                new ReportDataSource("DataSet1", printableBillItemBindingSource));
            report.DataSources.Add(
                new ReportDataSource("DataSet2", printableBillBindingSource));
            report.DataSources.Add(
                new ReportDataSource("DataSet3", printableBillBindingSource2));

            Export(report);
            Print();
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }

        private PrintableBill CreatePrintableBillFromBill(Bill bill)
        {
            var pb = new PrintableBill
            {
                BillNumber = bill.BillNumnber,
                CustomerName =
                    bill.PartyName + Environment.NewLine + bill.PartyAddress + Environment.NewLine + "GSTN : " +
                    bill.PartyGstIn,
                //CustomerAddress = bill.PartyAddress,
                Date = bill.BillDate.ToString("dd-MM-yyyy"),
                Items = new List<PrintableBillItem>(),
                //CustomerGstn = "GSTN : " + bill.PartyGstIn
            };
            foreach (BillItem item in bill.Items)
            {
                var printableItem = new PrintableBillItem
                {
                    ItemNumber = item.ItemNumber,
                    ItemName = item.Name,
                    HsnOrSac = item.HsnOrSac,
                    Quantity = item.Quantity,
                    Rate = FixDecimaPoints(item.Rate),
                    Amount = FixDecimaPoints(item.Rate*item.Quantity)
                };
                pb.SumOfAmounts += printableItem.Rate*item.Quantity; // Amount
                double itemDiscountAmount = item.Rate*item.Quantity*item.DiscountPercent/100 +
                                            item.SpecialDiscountAmount;
                printableItem.Discount = FixDecimaPoints(itemDiscountAmount);
                pb.SumOfDiscounts += itemDiscountAmount; // Discount
                double taxableAmount = item.Rate*item.Quantity - itemDiscountAmount;
                printableItem.TaxableAmount = FixDecimaPoints(taxableAmount);
                pb.SumOfTaxableAmounts += taxableAmount; // Taxable Amt
                double itemGst = taxableAmount*item.GstPercent/100;
                printableItem.CgstRate = item.GstPercent/2;
                printableItem.CgstAmount = FixDecimaPoints(itemGst/2);
                pb.SumOfCgstAmounts += itemGst/2; //Cgst Amt
                printableItem.SgstRate = item.GstPercent/2;
                printableItem.SgstAmount = FixDecimaPoints(itemGst/2);
                pb.SumOfSgstAmounts += itemGst/2; //Sgst Amt
                printableItem.CessRate = item.CessPercent;
                printableItem.CessAmount = FixDecimaPoints(item.CessAmount);
                pb.SumOfCessAmounts += item.CessAmount; //Cess Amt
                printableItem.TotalAmount = FixDecimaPoints(taxableAmount + itemGst + item.CessAmount);
                pb.SumOfTotalAmounts += taxableAmount + itemGst + item.CessAmount; // Total Amt
                pb.Items.Add(printableItem);
            }
            pb.GrandTotal = pb.SumOfTotalAmounts + bill.RoundOffAmount;
            pb.Roundoff = bill.RoundOffAmount;
            pb.TaxCatogories = new List<TaxCategory>();
            foreach (var group in pb.Items.GroupBy(item => new {item.CgstRate, item.CessRate}))
            {
                var tc = new TaxCategory
                {
                    GstRate = FixDecimaPoints(group.Key.CgstRate*2),
                    CessRate = FixDecimaPoints(group.Key.CessRate),
                    TaxAmount = FixDecimaPoints(@group.Sum(item => item.CgstAmount + item.SgstAmount + item.CessAmount)),
                    SaleAmount = FixDecimaPoints(@group.Sum(item => item.TaxableAmount))
                };
                pb.TaxCatogories.Add(tc);
            }
            pb.SumOfAmounts = FixDecimaPoints(pb.SumOfAmounts);
            pb.SumOfDiscounts = FixDecimaPoints(pb.SumOfDiscounts);
            pb.SumOfTaxableAmounts = FixDecimaPoints(pb.SumOfTaxableAmounts);
            pb.SumOfCgstAmounts = FixDecimaPoints(pb.SumOfCgstAmounts);
            pb.SumOfSgstAmounts = FixDecimaPoints(pb.SumOfSgstAmounts);
            pb.SumOfTotalAmounts = FixDecimaPoints(pb.SumOfTotalAmounts);
            pb.SumOfCessAmounts = FixDecimaPoints(pb.SumOfCessAmounts);
            pb.GrandTotal = FixDecimaPoints(pb.GrandTotal);
            pb.Roundoff = FixDecimaPoints(pb.Roundoff);
            pb.GrandTotalAmountInWords = ConvertAmountToString(pb.GrandTotal);
            return pb;
        }

        private double FixDecimaPoints(double value, int decimalPoints = 2)
        {
            return Math.Round(value, decimalPoints);
        }

        public Bill LoadBill(int billNumber)
        {
            return BillDao.Load(billNumber);
        }
    }
}