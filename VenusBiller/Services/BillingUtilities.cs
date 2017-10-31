using System.Diagnostics;
using System.IO;
using System.Text;

namespace VenusBiller.Services
{
    public static class BillingUtilities
    {
        public static void WriteBillToFile(StringBuilder textToWrite, bool printAfterGeneration, string fileName)
        {
            FileStream file = File.Open(fileName, FileMode.Create);
            using (var sw = new StreamWriter(file))
            {
                sw.WriteLine(textToWrite.ToString());
            }
            if (printAfterGeneration)
                SendToPrinter(fileName);
            else
            {
                Process.Start(fileName);
            }
        }

        private static void SendToPrinter(string fileName)
        {
            var info = new ProcessStartInfo
            {
                FileName = fileName,
                Verb = "print",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
            };
            Process.Start(info);
            //var printDocument1 = new PrintDocument();

            //printDocument1.DocumentName = fileName;
            //using (var stream = new FileStream(fileName, FileMode.Open))
            //using (var reader = new StreamReader(stream))
            //{
            //    stringToPrint = reader.ReadToEnd();
            //}
            ////printDocument1.DefaultPageSettings.Landscape = true;
            //printDocument1.PrintPage += printDocument1_PrintPage;
            //printDocument1.Print();
        }

        //static string stringToPrint = string.Empty;
        //private static void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        //{
        //    FontFamily fontFamily = new FontFamily("Arial");
        //    Font font = new Font(
        //       fontFamily,
        //       12,
        //       FontStyle.Regular,
        //       GraphicsUnit.Pixel);
        //    int charactersOnPage = 0;
        //    int linesPerPage = 0;

        //    // Sets the value of charactersOnPage to the number of characters 
        //    // of stringToPrint that will fit within the bounds of the page.
        //    e.Graphics.MeasureString(stringToPrint, font,
        //        e.MarginBounds.Size, StringFormat.GenericTypographic,
        //        out charactersOnPage, out linesPerPage);

        //    // Draws the string within the bounds of the page
        //    e.Graphics.DrawString(stringToPrint, font, Brushes.Black,
        //        e.MarginBounds, StringFormat.GenericTypographic);

        //    // Remove the portion of the string that has been printed.
        //    stringToPrint = stringToPrint.Substring(charactersOnPage);

        //    // Check to see if more pages are to be printed.
        //    e.HasMorePages = (stringToPrint.Length > 0);
        //}
    }
}