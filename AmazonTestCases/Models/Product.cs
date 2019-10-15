using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AmazonTestCases.Models
{
    public static class Product
    {

        public static void AddToCart(IWebDriver driver)
        {
            IWebElement button = driver.FindElement(By.XPath("//*[@id='add-to-cart-button']"));
            button.Click();
        }
    }
}
