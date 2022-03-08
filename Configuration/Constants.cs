using System;
using OpenQA.Selenium;

namespace demo.Configuration
{
    public class Constants
    {
        public string propertryFilePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Projects/demo/demo/Data.properties";
        public string extentPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Projects/demo/demo/Reports/Report.html";
    }
}

//    /Users/apple
///Users/apple/Projects/demo/demo/Reports
///Users/apple/Projects/demo/demo/Data.properties
///Users/apple/Projects/demo/demo/Reports/ExtentReport.html