﻿using System;
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
            try
            {
                string htmlContent = GetHtmlStringByUrl(url);

                // Последовательность выполнения методов - важна
                htmlContent = Parser.RemoveHtmlTagWithContent(htmlContent, "head");
                htmlContent = Parser.RemoveHtmlTagWithContent(htmlContent, "noscript");
                htmlContent = Parser.RemoveHtmlTagWithContent(htmlContent, "script");
                htmlContent = Parser.RemoveAllHtmlTagBrackets(htmlContent);
                htmlContent = Parser.RemoveUnicodeSymbols(htmlContent);
                htmlContent = Parser.RemoveAllHtmlComments(htmlContent);

                return Parser.GroupString(htmlContent);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Получает HTML-код страницы в интернете
        /// </summary>
        /// <param name="url">URL-адрес сайта</param>
        /// <returns></returns>
        private static string GetHtmlStringByUrl(string url)
        {
            string htmlCode = string.Empty;

            try
            {
                htmlCode = GetHtmlCode(url);
            }
            catch (OutOfMemoryException ex)
            {
                throw new Exception("Нехватка памяти: " + ex.Message);
            }
            // Если при подключении через https возникнут ошибки, то запрос на сайт будет уже через http
            catch (Exception)
            {
                if (url.StartsWith("https://"))
                {
                    url = url.Remove(4, 1);
                    return GetHtmlCode(url);
                }
            }

            return htmlCode;
        }

        private static string GetHtmlCode(string url)
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
                        Encoding encoding = Encoding.UTF8;

                        if (response.CharacterSet == "windows-1251")
                        {
                            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                            encoding = Encoding.GetEncoding("windows-1251");
                        }

                        using (StreamReader sr = new StreamReader(receiveStream, encoding))
                        {
                            result = sr.ReadToEnd();
                        }
                    }
                }
            }
            return result;
        }
    }
}
