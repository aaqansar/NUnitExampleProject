using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitExampleProject
{
    internal class WaitExample
    {
        IWebDriver driver;
        DateTime now;
        long StartTime, EndTime;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            
            driver.Navigate().GoToUrl("https://www.google.com");
            now = DateTime.Now;
            StartTime = now.Second;
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            WebDriverWait w = new WebDriverWait(driver,TimeSpan.FromSeconds(10));
            w.Until(ExpectedConditions.ElementExists(By.CssSelector("[name = 'q']")));

            Console.WriteLine("NOW: " + now + "|Converted Start Time| "+ StartTime);
            IWebElement searchText = driver.FindElement(By.CssSelector("[name = 'q']"));

            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            IWebElement searchText1 = driver.FindElement(By.CssSelector("[name = 'i']"));

        }

        [TearDown]
        public void close_Browser()
        {
            DateTime now1 = DateTime.Now;
            EndTime = now1.Second;
            Console.WriteLine("NOW: " + now + "|Converted End Time| " + EndTime);
            Console.WriteLine("diff: " + (EndTime-StartTime));
            driver.Quit();
        }
    }
}
