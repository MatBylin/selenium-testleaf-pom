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

            AlertPage = new AlertPage(driver);
        }

        [Test]
        public void DisplayAlertBox()
        {
            AlertPage.DisplayAlertBox();
            Methods.Methods.ImplicitWaitForSeconds(driver, 2);
            Assert.AreEqual(driver.Title, "TestLeaf - Interact with Alerts");
        }

        [Test]
        public void DisplayAndConfirmAlertBox()
        {
            AlertPage.DisplayAndConfirmAlertBox();
            Methods.Methods.ImplicitWaitForSeconds(driver, 2);
            Assert.AreEqual(driver.Title, "TestLeaf - Interact with Alerts");
        }

        [Test]
        public void DisplayAndPromptAlertBox()
        {
            AlertPage.PromptAlertBox();
            Methods.Methods.ImplicitWaitForSeconds(driver, 2);
            Assert.AreEqual(driver.Title, "TestLeaf - Interact with Alerts");
        }

        [Test]
        public void IsLineBreaksAlertBox()
        {
            Console.WriteLine(AlertPage.LineBreaksAlertBox());
            Methods.Methods.ImplicitWaitForSeconds(driver, 2);
            Assert.AreEqual(driver.Title, "TestLeaf - Interact with Alerts");
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}