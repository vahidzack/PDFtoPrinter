using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PDFtoPrinter.NetCoreSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var wrapper = new PDFtoPrinterPrinter();
            //Print from file
            wrapper
                .Print(new PrintingOptions("Microsoft Print to PDF", "somefile.pdf"))
                .Wait();

           // Print from stream(this code simulates that you want (parallel) )
          List<Task> tasks = new List<Task>();
            tasks.Add(
                wrapper
                    .Print(File.OpenRead("somefile.pdf"), new StreamPrintingOptions("Microsoft Print to PDF")));
            tasks.Add(
                wrapper
                    .Print(File.OpenRead("somefile.pdf"), new StreamPrintingOptions("Microsoft Print to PDF")));
            tasks.Add(
                wrapper
                    .Print(File.OpenRead("somefile.pdf"), new StreamPrintingOptions("Microsoft Print to PDF")));
            Task.WhenAll(tasks);
        }
    }
}
