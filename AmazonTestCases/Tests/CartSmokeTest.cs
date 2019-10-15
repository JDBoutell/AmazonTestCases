using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using AmazonTestCases.Models;

namespace AmazonTestCases.Tests
{
    public class CartSmokeTest : TestBase
    {
        //Please change these 2 variables to wherever you want to save the screenshot and its name.
        private string fileLocation = @"D:\";
        private string fileName = "screenshot.png";

        [OneTimeSetUp]
        public void FirstTimeSetup()
        {
            Initialize();
            OpenHomePage();
        }

        [OneTimeTearDown]
        public void EndOfTestTeardown()
        {
            driver.Close();
            driver.Dispose();
        }

        [TestCase]
        [Description("Adding 3 items to the cart, then removing one.")]
        public void MultipleItemsAddThenRemoveOne()
        {
            string item1 = "ASUS MG28UQ 4K/UHD 28-Inch Gaming";
            string item2 = "Metasploit: The Penetration Tester's Guide Book";
            string item3 = "PerfectoStore Meow Meow Meow Halloween Cup";
            string item1Verify = "ASUS MG28UQ 4K/UHD 28-Inch";
            string item2Verify = "Metasploit: The Penetration Tester";
            string item3Verify = "PerfectoStore";
            string screenShotFile = String.Concat(fileLocation, fileName);

            //Adding items to the cart
            AddItemToCart(item1, item1Verify);
            AddItemToCart(item2, item2Verify);
            AddItemToCart(item3, item3Verify);

            //Taking screenshot after all items have been added to the cart
            Screenshot pic = ((ITakesScreenshot)driver).GetScreenshot();
            pic.SaveAsFile(screenShotFile, ScreenshotImageFormat.Png);

            //Going to the cart to verify the items were added to the cart successfully
            OpenPage(Cart.GetUrl());

            IWebElement product = Cart.GetCartItem(driver, item1Verify);
            Assert.That(product.Displayed, $"The item, {item1}, was not displayed on the cart page.");

            product = Cart.GetCartItem(driver, item2Verify);
            Assert.That(product.Displayed, $"The item, {item2}, was not displayed on the cart page.");

            product = Cart.GetCartItem(driver, item3Verify);
            Assert.That(product.Displayed, $"The item, {item3}, was not displayed on the cart page.");

            //Removing the Monitor
            product = Cart.GetDeleteButton(driver, item1Verify);
            product.Click();

            try
            {
                product = Cart.GetCartItem(driver, item1Verify);
            }
            catch(NoSuchElementException e)
            {
                Assert.That(e.Message.Contains("Unable to locate element:"), "The error retrieved was not the error expected, " + e.Message);
            }
        }

        public void AddItemToCart(string search, string product)
        {
            OpenHomePage();
            Header.RunSearch(driver, search);
            IWebElement item = Search.GetFirstResult(driver, product);
            item.Click();
            Product.AddToCart(driver);
            bool protectionPlan = true;
            
            try
            {
                driver.FindElement(By.XPath("//*[@id='attach-warranty-pane']"));
            }
            catch(NoSuchElementException)
            {
                protectionPlan = false;
            }

            if(protectionPlan)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                IWebElement decline = driver.FindElement(By.XPath("//*[@id='attachSiNoCoverage']"));
                decline.Click();
            }
        }
    }
}
