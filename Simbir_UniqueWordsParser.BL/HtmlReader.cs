using Simbir_UniqueWordsParser.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.BL
{
    public class HtmlReader : IReader
    {
        public delegate void EventHandler(string exclamationMessage);
        public event EventHandler ShowExclamation;

        public async Task<List<WordStat>> GetUniqueWordsStatisticsByUrl(string url)
        {
            try
            {
                if (!IsUrlAddressValid(url))
                    return null;

                string htmlContent = await GetHtmlCodeStringByUrl(url);

                // Последовательность выполнения методов - важна
                htmlContent = Parser.RemoveHtmlTagWithContent(htmlContent, "head");
                htmlContent = Parser.RemoveHtmlTagWithContent(htmlContent, "noscript");
                htmlContent = Parser.RemoveHtmlTagWithContent(htmlContent, "script");
                htmlContent = Parser.RemoveAllHtmlTagBrackets(htmlContent);
                htmlContent = Parser.RemoveUnicodeSymbols(htmlContent);
                htmlContent = Parser.RemoveAllHtmlComments(htmlContent);

                List<WordStat> result = Parser.GroupString(htmlContent);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Метод, отвечающий за валидацию введённого URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private bool IsUrlAddressValid(string url)
        {
            if (!url.StartsWith("https://"))
            {
                ShowExclamation?.Invoke("Введите ссылку, начинающуюся с https://");
                return false;
            }

            Match match = Regex.Match(url, @"^https://\w+\..+");
            if (!match.Success)
            {
                ShowExclamation?.Invoke("Введите ссылку в формате: https://site.com");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Получает HTML-код страницы в интернете
        /// </summary>
        /// <param name="url">URL-адрес сайта</param>
        /// <returns></returns>
        private static async Task<string> GetHtmlCodeStringByUrl(string url)
        {
            var result = string.Empty;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                using (HttpWebResponse response = (HttpWebResponse)(await request.GetResponseAsync()))
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
                                result = await sr.ReadToEndAsync();
                            }
                        }
                    }
                }
                return result;
            }
            catch (OutOfMemoryException ex)
            {
                throw new Exception("Нехватка памяти, сообщение исключения: " + ex.Message);
            }
            catch (WebException ex)
            {
                // Если запрос на сайт через https прошёл неудачно, то запрос отправляется через http
                if (url.StartsWith("https://"))
                {
                    url = url.Remove(4, 1);
                    return await GetHtmlCodeStringByUrl(url);
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
