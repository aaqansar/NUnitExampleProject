using NUnitExampleProject.PageObject;
using NUnitExampleProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace NUnitExampleProject.TestFiles
{

    public class ExecuteAutomation
    {

        EAPageObject? eAPageObject;
        LoginPageObject? lpObject;
        ExcelLib lib = new ExcelLib();


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

        [Test, Order(1)]
        public void ExecuteTest()
        {
            try
            {
                PropertiesCollections.driver.Navigate().GoToUrl("https://demosite.executeautomation.com/Login.html");
                // Calling Excel Sheet with Path
                lib.PopulateInCollection(@"E:\Data.xlsx");

                //Creating Object for Login Page and calling Method of Login Page
                lpObject = new LoginPageObject();

                //Getting Back Reference of EAPage
                eAPageObject = lpObject.Login(lib.ReadData(1, "UserName"), lib.ReadData(1, "Password"));

                //Calling Method of EAPage to Perform Action
                eAPageObject.FillUserForm(lib.ReadData(1, "Initial"), lib.ReadData(1, "FirstName"), lib.ReadData(1, "MiddleName"), lib.ReadData(1, "Title"));

                Console.WriteLine("The Value for my Initial is " + eAPageObject.GetTextFromFirstTextBox());
                Console.WriteLine("The Value for my Title is " + eAPageObject.GetTextFromDDLTitle());
                Console.WriteLine("Test Passed for Set and Get  Method");
                Thread.Sleep(2000);
            }
            finally
            {
                PropertiesCollections.driver.Dispose();
            }


        }

        [Test, Order(2)]
        public void TestMouseClick()
        {
            try
            {
                PropertiesCollections.driver.Navigate().GoToUrl("https://demosite.executeautomation.com/Login.html");
                // Calling Excel Sheet with Path
                lib.PopulateInCollection(@"E:\Data.xlsx");

                //Creating Object for Login Page and calling Method of Login Page
                lpObject = new LoginPageObject();

                //Getting Back Reference of EAPage
                eAPageObject = lpObject.Login(lib.ReadData(1, "UserName"), lib.ReadData(1, "Password"));
                eAPageObject.CheckMarkLanguageByMouseClick();
                eAPageObject.CheckMarkLanguageByClick();

                Console.WriteLine("Test Passed for MouseClick Method");
                Thread.Sleep(2000);
            }
            finally
            {
                PropertiesCollections.driver.Dispose();
            }
        }

        [Test, Order(3)]
        public void HtmlPopTest()
        {
            try
            {
                PropertiesCollections.driver.Navigate().GoToUrl("https://demosite.executeautomation.com/Login.html");
                // Calling Excel Sheet with Path
                lib.PopulateInCollection(@"E:\Data.xlsx");

                //Creating Object for Login Page and calling Method of Login Page
                lpObject = new LoginPageObject();

                //Getting Back Reference of EAPage
                eAPageObject = lpObject.Login(lib.ReadData(1, "UserName"), lib.ReadData(1, "Password"));
                string ParentWindow = eAPageObject.GetCurrentWindow();
                eAPageObject.HtmlPopupClick();
                Console.WriteLine("Parent Window {0}", ParentWindow);
                List<string> lstWindow = eAPageObject.GetCurrentWindowList();
                if (lstWindow.Count > 1)
                {
                    foreach (var handle in lstWindow)
                    {
                        Console.WriteLine("Window " + lstWindow.IndexOf(handle) + "||Value " + handle);

                        if (lstWindow.IndexOf(handle) == 1)
                        {
                            bool b = eAPageObject.SwitchWindowMethod(handle);
                            if (b == true)
                            {
                                Console.WriteLine("Test Passed to Switch Multiple Window");
                                PropertiesCollections.driver.Navigate().GoToUrl("https://www.google.com");
                                Thread.Sleep(2000);
                                PropertiesCollections.driver.Close();
                            }
                            else
                            {
                                Console.WriteLine("Test failed to Switch Multiple Window");
                            }
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Child Window Not Exist");
                }


                Thread.Sleep(2000);
            }
            finally
            {
                PropertiesCollections.driver.Dispose();
            }
        }


        [Test, Order(4)]
        public void TestMouseDragAndDrop()
        {
            try
            {
                // Calling Excel Sheet with Path
                PropertiesCollections.driver.Navigate().GoToUrl("https://material.angular.io/cdk/drag-drop/examples");

                MaterialPageObject mo = new MaterialPageObject();
                mo.DragAndDropCard(mo.cardRight, mo.cardLeft);
                Thread.Sleep(2000);
                Console.WriteLine("Test Passed for Drag and Drop Method");
                mo.MoveToElementMouse(mo.scrollPageTillHeading);
                Thread.Sleep(2000);
                mo.MoveToElementJscript(mo.scrollPageToConnectedSorting);
                Console.WriteLine("Test Passed Scrolling webpage till content");
                Thread.Sleep(2000);
                mo.DragAndDropCard(mo.todoSecondItem, mo.doneThirdItem);
                Thread.Sleep(2000);
                Console.WriteLine("Test Passed Item dragged and inserted in right");

            }
            finally
            {
                PropertiesCollections.driver.Dispose();
            }
        }

        [Test, Order(5)]
        public void JavaScriptAlertTest()
        {
            try
            {
                PropertiesCollections.driver.Navigate().GoToUrl("https://demosite.executeautomation.com/Login.html");
                // Calling Excel Sheet with Path
                lib.PopulateInCollection(@"E:\Data.xlsx");

                //Creating Object for Login Page and calling Method of Login Page
                lpObject = new LoginPageObject();

                //Getting Back Reference of EAPage
                eAPageObject = lpObject.Login(lib.ReadData(1, "UserName"), lib.ReadData(1, "Password"));
                eAPageObject.JavaScriptPopupClick();
                if (eAPageObject.GetTextFromAlertMethod() == "You generated a Javascript alert")
                {
                    Thread.Sleep(2000);
                    eAPageObject.AcceptAlertMethod();
                    if (eAPageObject.GetTextFromAlertMethod() == "You pressed OK!")
                    {
                        Thread.Sleep(2000);
                        eAPageObject.AcceptAlertMethod();
                    }
                }
                Thread.Sleep(2000);
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

