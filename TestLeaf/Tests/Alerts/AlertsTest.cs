using NUnit.Framework;
using System;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.Alerts
{
    class AlertsTest : BaseClass
    {
        public AlertPage AlertPage { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Firefox);
            driver.Navigate().GoToUrl(AlertPage.BaseUrl);
            Methods.Methods.ImplicitWaitForSeconds(driver, 2);

            AlertPage = new AlertPage(driver);
        }

        [Test]
        public void DisplayAlertBox()
        {
            AlertPage.DisplayAlertBox();

            Assert.True(driver.Title == "TestLeaf - Interact with Alerts");
        }

        [Test]
        public void DisplayAndConfirmAlertBox()
        {
            AlertPage.DisplayAndConfirmAlertBox();

            Assert.True(driver.Title == "TestLeaf - Interact with Alerts");
        }

        [Test]
        public void DisplayAndPromptAlertBox()
        {
            AlertPage.PromptAlertBox();

            Assert.True(driver.Title == "TestLeaf - Interact with Alerts");
        }

        [Test]
        public void IsLineBreaksAlertBox()
        {
            Console.WriteLine(AlertPage.LineBreaksAlertBox());

            Assert.True(driver.Title == "TestLeaf - Interact with Alerts");
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
