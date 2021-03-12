using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhinoceros.Tally.Damain
{
    /// <summary>
    /// Food - Breakfast - 12             ==> 今天 早餐 花了 12 块钱
    /// Food - Breakfast - 12 - 10        ==> 这个月的10号早餐花了 12 块钱
    /// Food - Breakfast - 12 - 5.10      ==> 5月10号 早餐 花了 10 块钱
    /// Food - Breakfast - 12 - 2020.5.10 ==> 2020年5月10日 早餐 花了 10块钱
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Food
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Breakfast
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 12
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 消费时间
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// 记录日志的时间
        /// </summary>
        public DateTime LogTime { get; set; }

        public override string ToString()
        {
            return $"{Time:d} - {Type} - {Label} - {Money}";
        }

        public static void AddLog()
        {
            Console.WriteLine("\nAdd a Log -------------------------");

            var log = new Log();

            Console.Write("1.(string) Type: ");
            var input = Console.ReadLine();
            log.Type = input;

            Console.Write("2.(string) Label:");
            input = Console.ReadLine();
            log.Label = input;

            Console.Write("3.(float) Money:");
            input = Console.ReadLine();
            log.Money = decimal.Parse(input);

            Console.Write("4.(= | Day | Month.Day | Year.Month.Day ) Time:");
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) log.Time = DateTime.Now;
            else
            {
                var inputs = input.Split('.');
                if (inputs.Length == 1)
                {
                    log.Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, int.Parse(inputs[0]));
                }
                else if (inputs.Length == 2)
                {
                    log.Time = new DateTime(DateTime.Now.Year, int.Parse(inputs[0]), int.Parse(inputs[1]));
                }
                else if (inputs.Length == 3)
                {
                    log.Time = new DateTime(int.Parse(inputs[0]), int.Parse(inputs[1]), int.Parse(inputs[2]));
                }
            }

            AccountBook.Logs.Add(log);

            var cacheColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(log);
            Console.ForegroundColor = cacheColor;
        }
    }
}