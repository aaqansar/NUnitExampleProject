using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnitExampleProject.Utilities;
using NUnitExampleProject.PageObject;
using SeleniumExtras.PageObjects;

namespace NUnitExampleProject.TestFiles
{
    public class Loginfb
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
        public void fb()
        {
            PropertiesCollections.driver.Navigate().GoToUrl("https://www.facebook.com/");
            FbObject fb = new FbObject();
            fb.TestLogin("abdullahahmadkhan@yahoo.in");
        }  
        }
}
