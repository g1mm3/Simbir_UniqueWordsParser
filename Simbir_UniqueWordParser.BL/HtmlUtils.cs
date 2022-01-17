using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordParser.BL
{
    public static class HtmlUtils
    {
        public static List<WordStat> GetUniqueWordsStatisticsByUrl(string url)
        {
            string content = string.Empty;

            string htmlContent = GetHtmlStringByUrl(url);

            using (StringReader sr = new StringReader(htmlContent))
            {
                string line;
                string tempBuffer = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    tempBuffer += line;
                    if (line.EndsWith(">"))
                    {
                        content += Parser.GetHtmlInnerText(tempBuffer) + " ";
                        tempBuffer = string.Empty;
                        continue;
                    }

                    content += Parser.GetHtmlInnerText(line) + " ";
                }
                return Parser.GroupString(content);
            }
        }

        /// <summary>
        /// Получает HTML-код страницы в интернете
        /// </summary>
        /// <param name="url">URL-адрес сайта</param>
        /// <returns></returns>
        private static string GetHtmlStringByUrl(string url)
        {
            try
            {
                var result = string.Empty;
                var request = (HttpWebRequest)WebRequest.Create(url);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var receiveStream = response.GetResponseStream();
                        if (receiveStream != null)
                        {
                            using (StreamReader sr = new StreamReader(receiveStream, Encoding.UTF8))
                            {
                                result = sr.ReadToEnd();
                            }
                        }
                    }
                }
                return result;
            }
            catch (OutOfMemoryException ex)
            {
                throw new Exception("Ошибка памяти " + ex.Message);
            }
        }
    }
}
