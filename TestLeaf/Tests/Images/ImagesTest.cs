using NUnit.Framework;
using System;
using System.Threading;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.Images
{
    class ImagesTest : BaseClass
    {
        public ImagePage ImagesPage { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Firefox);
            driver.Navigate().GoToUrl(ImagePage.BaseUrl);
            Methods.Methods.ImplicitWaitForSeconds(driver, 5);

            ImagesPage = new ImagePage(driver);
        }

        [Test, Order(1)]
        public void ClickHomePageImage()
        {
            ImagesPage.ClickHomeImage();

            Assert.True(driver.Title == "TestLeaf - Selenium Playground");

            driver.Navigate().Back();
        }

        [Test, Order(2)]
        public void VerifyBrokenImage()
        {
            if (ImagesPage.IsBroken())
                Console.WriteLine("Image is broken");
            else
                Console.WriteLine("Image is not broken");
        }

        [Test, Order(3)]
        public void ClickKeyboardImage()
        {
            ImagesPage.ClickUsingKeyboard();

            driver.Navigate().Back();
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
