using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnitExampleProject.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

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

        public void TestLogin(string email)
        {
            txtemail.EnterText(email);
        }
    }
}
