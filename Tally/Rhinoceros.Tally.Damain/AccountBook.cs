using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Rhinoceros.Tally.Damain
{
    public class AccountBook
    {
        public static List<Log> Logs = new List<Log>();

        public static void DisplayAllLog()
        {
            Console.WriteLine("\nDisplay all logs---------------------");
            var cacheColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var log in Logs)
            {
                Console.WriteLine(log);
            }
            Console.ForegroundColor = cacheColor;
        }

        public static void SaveAllLog()
        {
            using (var fs = new FileStream("log.xml", FileMode.OpenOrCreate))
            {

                var document = new XmlDocument();

                var dec = document.CreateXmlDeclaration("1.0", "utf-8", null);
                document.AppendChild(dec);

                var root = document.CreateElement("Root");
                document.AppendChild(root);

                foreach (var log in Logs)
                {
                    var logNote = document.CreateElement("Log");

                    logNote.SetAttribute("Time", $"{log.Time:d}");
                    logNote.SetAttribute("Type", log.Type);
                    logNote.SetAttribute("Label", log.Label);
                    logNote.SetAttribute("Money", $"{log.Money}");
                    logNote.SetAttribute("LogTime", $"{log.LogTime.Ticks}");

                    root.AppendChild(logNote);
                }
                document.Save(fs);
            }
        }

        public static void ReadAllLog()
        {
            var document = new XmlDocument();
            document.Load("log.xml");

            var xmlNodeList = document.SelectNodes("Root/Log");
            foreach (XmlNode node in xmlNodeList)
            {
                var log = new Log();

                var TimeAttr = node.Attributes["Time"];
                var time = TimeAttr.Value;
                var times = time.Split('/');
                log.Time = new DateTime(int.Parse(times[0]), int.Parse(times[1]), int.Parse(times[2]));

                var typeAttr = node.Attributes["Type"];
                log.Type = typeAttr.Value;

                var labelAttr = node.Attributes["Label"];
                log.Label = labelAttr.Value;

                var moneyAttr = node.Attributes["Money"];
                log.Money = decimal.Parse(moneyAttr.Value);

                var logTimeAttr = node.Attributes["LogTime"];
                log.LogTime = new DateTime(long.Parse(logTimeAttr.Value));

                Logs.Add(log);
            }

            DisplayAllLog();
        }
    }
}