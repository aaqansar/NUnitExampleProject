﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitExampleProject
{
    public static class SeleniumGetMethods
    {
        public static string GetText(this IWebElement element)
        {
            return element.GetAttribute("value");  
        }

        public static string GetCurrentWindowName()
        {
            return PropertiesCollections.driver.CurrentWindowHandle;
           
        }

        public static List<string> GetAllWindowName()
        {
            List<string> result = new List<string>();
            result = PropertiesCollections.driver.WindowHandles.ToList();
            return result;
        }

        public static string GetTextFromDDL(this IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;  
        }

        public static string GetAlertText()
        {
            return PropertiesCollections.driver.SwitchTo().Alert().Text;
        }
    }
}