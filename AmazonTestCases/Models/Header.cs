using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AmazonTestCases.Models
{
    public static class Header
    {
        public static IWebElement GetSearchBox(IWebDriver driver)
        {
            return driver.FindElement(By.XPath("//*[@id='twotabsearchtextbox']"));
        }

        public static void RunSearch(IWebDriver driver, string search)
        {
            IWebElement searchBox = GetSearchBox(driver);
            searchBox.SendKeys(search);
            searchBox.SendKeys(Keys.Enter);
        }
    }
}
