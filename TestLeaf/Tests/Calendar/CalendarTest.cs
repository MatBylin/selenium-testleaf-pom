using NUnit.Framework;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.Calendar
{
    class CalendarTest : BaseClass
    {
        public CalendarPage CalendarPage { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Firefox);
            driver.Navigate().GoToUrl(CalendarPage.BaseUrl);

            CalendarPage = new CalendarPage(driver);
        }

        [Test]
        public void SelectDayOfMonth()
        {
            CalendarPage.SearchForDay("10");
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}