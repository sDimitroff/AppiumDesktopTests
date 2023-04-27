using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Service;

namespace AppiumTest
{
    public class CalculatorTest
    {
        private const string appiumServer = "http://127.0.0.1:4723";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions appiumOptions;
        private const string appLocation = @"C:\Users\UserPC\Desktop\softuni QA\Front End QA\04.Appium-Desktop-Testing-Resources\SummatorDesktopApp.exe";
       // private AppiumLocalService appiumLocalService;
        [SetUp]
        public void Setup()
        {

            //start appium using the Desktop Appium Server
            this.appiumOptions = new AppiumOptions() {  PlatformName = "Windows"};
            appiumOptions.AddAdditionalCapability("app", appLocation);
            appiumOptions.AddAdditionalCapability("PlatformName", "Windows");
            this.driver = new WindowsDriver<WindowsElement> (new Uri(appiumServer), appiumOptions);
            Thread.Sleep(3000);

            //Start appium using node js headless mode
            //this.appiumLocalService = new AppiumServiceBuilder().UsingAnyFreePort().Build();
            //appiumLocalService.Start();
           //this.appiumOptions = new AppiumOptions();
           //appiumOptions.AddAdditionalCapability("app", appLocation);
           //appiumOptions.AddAdditionalCapability("PlatformName", "Windows");
           //this.driver = new WindowsDriver<WindowsElement>(appiumLocalService, appiumOptions);

        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }


        [TestCase("5", "15", "20")]
        [TestCase("5", "10", "15")]
        [TestCase("5", "12", "17")]
        public void Test1(string firstValue, string secondValue, string result)
        {


            var firstField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");

            firstField.Clear();
            secondField.Clear();
            firstField.SendKeys(firstValue);
            secondField.SendKeys(secondValue);
            calcButton.Click();
            
            
            Assert.That(resultField.Text, Is.EqualTo(result));
        }
    }
}




