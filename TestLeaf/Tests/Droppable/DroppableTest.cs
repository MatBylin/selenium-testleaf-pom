using NUnit.Framework;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.Droppable
{
    class DroppableTest : BaseClass
    {
        public DroppablePage DroppablePage { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Firefox);
            driver.Navigate().GoToUrl(DroppablePage.BaseUrl);

            DroppablePage = new DroppablePage(driver);
        }

        [Test]
        public void DragElementToTarget()
        {
            DroppablePage.DragElementToDropBox();
            Methods.Methods.ImplicitWaitForSeconds(driver, 2);
            Assert.IsTrue(DroppablePage.DroppableBoxText.Text == "Dropped!");
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}