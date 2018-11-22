using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace TestLeaf.Methods
{
    public static class ExtentionMethods
    {
        public static void ClickOnIt(this IWebElement element)
        {
            element.Click();
        }

        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        public static void SelectByIndex(this IWebElement element, int index)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByIndex(index);
        }

        public static void SelectByText(this IWebElement element, string text)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(text);
        }

        public static void SelectByValue(this IWebElement element, string value)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByValue(value);
        }

        public static int NumberOfOptions(this IWebElement element)
        {
            SelectElement select = new SelectElement(element);
            IList<IWebElement> oSelect = select.Options;
            return oSelect.Count;
        }

        public static string GetTextBoxText(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static bool VerifyBrokenLink(this IWebElement element)
        {
            HttpWebRequest re = null;
            re = (HttpWebRequest)WebRequest.Create(element.GetAttribute("href"));
            bool broken;
            try
            {
                var response = (HttpWebResponse)re.GetResponse();
                broken = false;
            }
            catch (WebException e)
            {
                var errorResponse = (HttpWebResponse)e.Response;
                broken = true;
            }
            return broken;
        }
    }
}
