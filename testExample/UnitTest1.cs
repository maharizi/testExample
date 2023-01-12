using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml.Linq;

namespace Guru99Demo
{
    class testExample
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("D:\\drivers\\");
        }

        [Test]
        public void test()
        {

            driver.Url = "https://www.ebay.com/";

            var SearchBar = driver.FindElement(By.Id("gh-ac"));
            SearchBar.SendKeys("mause");

            var clickOption = driver.FindElement(By.Id("gh-btn"));
            clickOption.Click();

            var items = driver.FindElements(By.ClassName("s-item__link"));

            Assert.IsTrue(items.Count > 0);

            for (int i = 1; i < 3; i++)
            {
                items[i].Click();
                System.Console.WriteLine(items[i].Text);
            }

        }

        [TearDown]
        public void closeBrowser()
        {
            //driver.Close();
        }
    }
}