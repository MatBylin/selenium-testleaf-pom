using NUnit.Framework;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.Upload
{
    class UploadTest : BaseClass
    {
        public UploadPage UploadPage { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Firefox);
            driver.Navigate().GoToUrl(UploadPage.BaseUrl);

            UploadPage = new UploadPage(driver);
        }

        [Test]
        public void UploadFile()
        {
            //The path to file must exist
            string path = "F:\\upload\\file.txt";

            UploadPage.Upload(path);
            //Thread.Sleep(1000);
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
