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
            var startPos = DraggablePage.DraggableBox.Location;
            DraggablePage.DragAround();
            var endPosition = DraggablePage.DraggableBox.Location;

            Assert.True(startPos.X == (endPosition.X - 100));

            DraggablePage.MoveToStartPosition();
        }

        [Test, Order(2)]
        public void DragMeAroundToTheRightMostCorner()
        {
            var startPos = DraggablePage.DraggableBox.Location;
            DraggablePage.DragAroundToTheContainerCorner();

            var box = DraggablePage.DraggableBox;
            var container = DraggablePage.ContainerDiv;

            Assert.True(box.Location.X == (startPos.X + container.Size.Width - box.Size.Width));

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
