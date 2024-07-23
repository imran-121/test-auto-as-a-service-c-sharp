using OpenQA.Selenium;
using TestAutoService.AutoEngine.UI.Logic.Utilities;

namespace TestAutoService.AutoEngine.UI.Logic.Pages // this name space contains one base and two derived pages
{
    // below class is base for board page, it contains board web elements and related actions
    public class BoardPage
    {
        //===========================================================================
        //                      Member Variables Declartaion
        //===========================================================================

        // declaring web driver
        public IWebDriver WebDriver
        {
            get;
        }



        // web element referencing
        //=========================================================
        private string xPath_createdNewBoard = "//span[contains(text(),'Create new board')]";
        private IWebElement webEle_createNewBoard => WebDriver.FindElement(By.XPath(xPath_createdNewBoard));


        private string xPath_inputNewBoard = "//input[@data-test-id='create-board-title-input']";
        private IWebElement webEle_inputNewBoard => WebDriver.FindElement(By.XPath(xPath_inputNewBoard));


        private string xPath_submitCreateBoard = "//button[@data-test-id='create-board-submit-button']";
        private IWebElement webEle_submitCreateBoard => WebDriver.FindElement(By.XPath(xPath_submitCreateBoard));


        private string xPath_newlyCreatedBoard = "//h1[@class='js-board-editing-target board-header-btn-text']";
        private IWebElement webEle_newlyCreatedBoard => WebDriver.FindElement(By.XPath(xPath_newlyCreatedBoard));





        //===========================================================================
        //                              Constructor
        //===========================================================================
        public BoardPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }



        //=========================================================
        // Member Methods
        //=========================================================

        public void Fn_ClickToCreateBoardButton()
        {

            UIHelpers.Wait.Fn_ExpWaitUntilElementIsVisible(WebDriver, xPath_createdNewBoard, 20);
            webEle_createNewBoard.Click();
        }

        public void Fn_EntersNewBoardName(string boardName)
        {
            UIHelpers.Wait.Fn_ExpWaitUntilElementIsVisible(WebDriver, xPath_inputNewBoard, 30);
            webEle_inputNewBoard.SendKeys(boardName);
        }


        public void Fn_SubmitCreateBoard()
        {
            UIHelpers.Wait.Fn_Fixed_wait(2);
            webEle_submitCreateBoard.Click();
        }

