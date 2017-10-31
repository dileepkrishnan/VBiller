#region

using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace VenusBiller
{
    internal static class Program
    {
        private const string LogFileNamePrefix = "ErrorLog";

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException;
            Application.Run(new MainForm());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var fileName = LogFileNamePrefix + "_" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
            using (FileStream logger = File.Open(fileName, FileMode.Append))
            {
                using (var writer = new StreamWriter(logger))
                {
                    string log = DateTime.Now.ToShortDateString() + "[" + DateTime.Now.ToString("h:mm:ss tt zz") + "]" +
                                 Environment.NewLine;
                    log += e.Exception.Message;
                    log += Environment.NewLine;
                    log += e.Exception.StackTrace;
                    writer.WriteLine(Environment.NewLine);
                    writer.WriteLine(log);
                }
            }
            MessageBox.Show(@"We are sorry but a critical error has occured and the applicaion will close now.",
                @"Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }
}