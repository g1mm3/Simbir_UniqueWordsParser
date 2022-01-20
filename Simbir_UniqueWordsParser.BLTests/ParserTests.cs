using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simbir_UniqueWordsParser.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbir_UniqueWordsParser.BL.Tests
{
    [TestClass()]
    public class ParserTests
    {
        [TestMethod()]
        public void RemoveHtmlTagWithContentTest_Head_Tag_Meta_Title_Delete_Content()
        {
            string htmlContent =
            @"<head>
                <meta charset=""utf-8"">
                <title>Yandex</title>
            </head>
            <body></body>";

            string htmlTag = "head";

            string expected = "<body></body>";
            string real = Parser.RemoveHtmlTagWithContent(htmlContent, htmlTag).Trim();
            Assert.AreEqual(expected, real);
        }

        [TestMethod()]
        public void RemoveAllHtmlTagBracketsTest_Tags_Head_Body_Meta_Title_Delete()
        {
            string htmlContent =
            @"<head>
                <meta charset=""utf-8"">
                <title>Yandex</title>
            </head>
            <body></body>";

            string expected = "Yandex";
            string real = Parser.RemoveAllHtmlTagBrackets(htmlContent).Trim();
            Assert.AreEqual(expected, real);
        }

        [TestMethod()]
        public void RemoveAllHtmlCommentsTest_Comment_Delete()
        {
            string htmlContent =
            @"<head>
                <meta charset=""utf-8"">
                <title>Yandex</title>
            </head>
            <body></body>
            <!-- комментарий -->";

            string expected =
            @"<head>
                <meta charset=""utf-8"">
                <title>Yandex</title>
            </head>
            <body></body>";
            string real = Parser.RemoveAllHtmlComments(htmlContent).Trim();
            Assert.AreEqual(expected, real);
        }

        [TestMethod()]
        public void RemoveUnicodeSymbolsTest_Reg_Symbol_Delete()
        {
            string htmlContent =
            "©1997-2022 Yandex";

            string expected =
            "1997-2022 Yandex";
            string real = Parser.RemoveUnicodeSymbols(htmlContent).Trim();
            Assert.AreEqual(expected, real);
        }
    }
}