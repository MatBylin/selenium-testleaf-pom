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
        }

        [Test, Order(2)]
        public void WhitchIsDefaultRadio()
        {
            Console.WriteLine("The one with value: " + RadioButtonPage.WhitchIsDefault());
        }

        [Test, Order(3)]
        public void SelectYourAgeRadio()
        {
            RadioButtonPage.SelectYourAgeGroup();
            Thread.Sleep(500);
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}