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
