using NUnitExampleProject.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitExampleProject.PageObject
{

    class EAPageObject
    {
        // Constructor for Page
        public EAPageObject()
        {
            PageFactory.InitElements(PropertiesCollections.driver, this);
        }

        //Page Factory Logic
        [FindsBy(How = How.Id, Using = "TitleId")]
        public IWebElement ddlTitleId { get; set; }

        [FindsBy(How = How.Name, Using = "Initial")]
        public IWebElement txtInitial { get; set; }

        [FindsBy(How = How.Name, Using = "Save")]
        public IWebElement btnSave { get; set; }

        [FindsBy(How = How.Name, Using = "FirstName")]
        public IWebElement txtFirstName { get; set; }

        [FindsBy(How = How.Id, Using = "MiddleName")]
        public IWebElement txtMiddleName { get; set; }

        [FindsBy(How = How.Name, Using = "Hindi")]
        public IWebElement checkboxLanguage { get; set; }

        [FindsBy(How = How.Name, Using = "Female")]
        public IWebElement radioButtonGender { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='popup.html']")]
        public IWebElement htmlPopupLink { get; set; }

        [FindsBy(How = How.Name, Using = "generate")]
        public IWebElement btnJavaScriptAlert { get; set; }



        public void FillUserForm(string initial, string firstname, string middlename, string ddlvalue)
        {
            // Calling via Custom Methods
            ddlTitleId.SelectDropdown(ddlvalue);
            txtInitial.EnterText(initial);
            //Can also be called via extended methods
            txtFirstName.EnterText(firstname);
            PropertiesCollections.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            //SeleniumSetMethods.EnterText(txtFirstName, firstname);
            txtMiddleName.EnterText(middlename);
        }

        public string GetTextFromFirstTextBox()
        {
            return txtFirstName.GetText();
        }
        public string GetTextFromDDLTitle()
        {
            return ddlTitleId.GetTextFromDDL();
        }

        public void CheckMarkLanguageByClick()
        {
            checkboxLanguage.DoClick();
        }

        public string GetCurrentWindow()
        {
            return SeleniumGetMethods.GetCurrentWindowName();
        }

        public List<string> GetCurrentWindowList()
        {
            return SeleniumGetMethods.GetAllWindowName();
        }

        public void CheckMarkLanguageByMouseClick()
        {
            checkboxLanguage.MouseClick(PropertiesCollections.driver);
            radioButtonGender.DoClick();
            btnSave.DoClick();
        }

        public void HtmlPopupClick()
        {
            htmlPopupLink.DoClick();
        }

        public void JavaScriptPopupClick()
        {
            btnJavaScriptAlert.DoClick();
        }

        public bool SwitchWindowMethod(string windowName)
        {
            return SeleniumSetMethods.SwitchWindow(windowName);
        }

        public string GetTextFromAlertMethod()
        {
            return SeleniumGetMethods.GetAlertText();
        }

        public void AcceptAlertMethod()
        {
            SeleniumSetMethods.AcceptAlert();
        }

        public void RejectAlertMethod()
        {
            SeleniumSetMethods.DismissAlert();
        }

    }
}
