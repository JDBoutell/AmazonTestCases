using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using AmazonTestCases.Models;

namespace AmazonTestCases.Tests
{
    public class CartSmokeTest : TestBase
    {
        private string fileLocation = @"C:\";
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
            string item2 = "Metasploit: The Penetration Tester";
            string item3 = "PerfectoStore Meow Meow Meow Halloween Cup";
            string screenShotFile = String.Concat(fileLocation, fileName);

            //Adding items to the cart
            AddItemToCart(item1);
            AddItemToCart(item2);
            AddItemToCart(item3);

            //Taking screenshot after all items have been added to the cart
            Screenshot pic = ((ITakesScreenshot)driver).GetScreenshot();
            pic.SaveAsFile(screenShotFile, ScreenshotImageFormat.Png);

            //Going to the cart to verify the items were added to the cart successfully
            OpenPage(Cart.GetUrl());

            IWebElement product = Cart.GetCartItem(driver, item1);
            Assert.That(product.Displayed, $"The item, {item1}, was not displayed on the cart page.");

            product = Cart.GetCartItem(driver, item2);
            Assert.That(product.Displayed, $"The item, {item2}, was not displayed on the cart page.");

            product = Cart.GetCartItem(driver, item3);
            Assert.That(product.Displayed, $"The item, {item3}, was not displayed on the cart page.");

            //Removing the Monitor

        }

        public void AddItemToCart(string product)
        {
            Header.RunSearch(driver, product);
            //OpenPage(Search.GetUrl(product));
            IWebElement item = Search.GetFirstResult(driver, product);
            item.Click();
            Product.AddToCart(driver);
        }
    }
}
