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

            LinksPage = new LinkPage(driver);
        }

        [Test]
        public void ClickFirstHomePage()
        {
            LinksPage.ClickFirstHomePage();
            driver.Navigate().Back();
            Methods.Methods.ImplicitWaitForSeconds(driver, 3);
        }

        [Test]
        public void WhereToRedirect()
        {
            Console.WriteLine(LinksPage.WhereRedirect());
        }

        [Test]
        public void VerifyBrokenButton()
        {
            bool isBroken = LinksPage.VerifyBroken();
            Console.WriteLine(isBroken);
        }

        [Test]
        public void ClickSecondHomePage()
        {
            LinksPage.ClickSecondHomePage();
            driver.Navigate().Back();
            Methods.Methods.ImplicitWaitForSeconds(driver, 3);
        }

        [Test]
        public void HowManyLinks()
        {
            Console.WriteLine(LinksPage.HowManyLinks());
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}