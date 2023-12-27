using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace NUnitExampleProject.TestFiles
{
    internal class HyperLink
    {
        IWebDriver driver;
        HttpWebRequest request = null;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestHyperlink()
        {
            int i = 0;
            //driver.Manage().Timeouts().SetPageLoadTimeout=TimeSpan.FromSeconds(500);
            driver.Navigate().GoToUrl("https://www.zlti.com");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            IList<IWebElement> le = driver.FindElements(By.TagName("a"));
            foreach (IWebElement ele in le)
            {
                string hrefUrl = ele.GetAttribute("href");
                Console.WriteLine(hrefUrl);
                if (hrefUrl != null)
                {
                    if (hrefUrl.Contains("tel"))
                    {
                        Console.WriteLine(hrefUrl + " This contain tel , email or @, hence skipped");
                    }
                    else if (hrefUrl.Contains("email"))
                    {
                        Console.WriteLine(hrefUrl + " This contain email, hence skipped");
                    }
                    else if (hrefUrl.Contains('@'))
                    {
                        Console.WriteLine(hrefUrl + " This contain @, hence skipped");
                    }

                    else
                    {
                        var k = isLinkWorking(hrefUrl);

                        if (k == true)
                        {
                            Console.WriteLine(hrefUrl + " This is valid URL as response came " + k);
                        }
                        else
                        {
                            Console.WriteLine(hrefUrl + " This is invalid URL as response came " + k);
                        }
                    }
                }
            }


            bool isLinkWorking(string url)
            {

                var webclient = new HttpClient();
                webclient.Timeout = TimeSpan.FromSeconds(30);
                if (!url.StartsWith("tel"))
                {
                    var response = webclient.GetAsync(url).Result;
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        response.Dispose();
                        return true;
                    }
                    else
                    {
                        response.Dispose();
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

        }

        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}
