using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V85.CSS;
using System.Xml.Linq;

namespace Guru99Demo
{
    class testExample
    {
        BrowserFactory browserFactory;
        string key;

        [SetUp]
        public void startBrowser()
        {
            browserFactory = new BrowserFactory();
            key = browserFactory.InitBrowser("chrome");
            browserFactory.LoadApplication(key, "https://www.ebay.com/");

            /*browserFactory = new BrowserFactory();
            key = browserFactory.InitBrowser("chrome");
            browserFactory.LoadApplication(key, "https://www.ebay.com/");*/

            /*browserFactory = new BrowserFactory();
            key = browserFactory.InitBrowser("firefox");
            browserFactory.LoadApplication(key, "https://www.ebay.com/");*/
        }

        [Test]
        public void test()
        {

            var SearchBar = browserFactory.drivers[key].FindElement(By.Id("gh-ac"));
            SearchBar.SendKeys("mause");

            var clickOption = browserFactory.drivers[key].FindElement(By.Id("gh-btn"));
            clickOption.Click();

            var items = browserFactory.drivers[key].FindElements(By.ClassName("s-item__link"));

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