        public string Fn_GetNewlyCreatedBoardName()
        {
            string newBoardName = "";

            UIHelpers.Wait.Fn_Fixed_wait(5);

            newBoardName = webEle_newlyCreatedBoard.Text;

            return newBoardName;
        }

    }



    // below class is derived class and it contains web elemets/actions belog to board page menu functionality 
    public class BoardMenuPage : BoardPage
    {
        //===========================================================================
        //                      Member Variables Declartaion
        //===========================================================================

        // web element referencing
        //=========================================================
        private string xPath_showMenu = "//span[contains(text(),'Show Menu')]";
        private IWebElement webEle_showMenu => WebDriver.FindElement(By.XPath(xPath_showMenu));


        private string xPath_moreOption = "//a[contains(text(),'More')]";
        private IWebElement webEle_moreOption => WebDriver.FindElement(By.XPath(xPath_moreOption));



        private string xPath_closedBoard = "//a[contains(text(),'Close Board…')]";
        private IWebElement webEle_closedBoard => WebDriver.FindElement(By.XPath(xPath_closedBoard));

        private string xPath_closeConfirm = "//input[@type='submit' and @value='Close']";
        private IWebElement webEle_xPath_closeConfirm => WebDriver.FindElement(By.XPath(xPath_closeConfirm));



        private string xPath_delteBoard = "//a[contains(text(),'Permanently Delete Board…')]";
        private IWebElement webEle_deleteBoard => WebDriver.FindElement(By.XPath(xPath_delteBoard));

        private string xPath_deleteConfirm = "//input[@type='submit'and @value='Delete']";
        private IWebElement webEle_deleteConfirm => WebDriver.FindElement(By.XPath(xPath_deleteConfirm));


        private string xPath_noBoardFound = "//h1[contains(text(),'Board not found.')]";
        private IWebElement webEle_noBoardFound => WebDriver.FindElement(By.XPath(xPath_noBoardFound));




        //===========================================================================
        //                              Constructor
        //===========================================================================
        public BoardMenuPage(IWebDriver WebDriver) : base(WebDriver)
        {
        }



        //===========================================================================
        //                          Member Methods
        //===========================================================================
        public void Fn_ClickToShowMenu()
        {
            UIHelpers.Wait.Fn_ExpWaitUntilElementIsVisible(WebDriver, xPath_showMenu, 5);
            webEle_showMenu.Click();
        }
        public void Fn_ClickToMoreOption()
        {
            UIHelpers.Wait.Fn_ExpWaitUntilElementIsVisible(WebDriver, xPath_moreOption, 5);
            webEle_moreOption.Click();
        }

        public void Fn_ClickToClosedBoardOption()
        {
            UIHelpers.Wait.Fn_ExpWaitUntilElementIsVisible(WebDriver, xPath_closedBoard, 2);
            webEle_closedBoard.Click();
            webEle_xPath_closeConfirm.Click();
        }

        public void Fn_ClickToDelteBoardOption()
        {
            UIHelpers.Wait.Fn_ExpWaitUntilElementIsVisible(WebDriver, xPath_delteBoard, 2);
            webEle_deleteBoard.Click();

            UIHelpers.Wait.Fn_ExpWaitUntilElementIsVisible(WebDriver, xPath_deleteConfirm, 2);
            webEle_deleteConfirm.Click();
        }


        public string Fn_Get_NoBoardFoundText()
        {

            string _noBoardFoundText = "";
            UIHelpers.Wait.Fn_ExpWaitUntilElementIsVisible(WebDriver, xPath_noBoardFound, 2);
            _noBoardFoundText = webEle_noBoardFound.Text;
            return _noBoardFoundText;
        }

    }



    // below class is derived class and it contains web elemets/actions belongs board list functionality
    public class BoardList : BoardPage
    {


        //===========================================================================
        //                      Member Variables Declartaion
        //===========================================================================


        // web element referencing
        //=========================================================

        public string xPath_addList = "//span[contains(text(),'Add a list')]";
        public IWebElement webEle_addList => WebDriver.FindElement(By.XPath(xPath_addList));


        public string xPath_inputBoxList = "//input[@placeholder='Enter list title...' and @type='text']";
        public IWebElement webEle_inputBoxList => WebDriver.FindElement(By.XPath(xPath_inputBoxList));

        public string xPath_addListBtn = "//input[@value = 'Add List' and @type='submit']";
        public IWebElement webEle_addListBtn => WebDriver.FindElement(By.XPath(xPath_addListBtn));

        public string xPath_newList = "//div/h2[contains(text(),'XXReplaceTextXX')]/following-sibling::textarea";
        public IWebElement webEle_newList => WebDriver.FindElement(By.XPath(xPath_newList));



        //===========================================================================
        //                              Constructor
        //===========================================================================
        public BoardList(IWebDriver WebDriver) : base(WebDriver)
        {
        }



        //===========================================================================
        //                          Member Methods
        //===========================================================================
        public void Fn_InsertListName(string listName)
        {
            //UIHelpers.Wait.Fn_ExpWaitUntilElementIsVisible(WebDriver, xPath_inputBoxList, 15);
            UIHelpers.Wait.Fn_Fixed_wait(2);
            webEle_inputBoxList.SendKeys(listName);
        }


        public void Fn_ClickToAddListBtn()
        {
            UIHelpers.Wait.Fn_ExpWaitUntilElementIsVisible(WebDriver, xPath_addListBtn, 4);
            webEle_addListBtn.Click();
        }

        public bool Fn_SearchNewlyAddedList(string listName)
        {
            
            xPath_newList = xPath_newList.Replace("XXReplaceTextXX", listName);
            UIHelpers.Wait.Fn_ExpWaitUntilElementIsVisible(WebDriver, xPath_newList, 4);
            int height = webEle_newList.Size.Height;

            if (height == 0)
            {
                return false;
            }
            else 
            {
                return true;
            }
   
        }
    }



}
