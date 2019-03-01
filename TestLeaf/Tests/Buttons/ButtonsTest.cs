using NUnit.Framework;
using System;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.Buttons
{
    class ButtonsTest : BaseClass
    {
        public ButtonPage ButtonPage { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Firefox);
            driver.Navigate().GoToUrl(ButtonPage.BaseUrl);
            Methods.Methods.ImplicitWaitForSeconds(driver, 3);

            ButtonPage = new ButtonPage(driver);
        }

        [Test]
        public void ClickButtonHomePage()
        {
            ButtonPage.ClickHomePage();
            driver.Navigate().Back();

            Assert.That(driver.Title == "TestLeaf - Interact with Buttons");
        }

        [Test]
        public void GetButtonPosition()
        {
            int[] pos = ButtonPage.GetPosition();
            Console.WriteLine("X postion is {0}, Y position is {1}", pos[0], pos[1]);

            Assert.That(pos[0] > 0);
            Assert.That(pos[1] > 0);
        }

        [Test]
        public void GetButtonColor()
        {
            var buttonColor = ButtonPage.GetColor();

            Assert.That(buttonColor, Is.EqualTo("rgb(144, 238, 144)"));
        }

        [Test]
        public void GetButtonSize()
        {
            int[] pos = ButtonPage.GetSize();
            Console.WriteLine("Width is {0}, Height is {1}", pos[0], pos[1]);

            Assert.That(pos[0] > 0);
            Assert.That(pos[1] > 0);
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
