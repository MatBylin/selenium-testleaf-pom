using NUnit.Framework;
using System;
using System.Threading;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.Dropdowns
{
    class DropdownsTest : BaseClass
    {
        public DropDownPage DropDownPage { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Firefox);
            driver.Navigate().GoToUrl(DropDownPage.BaseUrl);

            DropDownPage = new DropDownPage(driver);
        }

        [Test, Order(1)]
        public void SelectDropdownByIndex()
        {
            DropDownPage.SelectByIndex();

            Assert.True(DropDownPage.IndexDropdown.GetAttribute("value") == "2");
        }

        [Test, Order(2)]
        public void SelectDropdownByText()
        {
            DropDownPage.SelectByText();

            Assert.True(DropDownPage.TextDropdown.GetAttribute("value") == "1");
        }

        [Test, Order(3)]
        public void SelectDropdownByValue()
        {
            DropDownPage.SelectByValue();

            Assert.True(DropDownPage.ValueDropdown.GetAttribute("value") == "2");
        }

        [Test, Order(4)]
        public void GetNumberOfOptions()
        {
            Console.WriteLine(DropDownPage.NumberOfOptions());

            Assert.True(DropDownPage.NumberOfOptions() == 5);
        }

        [Test, Order(5)]
        public void SelectDropdownBySendKeys()
        {
            DropDownPage.SelectBySendKeys();

            Assert.True(DropDownPage.SendKeysDropdown.GetAttribute("value") == "1");
        }

        [Test, Order(6)]
        public void SelectMultiDropdown()
        {
            DropDownPage.SelectMultiDrop();

            Assert.True(DropDownPage.MultiDropdownOption.Selected);
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
