using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestLeaf.PageObjects
{
    class TablePage
    {
        private IWebDriver _driver;
        public static string BaseUrl { get; set; } = "http://www.leafground.com/pages/table.html";

        public TablePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@class='innerblock']/div/table")]
        [CacheLookup]
        public IWebElement Table { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='innerblock']/div/table/tbody/tr/th")]
        [CacheLookup]
        public IWebElement MainRow { get; set; }

        public int ColumnsCount()
        {
            return Table.FindElements(By.TagName("th")).Count;
        }

        public int RowsCount()
        {
            return Table.FindElements(By.TagName("tr")).Count;
        }

        public string GetTheValueOfTableIndex(string columnName, int rowIndex)
        {
            //Read table
            Methods.Methods.ReadTable(Table);

            //read cell value
            return Methods.Methods.ReadCellData(columnName, rowIndex);
        }

        public IWebElement GetTheCellAsIWebElement(string columnName, int rowIndex)
        {
            //Read table in previous method
            //read cell value
            return Methods.Methods.ReadCellToIWebElement(columnName, rowIndex);
        }
    }
}