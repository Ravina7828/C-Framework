using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using demo.Configuration;

namespace SeleniumTest
{
    public class BaseTest
    {
        public IWebDriver driver;
        public ExtentReports extent = null;
        public static ExtentTest extentTest;
        public Constants cons = new Constants();
        public static object OutputType { get; private set; }

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            //var dir = TestContext.CurrentContext.TestDirectory + "\\";
            //string fileName = this.GetType().ToString() + "Report.html";
            //var htmlReporter = new ExtentHtmlReporter(dir + fileName);
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(cons.extentPath);
            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
            new WebDriverManager.DriverManager().SetUpDriver(new WebDriverManager.DriverConfigs.Impl.ChromeConfig());
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("https://www.icicibank.com/");
        }

        [TearDown]
        public void CaptureScreenshot()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<prev>" + TestContext.CurrentContext.Result.StackTrace + "</prev>";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            if (status == TestStatus.Failed)
            {
                string screenshot = BaseTest.Capture(driver, "ScreenShotName");
                extentTest.Log(Status.Fail, errorMessage);
                extentTest.Log(Status.Fail, "Snapshot :" + extentTest.AddScreenCaptureFromPath(screenshot));

            }

        }
        public static string Capture(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalPath = pth.Substring(0, pth.LastIndexOf("bin")) + "Reports/" + "screenShotName" + ".png";
            string localPath = new Uri(finalPath).LocalPath;
            screenshot.SaveAsFile(localPath);
            return localPath;
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            extent.Flush();
        }

    }
}
