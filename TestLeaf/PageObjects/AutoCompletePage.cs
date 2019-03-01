using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestLeaf.PageObjects
{
    class AutoCompletePage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/autoComplete.html";

        public AutoCompletePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "tags")]
        [CacheLookup]
        public IWebElement AutoCompleteInput { get; set; }

        public int ChooseFromAutoList()
        {
            AutoCompleteInput.SendKeys("A");
            Methods.Methods.ImplicitWaitForSeconds(_driver, 3);
            IList<IWebElement> listOfOptions = _driver.FindElements(By.XPath("//*[@id='ui-id-1']/li/div"));
            if(listOfOptions.Count != 0)
                listOfOptions[0].Click();
            return listOfOptions.Count;
        }
    }
}
