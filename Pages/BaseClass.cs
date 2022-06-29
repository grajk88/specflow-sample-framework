using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTravelProjectThree.Pages
{
   public class BaseClass
    {
        private IWebDriver _driver;

        public BaseClass(IWebDriver driver)
        {
            _driver = driver;
        }

        public void EnterText(IWebElement element, String text) {
            element.SendKeys(text);
        }

        public void CheckTitle(string title) => Assert.True(_driver.Title.Contains(title));
    }
}
