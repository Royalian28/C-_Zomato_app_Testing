/// change YOUR_PROFILE_NAME to ur existed profile name in your account for.eg: arun2211
/// change NAME_TO_BE_CHANGED to ur Nme to be updated for.eg: arun prabhu

using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;


namespace Test
{
    [TestFixture]
    [Order(2)]
    public class ZomatoProfileUpdate : BaseSetup
    {
        [Test, Order(2)]
        public void UpdateProfileDetails()
        {  
             if (driver == null)
            {
                Assert.Fail("Driver is not initialized!");
                return;
            }
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            try
            {
                bool homeActivityLoaded = wait.Until(d => 
                    ((AndroidDriver)d).CurrentActivity.Contains("com.library.zomato.home.tabbed.home.HomeActivityV2")
                );

                // Navigate to Profile Section
                var profileIcon = driver.FindElement(By.Id("com.application.zomato:id/profile_text_icon"));
                profileIcon.Click();

                //click the edit profile
                var editProfile = driver.FindElement(By.Id("com.application.zomato:id/search_edit_text_container"));
                editProfile.Click();

                // check for the ProfileForm activity
                // bool formActivityLoaded = wait.Until(d => 
                //     ((AndroidDriver)d).CurrentActivity.Contains("com.application.zomato.language.sideProfile.genericFormV2.GenericFormActivityV2")
                // );

                // SELECT THE NAME FIELD
                var nameField = driver.FindElement(By.XPath("//android.widget.EditText[@text='YOUR_PROFILE_NAME']"));
                nameField.Clear();
                nameField.SendKeys("NAME_TO_BE_CHANGED");


                /// change DOB
                // var dobField = driver.FindElement(By.XPath("//android.widget.EditText[@text='21/03/2009']"));
                // dobField.Click();

                // var yearPicker = driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='android:id/date_picker_header_year']"));
                // yearPicker.Click();

                // // Scroll to the year 2002
                // var yearList = driver.FindElement(By.XPath("//android.widget.ListView"));
                // ((AndroidDriver)driver).ExecuteScript("mobile: scroll", new Dictionary<string, string> { { "element", yearList.GetAttribute("resource-id") }, { "toVisible", "2002" } });

                // var selectYear = driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='android:id/text1' and @text='2002']"));
                // selectYear.Click();

                // var dateHeader = driver.FindElement(By.XPath("//android.widget.TextView[@resource-id='android:id/date_picker_header_date']"));
                // dateHeader.Click();

                // var selectDate = driver.FindElement(By.XPath("//android.view.View[@content-desc='03 November 2002']"));
                // selectDate.Click();

                // var confirmDate = driver.FindElement(By.XPath("//android.widget.Button[@resource-id='android:id/button1']"));
                // confirmDate.Click();
    
                // Update Gender
                var genderDropdown = driver.FindElement(By.XPath("//android.widget.Spinner[@resource-id='com.application.zomato:id/dropdown']"));
                genderDropdown.Click();

                var genderOptions = driver.FindElements(By.ClassName("android.widget.TextView"));
                genderOptions[1].Click(); // Selects the second item, assuming Male is first.


                // Save Changes
                var saveButton = driver.FindElement(By.XPath("//android.widget.Button[@resource-id='com.application.zomato:id/buttonFromButtonLoader']"));
                saveButton.Click();

                Console.WriteLine("Profile updated successfully!");

                var back = driver.FindElement(By.Id("com.application.zomato:id/toolbarArrowBack"));
                back.Click();

                var back1 = driver.FindElement(By.Id("com.application.zomato:id/toolbarArrowBack"));
                back1.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected error: {ex.Message}");
            }
        }
    }
}
