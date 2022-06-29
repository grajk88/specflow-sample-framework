using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace MailTravelProjectThree.Utils
{
    [Binding]
    public class Hooks
    {
        public IWebDriver _driver;
        IObjectContainer _iObjectContainer;

        public Hooks(IObjectContainer iObjectContainer)
        {
            _iObjectContainer = iObjectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            try
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                _driver = new ChromeDriver();
                _iObjectContainer.RegisterInstanceAs(_driver);
                _driver.Manage().Window.Maximize();
                _driver.Navigate().GoToUrl("https://www.mailtravel.co.uk/");
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
           
        }

        [AfterScenario]
        public void AfterScenario()
        {
           _driver?.Quit();
           
        }
    }
}