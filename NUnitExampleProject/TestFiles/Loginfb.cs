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
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

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
            fb.TestLogin("abdullahahmadkhan@yahoo.in","Test@123");
            WebDriverWait wait = new WebDriverWait(PropertiesCollections.driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='_9ay7']")));

            string s = fb.Gettexterror();
            Console.WriteLine(s);
            int length=s.Length;
            Console.WriteLine("Character Count is :"+length);

            char ch = 'a';
            int count = s.Split(ch).Length - 1;
            Console.WriteLine("Total count of 'a' in a given string is : "+count);

        }

        
    }


}

