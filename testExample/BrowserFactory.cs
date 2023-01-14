using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;

namespace Guru99Demo
{
    class BrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        public Dictionary<string, IWebDriver> drivers= new Dictionary <string, IWebDriver>();
        IWebDriver driver;

        public string InitBrowser(string browserName)
        {
            switch (browserName.ToUpper())
            {
                case "IE":
                    if (!this.drivers.ContainsKey("IE"))
                    {
                        driver = new InternetExplorerDriver("C:\\bootcamp ness\\drivers");
                        this.drivers.Add("IE", driver);
                    }
                    return "IE";

                case "CHROME":
                    if (!this.drivers.ContainsKey("CROME"))
                    {
                        driver = new ChromeDriver("C:\\bootcamp ness\\drivers");
                        this.drivers.Add("Chrome", driver);
                    }
                    return "Chrome";
                case "FIREFOX":
                    if (!this.drivers.ContainsKey("FireFox"))
                    {
                        driver = new FirefoxDriver("C:\\bootcamp ness\\drivers");
                        this.drivers.Add("FireFox", driver);
                    }
                    return "FireFox";
            }
            return "";
        }

        public void LoadApplication(string brouserName, string url)
        {
            this.drivers[brouserName].Url = url;
        }

        public void CloseAllDrivers()
        {
            foreach (var key in drivers.Keys)
            {
                this.drivers[key].Close();
                this.drivers[key].Quit();
            }
        }
    }
}