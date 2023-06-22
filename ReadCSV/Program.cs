using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCSV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выбирите способ получения данных\n1. Файл\n2.SQL");
            if(Int32.TryParse(Console.ReadLine(),out int result))
            {
                switch (result)
                {
                    case 1:
                        new SQLReader();
                        break;
                    case 2:
                        new FromFile();
                        break;

                }


            }
  
        }

    }
}
