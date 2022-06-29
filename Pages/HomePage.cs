using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailTravelProjectThree.Pages
{
    class HomePage
    {
        private IWebDriver _driver;
        BaseClass baseClass => new BaseClass(_driver);

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        By txtSearchDestination = By.Id("searchtext_freetext_search_form");
        By listDestinationResults = By.Id("as_ul");

        public void CheckTitle() {
            try
            {
                var title = _driver.Title.ToString();
                Assert.True(title== "Home Page | Mail Travel");
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());     
            }
        }

        public void EnterSearchDestination(string searchDestination) {
            try
            {
                IWebElement _txtSearchDestination = _driver.FindElement(txtSearchDestination);
            // _txtSearchDestination.SendKeys(searchDestination);
            baseClass.EnterText(_txtSearchDestination, searchDestination);
            }
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }

        public void SelectTourPackage(string tourPackageName) {
            try
            {
                Thread.Sleep(3000);

                IWebElement _listDestinationResults = _driver.FindElement(listDestinationResults);
                var resultsValue= _listDestinationResults.FindElements(By.TagName("bdi"));
                var resultsSize = resultsValue.Count();

                for (int i = 0; i < resultsSize; i++)
                {
                    Console.WriteLine(resultsValue[i].Text);
                    if (resultsValue[i].Text == tourPackageName)
                    {
                        resultsValue[i].Click();
                        break;
                    }
                }
            } 
            catch (Exception e)
            {
                Assert.Fail(e.ToString());
            }
        }

      }
}