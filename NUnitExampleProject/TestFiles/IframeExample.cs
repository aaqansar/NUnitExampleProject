using NUnitExampleProject.PageObject;
using NUnitExampleProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitExampleProject.TestFiles
{
    internal class IframeExample
    {

        [SetUp]
        public void Setup()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("browser_version", "67");
            chromeOptions.AddArguments("incognito");
            chromeOptions.AddUserProfilePreference("intl.accept_languages", "en");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            PropertiesCollections.driver = new ChromeDriver(chromeOptions);
            PropertiesCollections.driver.Manage().Window.Maximize();
            PropertiesCollections.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [Test]
        public void IframeTest()
        {
            try
            {
                PropertiesCollections.driver.Navigate().GoToUrl("http://demo.guru99.com/test/guru99home/");
                IframeObject ff = new IframeObject();

                //Identify the iframes
                int size = ff.GetAllIframes();

                Console.WriteLine("Total Number of iFrames {0}", size);
                for (int i = 0; i < size; i++)
                {
                    PropertiesCollections.driver.SwitchTo().Frame(i);
                    int total = ff.GetAllImageInIframes();
                    Console.WriteLine("Total Number of Image in iFrame {0} and it's an iteration {1}", total, i);
                    PropertiesCollections.driver.SwitchTo().DefaultContent();
                }
            }


            finally
            {
                PropertiesCollections.driver.Dispose();
            }
        }

        [TearDown]
        public void close_Browser()
        {
            PropertiesCollections.driver.Quit();
        }
    }
}
