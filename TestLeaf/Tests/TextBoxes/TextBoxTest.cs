using NUnit.Framework;
using TestLeaf.Base;
using TestLeaf.PageObjects;

namespace TestLeaf
{
    [TestFixture]
    public class TextBoxTest : BaseClass
    {
        public TextBoxPage TextBoxPage { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            InitBrowser(BrowserType.Chrome);
            driver.Navigate().GoToUrl(TextBoxPage.BaseUrl);

            TextBoxPage = new TextBoxPage(driver);
        }

        [Test, Order(1)]
        public void EnterEmailAdress()
        {
            TextBoxPage.EnterEmail("example@example.com");
        }

        [Test, Order(2)]
        public void AppendText()
        {
            TextBoxPage.AppendText(" append... ");
        }

        [Test, Order(3)]
        public void GetTheDefaultText()
        {
            string text = TextBoxPage.GetDefaultText();
            System.Console.WriteLine(text);
        }

        [Test, Order(4)]
        public void ClearTextBox()
        {
            TextBoxPage.ClearTextBox.Clear();
        }

        [Test, Order(5)]
        public void ConfirmDisabled()
        {
            bool isDisabled = TextBoxPage.IsTextBoxDisabled();
            Assert.True(isDisabled);
            //Thread.Sleep(3000);
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}