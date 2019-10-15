using System;
using OpenQA.Selenium;

namespace AmazonTestCases.Models
{
    public static class Search
    {
        public static string searchUrl = @"s? k = {0} &ref=nb_sb_noss_2";

        public static string GetUrl(string search)
        {
            searchUrl = String.Format(searchUrl, search);
            return String.Concat(Homepage.GetUrl(), searchUrl);
        }

        public static IWebElement GetFirstResult(IWebDriver driver, string selector)
        {
            return driver.FindElement(By.XPath($"//*[@id='search']/div//descendant::h2/a/span[contains(text(), '{selector}')]"));     
        }

    }
}
