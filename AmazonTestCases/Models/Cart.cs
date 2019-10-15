using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AmazonTestCases.Models
{
    public static class Cart
    {
        public static string cartUrl = @"gp/cart/view.html?ref_=nav_cart";

        public static string GetUrl()
        {
            return String.Concat(Homepage.GetUrl(), cartUrl);
        }

        public static IWebElement GetCartItem(IWebDriver driver, string item)
        {
            return driver.FindElement(By.XPath($"//*[@data-name='Active Items']//descendant::span/a/span[contains(text(), '{item}')]"));
        }

    }
}
