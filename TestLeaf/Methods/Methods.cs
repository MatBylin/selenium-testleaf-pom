using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace TestLeaf.Methods
{
    class Methods
    {
        public static void ImplicitWaitForSeconds(IWebDriver driver, int seconds)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public static bool VerifyBrokenLink(string link)
        {
            HttpWebRequest re = null;
            re = (HttpWebRequest)WebRequest.Create(link);
            bool isBroken;
            try
            {
                var response = (HttpWebResponse)re.GetResponse();
                isBroken = false;
            }
            catch (WebException e)
            {
                var errorResponse = (HttpWebResponse)e.Response;
                isBroken = true;
            }
            return isBroken;
        }

        public static void ReadTable(IWebElement table)
        {
            var columns = table.FindElements(By.TagName("th"));
            var rows = table.FindElements(By.TagName("tr"));
            int rowIndex = 0;

            foreach (var row in rows)
            {
                int colIndex = 0;
                var colDatas = row.FindElements(By.TagName("td"));

                foreach (var colValue in colDatas)
                {
                    _tableData.Add(new TableDataCollection
                    {
                        RowNumber = rowIndex,
                        ColumnName = columns[colIndex].Text,
                        ColumnValue = colValue.Text,
                        Cell = colValue
                    });
                    colIndex++;
                }
                rowIndex++;
            }
        }

        public static string ReadCellData(string columnName, int rowNumber)
        {
            var data = (from e in _tableData
                        where e.ColumnName == columnName && e.RowNumber == rowNumber
                        select e.ColumnValue).SingleOrDefault();

            return data;
        }

        public static IWebElement ReadCellToIWebElement(string columnName, int rowNumber)
        {
            var data = (from e in _tableData
                        where e.ColumnName == columnName && e.RowNumber == rowNumber
                        select e.Cell).SingleOrDefault();

            return data;
        }

        static List<TableDataCollection> _tableData = new List<TableDataCollection>();
    }

    class TableDataCollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        public IWebElement Cell { get; set; }
    }
}
