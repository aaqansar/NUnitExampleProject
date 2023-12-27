using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnitExampleProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace NUnitExampleProject.PageObject
{
    internal class FbObject
    {
        public FbObject()
        {
            PageFactory.InitElements(PropertiesCollections.driver, this);
        }

        //Page Factory Logic
        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement txtemail { get; set; }

        [FindsBy(How = How.Id, Using = "pass")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Name, Using = "login")]
        public IWebElement btnFBLogin { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='_9ay7']")]
        public IWebElement errorMessage { get; set; }

        public void TestLogin(string email,string pass)
        {
            txtemail.EnterText(email);
            txtPassword.EnterText(pass);
            btnFBLogin.DoClick();     
        }

        public string Gettexterror()
        {
            return errorMessage.GetTextFromDiv();
        }


    }
}
