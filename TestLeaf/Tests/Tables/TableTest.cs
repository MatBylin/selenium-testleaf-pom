using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.Tables
{
    class TableTest : BaseClass
    {
        public TablePage TablePage { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Firefox);
            driver.Navigate().GoToUrl(TablePage.BaseUrl);
            TablePage = new TablePage(driver);
        }

        [Test, Order(1)]
        public void HowManyColumns()
        {
            Console.WriteLine(TablePage.ColumnsCount());
        }

        [Test, Order(2)]
        public void HowManyRows()
        {
            Console.WriteLine(TablePage.RowsCount());
        }

        [Test, Order(3)]
        public void GetTheValueOfProgressInteract()
        {
            Console.WriteLine(TablePage.GetTheValueOfTableIndex("Progress", 2));
        }

        [Test, Order(4)]
        public void CheckVitalTakForLeastCompleted()
        {
            IWebElement cell = TablePage.GetTheCellAsIWebElement("Vital Task", 3);
            Methods.Methods.ImplicitWaitForSeconds(driver, 3);
            cell.Click();
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}