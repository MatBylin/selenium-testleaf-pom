using NUnit.Framework;
using System;
using System.Threading;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.RadioButtons
{
    class RadioButtonsTest : BaseClass
    {
        public RadioButtonPage RadioButtonPage { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Firefox);
            driver.Navigate().GoToUrl(RadioButtonPage.BaseUrl);

            RadioButtonPage = new RadioButtonPage(driver);
        }

        [Test, Order(1)]
        public void AreYouEnjoying()
        {
            RadioButtonPage.EnjoyClasses();

            Assert.True(RadioButtonPage.EnjoyYesRadioButton.Selected);
        }

        [Test, Order(2)]
        public void WhitchIsDefaultRadio()
        {
            Console.WriteLine("The one with value: " + RadioButtonPage.WhitchIsDefault());

            Assert.True(RadioButtonPage.DefaultButtons[1].Selected);
        }

        [Test, Order(3)]
        public void SelectYourAgeRadio()
        {
            RadioButtonPage.SelectYourAgeGroup();

            Assert.True(RadioButtonPage.AgeButtons[1].Selected);
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
