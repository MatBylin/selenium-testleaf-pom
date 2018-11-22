using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestLeaf.PageObjects
{
    class ButtonPage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/Button.html";

        public ButtonPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "home")]
        [CacheLookup]
        public IWebElement HomeButton { get; set; }

        [FindsBy(How = How.Id, Using = "position")]
        [CacheLookup]
        public IWebElement PositionButton { get; set; }

        [FindsBy(How = How.Id, Using = "color")]
        [CacheLookup]
        public IWebElement ColorButton { get; set; }

        [FindsBy(How = How.Id, Using = "size")]
        [CacheLookup]
        public IWebElement SizeButton { get; set; }

        public void ClickHomePage()
        {
            HomeButton.Click();
        }

        public int[] GetPosition()
        {
            int[] positionArray = new int[2];
            positionArray[0] = PositionButton.Location.X;
            positionArray[1] = PositionButton.Location.Y;
            return positionArray;
        }

        public string GetColor()
        {
            return ColorButton.GetCssValue("background-color");
        }

        public int[] GetSize()
        {
            int[] sizeArray = new int[2];
            sizeArray[0] = SizeButton.Size.Width;
            sizeArray[1] = SizeButton.Size.Height;
            return sizeArray;
        }
    }
}
