using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace NUnitExampleProject
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            //driver.Manage().Timeouts().SetPageLoadTimeout=TimeSpan.FromSeconds(500);
            driver.Navigate().GoToUrl("https://www.google.com");

            driver.Manage().Timeouts().ImplicitWait= TimeSpan.FromSeconds(20);

            IWebElement searchText = driver.FindElement(By.CssSelector("[name = 'q']"));

            //IWebElement searchText1 = driver.FindElement(By.Name("q"));

            //IWebElement searchText2 = driver.FindElement(By.XPath("//input[@title='Search']"));

            searchText.SendKeys("LambdaTest" +Keys.Enter);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            String TargetPath = "//h3[.='LambdaTest: Most Powerful Cross Browser Testing Tool Online']";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));


            IWebElement SearchResult = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(TargetPath)));

            SearchResult.Click();

            System.Threading.Thread.Sleep(6000);

            Console.WriteLine("Test Passed");
        }

        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
    
}