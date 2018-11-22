using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace TestLeaf.PageObjects
{
    class DroppablePage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/drop.html";

        public DroppablePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "draggable")]
        [CacheLookup]
        public IWebElement DraggableBox { get; set; }

        [FindsBy(How = How.Id, Using = "droppable")]
        [CacheLookup]
        public IWebElement DroppableBox { get; set; }

        [FindsBy(How = How.Id, Using = "mydiv")]
        [CacheLookup]
        public IWebElement ContainerDiv { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='droppable']/p")]
        [CacheLookup]
        public IWebElement DroppableBoxText { get; set; }

        public void DragElementToDropBox()
        {
            var action = new Actions(_driver);
            action.ClickAndHold(DraggableBox).MoveToElement(DroppableBox, DraggableBox.Size.Width/2, DraggableBox.Size.Height/2).Release().Build().Perform();
        }
    }
}
