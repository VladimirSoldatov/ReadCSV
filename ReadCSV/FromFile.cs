using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCSV
{
    internal class FromFile
    {
        public string Filename { get; set; }
        public FromFile()
        {


            string fileName = "Вылеты.csv";
            List<OneFly> flyList = new List<OneFly>();
            if (File.Exists(fileName))
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = String.Empty;
                        line = sr.ReadLine();
                        line = line.Trim().Replace("\"", "");
                        //Console.WriteLine(line);
                        OneFly oneFly = new OneFly(line.Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries));
                        flyList.Add(oneFly);
                    }
                }
            else
            {
                Console.WriteLine("Файл не существует!");
            }
            GetData getData = new GetData(flyList);
            getData.getfliesByDate("2005-01-01");
            // getData.getfliesNotFullName("Lopez");

        }
    }
}
