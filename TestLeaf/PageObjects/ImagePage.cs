using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace TestLeaf.PageObjects
{
    class ImagePage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/Image.html";

        public ImagePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//img[@src='../images/home.png']")]
        [CacheLookup]
        public IWebElement HomeImage { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@src='../images/abcd.jpg']")]
        [CacheLookup]
        public IWebElement BrokenImage { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@src='../images/keyboard.png']")]
        [CacheLookup]
        public IWebElement KeyBoardImage { get; set; }

        public void ClickHomeImage()
        {
            HomeImage.Click();
        }

        public bool IsBroken()
        {
            string imegaSrc = BrokenImage.GetAttribute("src");
            return Methods.Methods.VerifyBrokenLink(imegaSrc);
        }

        public void ClickUsingKeyboard()
        {
            Actions act = new Actions(_driver);
            act.Click(KeyBoardImage).Build().Perform();
        }
    }
}
