using NUnit.Framework;
using System;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.Links
{
    class LinksTest : BaseClass
    {
        LinkPage LinksPage;

        [OneTimeSetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Firefox);
            driver.Navigate().GoToUrl(LinkPage.BaseUrl);
            Methods.Methods.ImplicitWaitForSeconds(driver, 3);

            LinksPage = new LinkPage(driver);
        }

        [Test]
        public void ClickFirstHomePage()
        {
            LinksPage.ClickFirstHomePage();
            
            Assert.AreEqual(driver.Title, "TestLeaf - Selenium Playground");

            driver.Navigate().Back();
        }

        [Test]
        public void WhereToRedirect()
        {
            Console.WriteLine(LinksPage.WhereRedirect());

            Assert.True(LinksPage.WhereRedirect() == "http://www.leafground.com/pages/Button.html");
        }

        [Test]
        public void VerifyBrokenButton()
        {
            bool isBroken = LinksPage.VerifyBroken();

            Assert.True(isBroken);
        }

        [Test]
        public void ClickSecondHomePage()
        {
            LinksPage.ClickSecondHomePage();

            Assert.AreEqual(driver.Title, "TestLeaf - Selenium Playground");

            driver.Navigate().Back();
        }

        [Test]
        public void HowManyLinks()
        {
            Console.WriteLine(LinksPage.HowManyLinks());

            Assert.True(LinksPage.HowManyLinks() == 6);
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
