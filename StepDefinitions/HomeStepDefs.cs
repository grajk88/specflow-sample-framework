using MailTravelProjectThree.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow.Assist;

namespace MailTravelProjectThree.StepDefinitions
{
    [Binding]
    public sealed class HomeStepDefs
    {
        private IWebDriver _driver;

        public HomeStepDefs(IWebDriver driver)
        {
            _driver = driver;
        }

        HomePage homePage => new HomePage(_driver);

        [Given(@"I am in the home page of the MailTravel application")]
        public void GivenIAmInTheHomePageOfTheMailTravelApplication()
        {
            homePage.CheckTitle();
        }

        [Given(@"I search ""([^""]*)"" for destination")]
        public void GivenISearchForDestination(string destination)
        {
            homePage.EnterSearchDestination(destination);   
        }

        [Given(@"I select ""([^""]*)"" tour package")]
        public void GivenISelectTourPackage(string p0)
        {
            homePage.SelectTourPackage(p0);
        }

        [Given(@"I search for below places")]
        public void GivenISearchForBelowDestinations(Table table)
        {
            dynamic datas = table.CreateDynamicSet();

            foreach (var item in datas)
            {
                Console.WriteLine($"The destination is : {item.Destination} and the package name is {item.PackageName}");
            }
                        
        }

        [Given(@"I enter below values")]
        public void GivenIEnterBelowValues(Table table)
        {
            dynamic data = table.CreateDynamicSet();
            foreach (var item in data)
            {
                Console.WriteLine($"{item.Numbers}");
            }
        }

        [Given(@"I am in the ASOS search page")]
        public void GivenIAmInTheASOSSearchPage()
        {
           IList<IWebElement> elements =  _driver.FindElements(By.CssSelector("[data-auto-id*='productTileDescription']"));

            for (int i = 0; i < elements.Count; i++)
            {
                Console.WriteLine(elements[i].FindElement(By.TagName("h2")).Text);
            }
            
        }



    }
}