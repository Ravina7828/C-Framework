using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace demo.Generic
{
    public class Utilities
    {
		public static IWebDriver driver;

        [Obsolete]
        public static IWebElement WaitForElement(IWebElement el)
		{
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
			IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible((By)el));
			Assert.True(element.Displayed);
			return element;
		}


        public static void VerifyTitle(String el)
        {
            String title = driver.Title;
			Assert.AreEqual(title, el);
		}

        [Obsolete]
        public static void Click(IWebElement el)
        {
            WaitForElement(el).Click();
		}

        [Obsolete]
        public static void TypeText(IWebElement el, String text)
		{
			WaitForElement(el).SendKeys(text);
        }


		public static void MoveToElemet(IWebElement el)
		{
			Actions ac = new Actions(driver);
			ac.MoveToElement(el).Perform();
		}

		public static void Scroll(int x, int y)
		{
			IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
			js.ExecuteScript("window.scrollBy(" + x + "," + y + ")");
		}
		public static void DropDown(IWebElement ele, String text)
		{
			SelectElement s = new SelectElement(ele);
			s.SelectByText(text);
		}

		//Actions Class Methods -->>
		public static void MouseHover(IWebElement ele)
		{
			Actions a = new Actions(driver);
			a.MoveToElement(ele).Perform();
		}
		public static void DoubleClick(IWebElement ele)
		{
			Actions a = new Actions(driver);
			a.DoubleClick(ele).Perform();
		}
		public static void RightClick(IWebElement ele)
		{
			Actions a = new Actions(driver);
			a.ContextClick(ele).Perform();
		}

		//Switching one frame to another
		public static void SwitchToframe()
		{
			driver.SwitchTo().Frame(0);

		}
		//to accept alert methods
		public static void AlertAccept()
		{
			driver.SwitchTo().Alert().Accept();
		}
		//to dismiss alert methods
		public static void AlertDismiss()
		{
			driver.SwitchTo().Alert().Dismiss();
		}
		//Navigate methods
		public static void NavBack()
		{
			driver.Navigate().Back();
		}
		public static void NavForword()
		{
			driver.Navigate().Forward();
		}
		public static void NavRefresh()
		{
			driver.Navigate().Refresh();
		}


	}
}
