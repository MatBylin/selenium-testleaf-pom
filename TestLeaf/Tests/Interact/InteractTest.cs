using NUnit.Framework;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.Interact
{
    class InteractTest : BaseClass
    {
        public InteractPage InteractPage { get; set; }

        [SetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Firefox);
            driver.Navigate().GoToUrl(InteractPage.BaseUrl);

            InteractPage = new InteractPage(driver);
        }

        [Test]
        public void MouseOverTextBox()
        {
            InteractPage.SetMouseOver();
        }

        [TearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
