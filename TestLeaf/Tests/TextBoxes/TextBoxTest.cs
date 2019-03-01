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
        [TestCase("example@example.com")]
        public void EnterEmailAdress(string adress)
        {
            TextBoxPage.EnterEmail(adress);

            Assert.True(TextBoxPage.EmailTextBox.GetAttribute("value") == adress);
        }

        [Test, Order(2)]
        public void AppendText()
        {
            TextBoxPage.AppendText(" append... ");

            Assert.True(TextBoxPage.AppendTextBox.GetAttribute("value").Contains("append"));
        }

        [Test, Order(3)]
        public void GetTheDefaultText()
        {
            string text = TextBoxPage.GetDefaultText();

            Assert.True(text == "TestLeaf");
        }

        [Test, Order(4)]
        public void ClearTextBox()
        {
            TextBoxPage.ClearTextBox.Clear();

            Assert.True(TextBoxPage.ClearTextBox.GetAttribute("value") == "");
        }

        [Test, Order(5)]
        public void ConfirmDisabled()
        {
            bool isDisabled = TextBoxPage.IsTextBoxDisabled();

            Assert.True(isDisabled);
        }

        [OneTimeTearDown]
        public void Quit()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
