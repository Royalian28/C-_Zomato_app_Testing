using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace Test
{
    public class BaseSetup
    {
        protected static AndroidDriver? driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            Console.WriteLine("Starting Appium Driver Initialization...");

            AppiumOptions options = new AppiumOptions();
            options.DeviceName = "FILL_UR_DEVICE_NAME";
            options.PlatformVersion = "14";
            options.AddAdditionalAppiumOption("udid", "FILL_UR_MOBILE_UDID");
            options.AddAdditionalAppiumOption("appPackage", "com.application.zomato");
            options.AddAdditionalAppiumOption("appActivity", ".default"); 
            options.AddAdditionalAppiumOption("autoGrantPermissions", true);
            options.AddAdditionalAppiumOption("platformName", "Android");
            options.AutomationName = "UiAutomator2"; // or "XCUITest" for iOS
            options.AddAdditionalAppiumOption("noReset", true);
            options.AddAdditionalAppiumOption("fullReset", false);
            options.AddAdditionalAppiumOption("appWaitActivity", "*");
            options.AddAdditionalAppiumOption("autoGrantPermissions", true);


            driver = new AndroidDriver(new Uri("http://127.0.0.1:4723/"), options);
            driver.ActivateApp("com.application.zomato");

            Console.WriteLine("Appium Driver Initialized Successfully!");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
                Console.WriteLine("Appium Driver Closed.");
            }
        }
    }
}