using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReadCSV
{
    internal class GetData
    {
        List<OneFly> flies;
        public GetData(List<OneFly>_flies) 
        { 
        flies = _flies;
        }
        public void getfliesByDate(string fromDate, string toDate = "2006-01-01")
        {
            IEnumerable<OneFly> result =
                flies.Where(x => x.DateFly >= DateTime.Parse(fromDate) &&
                                 x.DateFly <= DateTime.Parse(toDate));
            if (result.Count() > 0)
                foreach (OneFly item in result)
                {
                    Console.WriteLine(item);
                }
            else
                Console.WriteLine("Нет данных для вывода");
            writeDataToFile($"Поиск_по_дате_{fromDate}_{toDate}.csv", result);
        }

        private void writeDataToFile(string fileName, IEnumerable<OneFly> list)
        {
            string line;
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                if (list.Count() > 0)
                {
                    foreach (OneFly item in list)
                    {
                        line = String.Empty;
                        line += $"{item.DateFly};{item.CompanyName};" +
                            $"{item.PlaneName};{item.FromCity};" +
                            $"{item.ToCity};{item.PassangerName};" +
                            $"{item.Place}";
                        sw.WriteLine(line);
                    }

                }
               
            }
        }
        public void getfliesNotFullName(string name)
        {
            IEnumerable<OneFly> result =
                flies.Where(x => x.PassangerName.Contains(name));
            if (result.Count() > 0)
            {
                foreach (OneFly item in result)
                {
                    Console.WriteLine(item);
                }
            }
            else
                Console.WriteLine("Нет данных для вывода");
        }
    }
}
