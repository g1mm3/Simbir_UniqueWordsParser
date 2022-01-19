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
        public static string RemoveHtmlTagWithContent(string htmlContent, string tag)
        {
            return Regex.Replace(htmlContent, @$"<{tag}[\W\w\S\s]*?>[\W\w\S\s]*?</{tag}>", string.Empty);
        }

        public static string RemoveAllHtmlTagBrackets(string htmlContent)
        {
            return Regex.Replace(htmlContent, @"<[\W\w\S\s]*?>", string.Empty);
        }

        public static string RemoveAllHtmlComments(string htmlContent)
        {
            return Regex.Replace(htmlContent, @"<!--[\W\w\S\s]*?-->", string.Empty);
        }

        public static string RemoveUnicodeSymbols(string htmlContent)
        {
            string[] symbols = new string[]
            {
                "&nbsp;", "&#160;",
                "&reg;", "&#174;", "®",
                "&trade;", "&#8482;", "™",
                "&quot;", "&#34;",
                "&ndash;", "&#8211;",
                "&mdash;", "&#8212;",
                "&laquo;", "&#171;", "«",
                "&raquo;", "&#187;", "»",
            };

            string symbolsString = string.Empty;
            foreach(string symbol in symbols)
            {
                symbolsString += $"{symbol}|";
            }
            symbolsString = symbolsString.Remove(symbolsString.Length - 1);

            return Regex.Replace(htmlContent, @$"{symbolsString}", string.Empty);
        }

        public static List<WordStat> GroupString(string content)
        {
            var splitSymbolsArray = new char[] { ' ', ',', '.', '!', '?', '"', ';', ':',
                '[', ']', '(', ')', '\n', '\r', '\t', '\\', '/', '{', '}' };

            List<string> contentList = content.Split(splitSymbolsArray).ToList();
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

            List<WordStat> wordsStat = new List<WordStat>();
            foreach (var item in rez.OrderByDescending(x => x.Count).ThenBy(x => x.Name))
            {
                string word = item.Name;
                if (word != null)
                {
                    // Если в строке нет хотя-бы одной буквы, то эта строка пропускается
                    if (!word.Any(x => char.IsLetter(x)))
                        continue;

                    // Удаление всех числе из строки
                    word = Regex.Replace(item.Name, "[0-9]", string.Empty);

                    wordsStat.Add(new WordStat { Word = word, Count = item.Count });
                }

            }

            return wordsStat;
        }
    }
}
