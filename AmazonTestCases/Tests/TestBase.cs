using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AmazonTestCases.Models;

namespace AmazonTestCases.Tests
{
    public class TestBase
    {
        public IWebDriver driver;

        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            OpenHomePage();
        }

        public void OpenHomePage()
        {
            driver.Url = Homepage.GetUrl();
            driver.Navigate();
        }

        public void OpenPage(string url)
        {
            driver.Url = url;
            driver.Navigate();
        }
    }
}
