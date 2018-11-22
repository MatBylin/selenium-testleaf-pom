using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLeaf.PageObjects
{
    class RadioButtonPage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/radio.html";

        public RadioButtonPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "yes")]
        [CacheLookup]
        public IWebElement EnjoyYesRadioButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='news']")]
        [CacheLookup]
        public IList<IWebElement> DefaultButtons { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='age']")]
        [CacheLookup]
        public IList<IWebElement> AgeButtons { get; set; }

        public void EnjoyClasses()
        {
            EnjoyYesRadioButton.Click();
        }

        public string WhitchIsDefault()
        {
            string text = "";

            foreach (var radio in DefaultButtons)
            {
                if (radio.Selected)
                    text = radio.GetAttribute("value");
                else
                    text = "none is selected";
            }
            return text;
        }

        public void SelectYourAgeGroup()
        {
            foreach (var radio in AgeButtons)
            {
                if (radio.GetAttribute("value") == "1")
                {
                    if (!radio.Selected)
                    {
                        radio.Click();
                    }
                }
            }
        }
    }
}
