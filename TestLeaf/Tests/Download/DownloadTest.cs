using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf.Tests.Download
{
    class DownloadTest : BaseClass
    {
        public DownloadPage DownloadPage { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", "D:\\");
            driver = new ChromeDriver(options);

            DownloadPage = new DownloadPage(driver);
            driver.Navigate().GoToUrl(DownloadPage.BaseUrl);
        }

        [Test]
        public void DownloadFile()
        {
            /* Important thing is to initialize
            * browser with auto-download setting */

            DownloadPage.ClickDownload();
            Task.Delay(5000).Wait(); // wait to download the file
            Assert.True(DownloadPage.CheckDownload());
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}