using NUnit.Framework;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.Draggable
{
    class DraggableTest : BaseClass
    {
        public DraggablePage DraggablePage { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Firefox);
            driver.Navigate().GoToUrl(DraggablePage.BaseUrl);

            DraggablePage = new DraggablePage(driver);
        }

        [Test, Order(1)]
        public void DragMeAroundByOffset()
        {
            DraggablePage.DragAround();
            DraggablePage.MoveToStartPosition();
        }

        [Test, Order(2)]
        public void DragMeAroundToTheRightMostCorner()
        {
            DraggablePage.DragAroundToTheContainerCorner();
            DraggablePage.MoveToStartPosition();
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}