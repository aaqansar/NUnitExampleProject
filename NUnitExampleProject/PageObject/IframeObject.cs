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
    internal class IframeObject
    {
        public IframeObject()
        {
            PageFactory.InitElements(PropertiesCollections.driver, this);
        }

        //Page Factory Logic
        [FindsBy(How = How.TagName, Using = "iframe")]
        public IWebElement iFrameElement { get; set; }

        [FindsBy(How = How.XPath, Using = "html/body/a/img")]
        public IWebElement imageXpath { get; set; }

        public int GetAllIframes()
        {
            return SeleniumGetMethods.GetAllFramesMethod();
        }
        public int GetAllImageInIframes()
        {
            return SeleniumGetMethods.GetAllImagesInIframeMethod();
        }
    }
}
