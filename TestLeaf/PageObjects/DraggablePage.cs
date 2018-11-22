using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System.Drawing;
using System.Threading;

namespace TestLeaf.PageObjects
{
    class DraggablePage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/drag.html";

        public DraggablePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "draggable")]
        [CacheLookup]
        public IWebElement DraggableBox { get; set; }

        [FindsBy(How = How.Id, Using = "mydiv")]
        [CacheLookup]
        public IWebElement ContainerDiv { get; set; }

        public void MoveToStartPosition()
        {
            var action = new Actions(_driver);

            int widthOfDraggable = DraggableBox.Size.Width;
            int heightOfDraggable = DraggableBox.Size.Height;

            action.ClickAndHold(DraggableBox).MoveToElement(ContainerDiv, widthOfDraggable/2, heightOfDraggable/2).Build().Perform() ;
        }

        public void DragAround()
        {
            var action = new Actions(_driver);
            action.DragAndDropToOffset(DraggableBox, 100, 200).Perform();
        }

        public void DragAroundToTheContainerCorner()
        {
            var firstAction = new Actions(_driver);
            var secondAction = new Actions(_driver);

            int widthOfContainer = ContainerDiv.Size.Width;
            int widthOfDraggable = DraggableBox.Size.Width;

            firstAction.ClickAndHold(DraggableBox).MoveByOffset((widthOfContainer - widthOfDraggable), 0).Release().Build().Perform();
        }
    }
}
