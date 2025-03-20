
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    [Order(1)]
    public class ZomatoLogin : BaseSetup
    {
        [Test]
        public void LoginWithMobileOtp()
        {
            if (driver == null)                             
            {
                Assert.Fail("Driver is not initialized!");
                return;
            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            try
            { 

                Thread.Sleep(5000);
                // Enter mobile number
                // driver.FindElement(By.Id("com.application.zomato:id/fw_mobile_edit_text"))?.Click();   
                // driver.FindElement(By.Id("com.application.zomato:id/fw_mobile_edit_text"))?.SendKeys("8838040929");

                // // Click Send OTP button
                // driver.FindElement(By.Id("com.application.zomato:id/send_otp_button"))?.Click();

                var goog = wait.Until(d=> d.FindElement(By.XPath("//android.widget.LinearLayout[@resource-id='com.application.zomato:id/login_options_container']/android.widget.LinearLayout[1]")));
                goog.Click();

                var acc = wait.Until(d=> d.FindElement(By.XPath("(//android.widget.LinearLayout[@resource-id='com.google.android.gms:id/container'])[7]/android.widget.LinearLayout")));
                acc.Click();
                
                // Wait for Home Activity
                bool homeActivityLoaded = wait.Until(d => 
                    ((AndroidDriver)d).CurrentActivity.Contains("com.library.zomato.home.tabbed.home.HomeActivityV2")
                );

                if (homeActivityLoaded)
                {
                    Console.WriteLine("✅ Home screen loaded successfully!");
                }
                else
                {
                    Assert.Fail("❌ Home screen did not load!");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex.Message}");
            }
        }
    }
}
