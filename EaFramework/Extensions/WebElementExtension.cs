using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EaFramework.Extensions
{
    public static class WebElementExtension
    {
        public static void SelectDropDownByText(this IWebElement element, string text)
        {
            var select = new SelectElement(element);
            select.SelectByText(text);
        }

        public static void SelectDropDownByValue(this IWebElement element, string value)
        {
            var select = new SelectElement(element);
            select.SelectByValue(value);
        }

        public static void SelectDropDownByIndex(this IWebElement element, int index)
        {
            var select = new SelectElement(element);
            select.SelectByIndex(index);
        }

        public static void SendKeys(this IWebElement element, string text, bool clearFirst = true)
        {
            if (clearFirst)
            {
                element.Clear();
            }
            element.SendKeys(text);
        }

    }
}
