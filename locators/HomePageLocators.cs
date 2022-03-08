using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace demo.locators
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage()
        {
        }

        [Obsolete]
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@id='login - btn']")]
        public IWebElement Login { get; set; }
    }
}
