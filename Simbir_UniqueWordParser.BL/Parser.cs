using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simbir_UniqueWordParser.BL
{
    public class Parser
    {
        public static string GetHtmlInnerText(string htmlContent)
        {
            try
            {
                return HtmlRegexParse(htmlContent);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static string HtmlRegexParse(string htmlContent)
        {
            if (string.IsNullOrWhiteSpace(htmlContent))
            {
                return null;
            }

            return Regex.Replace(htmlContent, @"<[^>]+>|&nbsp;|<span>|&mdash|&raquo", string.Empty);
        }

        public static string GroupString(string content)
        {
            var masssivCar = new char[] { ' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t', '\\', '/', '{', '}' }; // todo качество поиск
            List<string> contentList = content.Split(masssivCar).ToList();
            var newcontentList = new List<string>();
            foreach (var item in contentList)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    newcontentList.Add(item);
                }
            }

            var rez = from r in newcontentList
                      group r by r.ToUpper() into g
                      select (Name: g.Key, Count: g.Count());

            string rezList = string.Empty;

            foreach (var item in rez.OrderByDescending(x => x.Count).ThenBy(x => x.Name))
            {
                if (item.Name != null)
                {
                    rezList += $"{item.Name} - {item.Count} \n";
                }

            }

            return rezList;
        }
    }
}
