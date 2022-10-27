using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitExampleProject.Utilities
{
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        ClassName,
        Class
    }

    public class PropertiesCollections
    {
        //AutoImplemented Property
        public static IWebDriver driver { get; set; }
    }
}
