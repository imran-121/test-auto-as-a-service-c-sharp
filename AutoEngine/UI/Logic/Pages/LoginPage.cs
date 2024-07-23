using OpenQA.Selenium;
using TestAutoService.AutoEngine.UI.Logic.Utilities;


namespace TestAutoService.AutoEngine.UI.Logic.Pages
{
    // below class contains login page web elements and actions
    class LoginPage
    {

        //===========================================================================
        // Member Variables Declartaion
        //===========================================================================


        // declaring web driver
        public IWebDriver WebDriver
        {
            get;
        }


        // web element referencing
        //=========================================================
        private IWebElement webEle_loginLink => WebDriver.FindElement(By.LinkText("Log In"));

        private IWebElement webEle_inputUserName => WebDriver.FindElement(By.Id("user"));
        private IWebElement webEle_inputUserPass => WebDriver.FindElement(By.Id("password"));
        private IWebElement webEle_loginAtlasian => WebDriver.FindElement(By.Id("login"));


        private string xPath_loginSubmit = "//span[contains(text(),'Log in')]";
        private IWebElement webEle_loginSubmit => WebDriver.FindElement(By.XPath(xPath_loginSubmit));

        private string xPath_Board = "//a[@href='/imranabbassatti/boards']";



        //=========================================================
        // Constructor
        //=========================================================
        public LoginPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }



        //=========================================================
        // Member Methods
        //=========================================================

        public void Fn_LoginUser(string userName, string userPass, string url)
        {
            WebDriver.Navigate().GoToUrl(url);
            webEle_loginLink.Click();
            UIHelpers.Wait.Fn_Fixed_wait(3); //calling fixed wait wrapper method
            webEle_inputUserName.SendKeys(userName);
            UIHelpers.Wait.Fn_Fixed_wait(2);
            webEle_loginAtlasian.Click();
            webEle_inputUserPass.SendKeys(userPass);
            UIHelpers.Wait.Fn_ExpWaitUntilElementIsVisible(WebDriver, xPath_loginSubmit, 3); // calling explicit wait wrapper static method
            webEle_loginSubmit.Click();
            Fn_waitForPageLoad();
        }

        private void Fn_waitForPageLoad()
        {
            UIHelpers.Wait.Fn_ExpWaitUntilElementIsVisible(WebDriver, xPath_Board, 80);
        }

    }
}
