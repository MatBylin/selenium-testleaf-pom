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
        }

        [Test, Order(2)]
        public void SelectDropdownByText()
        {
            DropDownPage.SelectByText();
        }

        [Test, Order(3)]
        public void SelectDropdownByValue()
        {
            DropDownPage.SelectByValue();
        }

        [Test, Order(4)]
        public void GetNumberOfOptions()
        {
            Console.WriteLine(DropDownPage.NumberOfOptions());
        }

        [Test, Order(5)]
        public void SelectDropdownBySendKeys()
        {
            DropDownPage.SelectBySendKeys();
        }

        [Test, Order(6)]
        public void SelectMultiDropdown()
        {
            DropDownPage.SelectMultiDrop();
            Thread.Sleep(500);
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}