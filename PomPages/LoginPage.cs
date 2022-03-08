using demo.Generic;
using demo.locators;
using OpenQA.Selenium;
namespace demo.PomPages
{
    public class LoginPage: HomePage
    {
        public IWebDriver driver;
        public HomePage home;

        [System.Obsolete]
        public LoginPage(IWebDriver driver) 
        {
            home = new HomePage(driver);

        }

        [System.Obsolete]
        public void LoginClick()
        {
            //Utilities.AlertDismiss();
            Utilities.Click(Login);
            //home.Login.Click();
        }
        }
}
