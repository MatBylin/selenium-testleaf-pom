using NUnit.Framework;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.Windows
{
    class WindowsTest : BaseClass
    {
        public WindowPage WindowPage { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Firefox);
            driver.Navigate().GoToUrl(WindowPage.BaseUrl);

            WindowPage = new WindowPage(driver);
        }

        [Test]
        public void ClickHomePage()
        {
            WindowPage.OpenHomePage();
        }

        [Test]
        public void OpenMultipleWindows()
        {
            WindowPage.OpenMultipleWindows();
        }

        [Test]
        public void DoNotCloseTwoNewWindows()
        {
            WindowPage.DoNotCloseTwoNewWindows();
        }

        [Test]
        public void WaitForFiveSeconds()
        {
            WindowPage.WaitForNewWindows(8);
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}