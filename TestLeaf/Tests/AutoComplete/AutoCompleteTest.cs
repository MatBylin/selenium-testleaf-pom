using NUnit.Framework;
using System;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.AutoComplete
{
    class AutoCompleteTest : BaseClass
    {
        public AutoCompletePage AutoCompletePage { get; set; }

        [SetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Firefox);
            driver.Navigate().GoToUrl(AutoCompletePage.BaseUrl);

            AutoCompletePage = new AutoCompletePage(driver);
        }

        [Test]
        public void AutoCompleteAndClick()
        {
            Console.WriteLine("AutoComplete sublist count is : {0}", AutoCompletePage.ChooseFromAutoList());
        }

        [TearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}