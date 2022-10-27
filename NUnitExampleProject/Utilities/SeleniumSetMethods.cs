using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitExampleProject.Utilities
{

    public static class SeleniumSetMethods
    {

        //Enter Text
        public static void EnterText(this IWebElement element, string elementvalue)
        {
            element.SendKeys(elementvalue);
        }

        //Click into button, checkbox etc
        public static void DoClick(this IWebElement element)
        {
            element.Click();
        }

        // Mouse Click
        public static void MouseClick(this IWebElement element, IWebDriver driver)
        {
            Actions a = new Actions(driver);
            a.Click(element).Build().Perform();
            Console.WriteLine("Mouse Click Worked");
        }

        //Mouse Drag and Drop
        public static void MouseDragAndDrop(this IWebElement pickElement, IWebElement dropElement, IWebDriver driver)
        {
            Actions a = new Actions(driver);
            a.DragAndDrop(pickElement, dropElement)
           .Build().Perform();
            Console.WriteLine("Mouse Drag&Drop Worked");
        }

        //Selecting a dropdown control
        public static void SelectDropdown(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }

        public static void MouseMoveToElement(this IWebElement targetElement, IWebDriver driver)
        {
            Actions a = new Actions(driver);
            a.MoveToElement(targetElement)
           .Build().Perform();
            Console.WriteLine("Mouse Scroll to Element Worked");
        }

        public static void JscriptMoveToElement(this IWebElement targetElement, IWebDriver driver)
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", targetElement);
            Console.WriteLine("JScript Scroll to Element Worked");
        }

        public static bool SwitchWindow(string windowName)
        {
            if (windowName != null)
            {
                PropertiesCollections.driver.SwitchTo().Window(windowName);
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void DismissAlert()
        {
            PropertiesCollections.driver.SwitchTo().Alert().Dismiss();
        }

        public static void AcceptAlert()
        {
            PropertiesCollections.driver.SwitchTo().Alert().Accept();
        }

        public static void SendTextToAlert(string text)
        {
            PropertiesCollections.driver.SwitchTo().Alert().SendKeys(text);
        }

    }
}
