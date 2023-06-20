using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadCSV
{
    internal class OneFly
    {
        public OneFly(string dateFly, string passangerName, string companyName,string planeName,string fromCity,string toCity,string place)
            {
            DateFly = DateTime.Parse(dateFly);
            PassangerName = passangerName;
            CompanyName = companyName;
            PlaneName = planeName;
            FromCity = fromCity;
            ToCity = toCity;
            Place = place;            
            }
        public OneFly(string[] arguments )
        {
            DateFly = DateTime.Parse(arguments[0]);
            PassangerName = arguments[1];
            CompanyName = arguments[2];
            PlaneName = arguments[3];
            FromCity = arguments[4];
            ToCity = arguments[5];
            Place = arguments[6];
        }
        public DateTime DateFly { get; set; }
        public string PassangerName { get; set; }
        public string CompanyName { get; set; }
        public string PlaneName { get; set; }
        public string FromCity{ get; set; }
        public string ToCity { get; set; }
        public string Place { get; set; }

        public override string ToString()
        {
            string message = string.Empty;
            message += $"Дата вылета: {DateFly.ToString("dd.MM.yyyy")}\n";
            message += $"Авиокомпания: {CompanyName}\n";
            message += $"Самолет: {PlaneName}\n";
            message += $"Убытие: {FromCity}\n";
            message += $"Прибытие: {ToCity}\n";
            message += $"Пассажир: {PassangerName}\n";
            message += $"Место: {Place}\n";
            return message;
        }
    }
}
