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
        public IWebDriver driver;

        public IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName.ToUpper())
            { 
                case "IE":
                    if (driver == null)
                    {
                        driver = new InternetExplorerDriver("C:\\drivers\\");
                        Drivers.Add("IE", driver);
                    }
                    break;

                case "CHROME":
                    if (driver == null)
                    {
                        driver = new ChromeDriver("C:\\drivers\\");
                        Drivers.Add("Chrome", driver);
                    }
                    break;
            }
        }

        public void LoadApplication(string url)
        {
            Driver.Url = url;
        }

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
    }
}