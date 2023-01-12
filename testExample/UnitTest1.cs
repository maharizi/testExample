using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml.Linq;

namespace Guru99Demo
{
    class testExample
    {
        IWebDriver driver;
        BrowserFactory browserFactory;

        [SetUp]
        public void startBrowser()
        {
            //driver = new ChromeDriver("D:\\drivers\\");

            browserFactory = new BrowserFactory();
            browserFactory.InitBrowser("chrome");
            browserFactory.LoadApplication("https://www.ebay.com/");
        }

        [Test]
        public void test()
        {

            var SearchBar = browserFactory.driver.FindElement(By.Id("gh-ac"));
            SearchBar.SendKeys("mause");

            var clickOption = browserFactory.driver.FindElement(By.Id("gh-btn"));
            clickOption.Click();

            var items = browserFactory.driver.FindElements(By.ClassName("s-item__link"));

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