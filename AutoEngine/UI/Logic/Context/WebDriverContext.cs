using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TestAutoService.AutoEngine.UI.Logic.Utilities;

namespace TestAutoService.AutoEngine.UI.Logic.Context
{
    public class WebDriverContext
    {
        public IWebDriver driver;

        public WebDriverContext()
        {
            // getting the browser name from xml configuration file [[\\Inputs\\UI\\Configuration\\TestConfigurations.xml]]
            string browserType = UIHelpers.Config.Fn_getUIconfigValueOnKey("browser");
     
            switch(browserType)
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;

                case "ie":
                    driver = new InternetExplorerDriver();
                    break;

                case "firefox":
                    driver = new FirefoxDriver();
                    break;

                default:
                    driver = new ChromeDriver();
                    break;
            }
            
        }
    }
}
