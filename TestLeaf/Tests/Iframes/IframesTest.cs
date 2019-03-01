using NUnit.Framework;
using System;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.IFrames
{
    class IframesTest : BaseClass
    {
        public FramesPage FramesPage { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Firefox);
            driver.Navigate().GoToUrl(FramesPage.BaseUrl);

            FramesPage = new FramesPage(driver);
        }

        [Test]
        public void ClickFirstIframeButton()
        {
            FramesPage.ClickFirstIframe();

            Assert.True(FramesPage.FirstIframeButton.Text.Contains("Clicked"));

            driver.SwitchTo().DefaultContent();
        }

        [Test]
        public void ClickNestedIframe()
        {
            FramesPage.ClickNestedIframe();

            Assert.True(FramesPage.NestedIframeButton.Text.Contains("Clicked"));

            driver.SwitchTo().DefaultContent();
        }

        [Test]
        public void IframesCount()
        {
            Console.WriteLine(FramesPage.IframeCount());

            Assert.True(FramesPage.IframeCount() == 3);
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
