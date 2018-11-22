using NUnit.Framework;
using System;
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

            ImagesPage = new ImagePage(driver);
        }

        [Test]
        public void ClickHomePageImage()
        {
            ImagesPage.ClickHomeImage();
            driver.Navigate().Back();
            Methods.Methods.ImplicitWaitForSeconds(driver, 3);
        }

        [Test]
        public void VerifyBrokenImage()
        {
            if (ImagesPage.IsBroken())
                Console.WriteLine("Image is broken");
            else
                Console.WriteLine("Image is not broken");
        }

        [Test]
        public void ClickKeyboardImage()
        {
            ImagesPage.ClickUsingKeyboard();
            driver.Navigate().Back();
            Methods.Methods.ImplicitWaitForSeconds(driver, 3);
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}