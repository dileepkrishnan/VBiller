using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\Dileep\Desktop\DP";

            foreach (var file in Directory.GetFiles(path))
            {
                using (var reader = new StreamReader(File.OpenRead(file)))
                {
                    var text = reader.ReadToEnd();
                    if (text.Contains("Sale Bill"))
                    {
                        Console.WriteLine("Search text found in file : " + file);
                    }
                }
            }
        }
    }
}
