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


        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void fb()
        {
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            FbObject fb = new FbObject();
            //FbObject fb = new FbObject(PageFactory);
            fb.TestLogin("abdullahahmadkhan@yahoo.in");


        }  
        }
}
