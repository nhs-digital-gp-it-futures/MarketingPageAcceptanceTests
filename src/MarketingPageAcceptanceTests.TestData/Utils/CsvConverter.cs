using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MarketingPageAcceptanceTests.TestData.Utils
{
    public static class CsvConverter
    {
        public static string ToCsv<T>(this IEnumerable<T> objectList, string separator)
        {
            Type t = typeof(T);
            PropertyInfo[] properties = t.GetProperties();

            string header = GetHeaderLine(separator, properties);

            StringBuilder csvBuilder = new StringBuilder();
            csvBuilder.AppendLine(header);

            foreach(var o in objectList)
            {
                csvBuilder.AppendLine(ToCsvLines(separator, properties, o));
            }

            return csvBuilder.ToString();
        }

        private static string GetHeaderLine(string separator, PropertyInfo[] properties)
        {
            List<string> headers = new List<string>();

            foreach (var p in properties)
            {
                if (p.GetCustomAttributes(typeof(DisplayAttribute), false).Length > 0)
                {
                    headers.Add(p.GetCustomAttributes(typeof(DisplayAttribute), false).Cast<DisplayAttribute>().Single().Name);
                }
                else
                {
                    headers.Add(p.Name);
                }
            }

            return string.Join(separator, headers);
        }

        private static string ToCsvLines<T>(string separator, PropertyInfo[] properties, T o)
        {
            StringBuilder line = new StringBuilder();

            foreach(var p in properties)
            {
                if (line.Length > 0)
                {
                    line.Append(separator);
                }

                var lineValue = p.GetValue(o);

                if(lineValue != null)
                {
                    line.Append(lineValue);
                }                
            }
            return line.ToString();
        }
    }
}
