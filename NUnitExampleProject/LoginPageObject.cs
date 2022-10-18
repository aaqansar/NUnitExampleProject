using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitExampleProject
{
    internal class LoginPageObject
    {
       
        // Constructor for Page
        public LoginPageObject()
        {
            PageFactory.InitElements(PropertiesCollections.driver, this);
        }

        //Page Factory Logic
        [FindsBy(How = How.Name, Using = "UserName")]
        public IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Name, Using = "Password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='Login']")]
        public IWebElement btnLogin { get; set; }

        public EAPageObject Login(string userName, string password)
        {
            // Calling via Custom Methods
            SeleniumSetMethods.EnterText(txtUserName, userName);
            SeleniumSetMethods.EnterText(txtPassword, password);
            PropertiesCollections.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            SeleniumSetMethods.DoClick(btnLogin);

            //Return the page object
            return  new EAPageObject();
        }
    }

}
