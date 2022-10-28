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
    internal class MaterialPageObject
    {

        // Constructor for Page
        public MaterialPageObject()
        {
            PageFactory.InitElements(PropertiesCollections.driver, this);
        }

        //Page Factory Logic
        [FindsBy(How = How.XPath, Using = "//div[@class='cdk-drag example-box'][contains(text(),'I can only be dragged up/down')]")]
        public IWebElement cardLeft { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='cdk-drag example-box'][contains(text(),'I can only be dragged left/right')]")]
        public IWebElement cardRight { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='Drag&Drop connected sorting group']")]
        public IWebElement scrollPageTillHeading { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='Drag&Drop connected sorting']")]
        public IWebElement scrollPageToConnectedSorting { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='cdk-drop-list-0']/div[2]")]
        public IWebElement todoSecondItem { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='cdk-drop-list-1']/div[3]")]
        public IWebElement doneThirdItem { get; set; }




        public void DragAndDropCard(IWebElement elepick, IWebElement eledrop)
        {
            elepick.MouseDragAndDrop(eledrop, PropertiesCollections.driver);

        }

        public void MoveToElementMouse(IWebElement target)
        {
            target.MouseMoveToElement(PropertiesCollections.driver);
        }
        public void MoveToElementJscript(IWebElement target)
        {
            target.JscriptMoveToElement(PropertiesCollections.driver);
        }

    }
}
