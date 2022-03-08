using System;
using demo.Configuration;
using demo.PomPages;
using NUnit.Framework;
using SeleniumTest;

namespace demo.TestCases
{
    public class Test_01 : BaseTest
    {
        [Test]
        [Obsolete]
        public void LoginTest()
        {
            extentTest = extent.CreateTest("Test_01").Info("Test Started");
            LoginPage login = new LoginPage(driver);
            login.LoginClick();
        }
    }
}
