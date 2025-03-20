///Update the HOTEL_NAME  to fetch the correct hotel name

using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    [Order(3)]
    public class ZomatoFoodOrder : BaseSetup
    {
        [Test]
        public void FoodOrder()
        {
            if (driver == null)
            {
                Assert.Fail("Driver is not initialized!");
                return;
            }
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            try
            {

                // var loc = wait.Until(d=> d.FindElement(By.XPath("//android.widget.LinearLayout[@resource-id='com.application.zomato:id/location_inner_container']")));
                // loc.Click();

                // var location = wait.Until(d=> d.FindElement(By.XPath("(//android.view.ViewGroup[@resource-id='com.application.zomato:id/parent'])[1]")));
                // loc.Click();

                // var Sflip = wait.Until(d=> d.FindElement(By.XPath("//android.widget.ViewFlipper[@resource-id='com.application.zomato:id/search_bar_view_flipper']/android.widget.TextView")));
                // Sflip.Click();
                
                var searcField = wait.Until(d => d.FindElement(By.XPath("//android.widget.EditText[@resource-id='com.application.zomato:id/edittext']")));
                searcField.Click();

                // ✅ Fetch Search Bar and Enter "Hotel Aryaas Grand"
                var searchField = wait.Until(d => d.FindElement(By.XPath("//android.widget.EditText[@resource-id='com.application.zomato:id/edittext']")));
                searchField.Click();
                searchField.SendKeys("HOTEL_NAME");

                // ✅ Click the first search result
                var firstRestaurant = wait.Until(d => d.FindElement(By.XPath("(//android.view.ViewGroup[@resource-id='com.application.zomato:id/root'])[1]")));
                firstRestaurant.Click();

                // ✅ Wait for Restaurant Menu Page
                WaitForActivity("com.library.zomato.ordering.newRestaurant.view.ResMenuCartActivityV2");

                // 🍛 Select "Ghee Pongal"
                var gheePongal = wait.Until(d => d.FindElement(By.XPath("//android.view.View[@content-desc='Meal']")));
                gheePongal.Click();

                // ➕ Add Item to Cart
                var addItemButton = wait.Until(d => d.FindElement(By.XPath("//android.widget.Button[@resource-id='com.application.zomato:id/button']")));
                addItemButton.Click();

                // 🛒 Go to Cart
                var cartButton = wait.Until(d => d.FindElement(By.XPath("//android.widget.LinearLayout[@resource-id='com.application.zomato:id/bt_menu']")));
                cartButton.Click();

                Thread.Sleep(4000);
                // 💳 Select Payment Method
                var paymentSection = wait.Until(d => d.FindElement(By.XPath("(//android.view.ViewGroup[@resource-id='com.application.zomato:id/container_data'])[2]")));
                paymentSection.Click();

                Thread.Sleep(2000);
                // 💰 Select Google Pay UPI
                var gpayOption = wait.Until(d => d.FindElement(By.XPath("//android.view.ViewGroup[@content-desc='Google Pay UPI']")));
                gpayOption.Click();

                Console.WriteLine("✅ Food order placed successfully!");
            }
            catch (Exception ex)
            {
                Assert.Fail($"❌ Unexpected error: {ex.Message}");
            }
        }

        // 🕒 Wait for Specific Activity to Load
        public void WaitForActivity(string activityName, int timeoutInSeconds = 15)
        {
            if (driver == null)
            {
                throw new NullReferenceException("Driver is not initialized!");
            }

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => ((AndroidDriver)d).CurrentActivity.Contains(activityName));
            Console.WriteLine($"📍 Activity Loaded: {activityName}");
        }
    }
}
