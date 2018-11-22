using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestLeaf.PageObjects
{
    class CalendarPage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/Calendar.html";

        public CalendarPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "datepicker")]
        [CacheLookup]
        public IWebElement CalendarTextBox { get; set; }

        public void SearchForDay(string setDay)
        {
            CalendarTextBox.Click();
            Methods.Methods.ImplicitWaitForSeconds(_driver, 2);

            IList<IWebElement> listOfDays = _driver.FindElements(By.ClassName("ui-state-default"));

            foreach (var day in listOfDays)
            {
                if (day.Text == setDay)
                    day.Click();
            }
        }

    }
}
