using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace converterCSVtoJson
{
    class Program
    {
        static void Main()
        {
            string[] CSVPath = Directory.GetFiles(@Environment.CurrentDirectory, "*.csv");
            string jsonPath = Environment.CurrentDirectory +"\\Output.json";
            Addresses a = new Addresses();
            a.CSVtoJson(CSVPath[0], jsonPath); 
        }
    }
}
