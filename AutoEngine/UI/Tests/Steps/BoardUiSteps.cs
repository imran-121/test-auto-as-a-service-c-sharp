using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestAutoService.AutoEngine.UI.Logic.Context;
using TestAutoService.AutoEngine.UI.Logic.Pages;
using TestAutoService.AutoEngine.UI.Logic.Utilities;

namespace TestAutoService.AutoEngine.UI.Steps
{
    [Binding]
    // below class is step defintion class linked to [BoardAp.feature]
    public sealed class BoardUiSteps 
    {
        //===========================================================================
        // Member Variables Declartaion
        //===========================================================================

        // below variables are used for keeping expected values for assertions
        private string expBoardName= null;
        private string expNoBoardFoundText = null;

        // below variables are objects of pages
        private LoginPage pageObjLogin = null;
        private BoardPage pageObjBoard = null; 
        private BoardMenuPage pageObjBoardMenu = null; // Inherired from BoardPage
        private BoardList pageObjBoardList = null; // Inherired from BoardPage

        // below variiables are used for context depnedency injection for storing web drivers
        private readonly WebDriverContext _webDriverContext;
        private static WebDriverContext _saveWebDriverContext;

        // below variables contains info. required for writing exception log files specific to feature
        private string exceptionFileName = "";
        private string exceptionFilePath = "";
        private string exceptionString = "";


        //===========================================================================
        // Constructor
        //===========================================================================
        public BoardUiSteps(WebDriverContext webdriverContext)
        {
            this._webDriverContext = webdriverContext;
            _saveWebDriverContext = this._webDriverContext; // storing the value web driver in static so that we can use it in after sceberio binding

            pageObjLogin = new LoginPage(_webDriverContext.driver);
            pageObjBoard = new BoardPage(_webDriverContext.driver);
            pageObjBoardMenu = new BoardMenuPage(_webDriverContext.driver);
            pageObjBoardList = new BoardList(_webDriverContext.driver);

            //initializing the variables for exception logging
            exceptionFileName = "BoardUiFeatureExcep.txt";
            exceptionFilePath = "\\Outputs\\UI\\Logs\\ExceptionLogs\\";

        }



        //===========================================================================
        //                          Member Methods
        //===========================================================================


        // Before and after scenerio executers
        //=========================================================

        [BeforeScenario(tags: "web_hook", Order = 0)]
        public static void StartUP()
        {
        // storing start scenerio health beat in [\Outputs\UI\Logs\UIScenario_HealthLogs.txt]
            UIHelpers.LogUI.Fn_WriteLogsForUI("UIScenario_HealthLogs.txt","Scenrio Start Beat");
        }

        [AfterScenario(tags: "web_hook", Order = 0)]
        public static void Dispose()
        {
            // disposing of webdriver object
            _saveWebDriverContext.driver.Close();

            // storing close scenerio health beat in [\Outputs\UI\Logs\UIScenario_HealthLogs.txt]
            UIHelpers.LogUI.Fn_WriteLogsForUI("UIScenario_HealthLogs.txt", "Scenrio Closed Beat");
            
        }



        // Below are step definition functions
        //============================================================

        [Given(@"user is already logged into the system")]
        public void GivenUserIsAlreadyLoggedIntoTheSystem(Table table)
        {
            try
            {
                dynamic data = table.CreateDynamicInstance(); // Fetching the table data from feature file [UI/Tests/Features/BoardUi.feature]
                string _userName = data.userName;
                string _password = data.password;
                // in below function we are fetching data from global ui configuration file [\\Inputs\\UI\\Configuration\\TestConfigurations.xml]
                // with purpose that we shpould have centeralized test configuration file
                string _env = UIHelpers.Config.Fn_getUIconfigValueOnKey("enviroment"); 

                pageObjLogin.Fn_LoginUser(_userName, _password, _env);
            }
            catch (Exception Ex)
            {
            // converting exception Ex to string and storing it into log file [Outputs\UI\Logs\ExceptionLogs\BoardUiFeatureExcep.txt]
            // wiith purpose of back tracking 
             exceptionString = Ex.ToString();
                UIHelpers.LogUI.Fn_WriteLogsForUI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    // if exception occurs then fail the test immediately without exeuting rest steps for scenerio
                    // release the resources
                    Assert.Fail();
                    _saveWebDriverContext.driver.Close();
                }
            }
            
        }




        [Given(@"user clicks on create new board on board page")]
        public void GivenUserClicksOnCreateNewBoardOnBoardPage()
        {
            try
            {
                pageObjBoard.Fn_ClickToCreateBoardButton();
            }
            catch (Exception Ex)
            {

                exceptionString = Ex.ToString();
                UIHelpers.LogUI.Fn_WriteLogsForUI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    _saveWebDriverContext.driver.Close();
                }
            }

        }


        

        [When(@"enters the name ""(.*)"" in title")]
        public void WhenEntersTheNameInTitle(string boardName)
        {
            try
            {
                pageObjBoard.Fn_EntersNewBoardName(boardName);
                expBoardName = boardName;
            }
            catch (Exception Ex)
            {

                exceptionString = Ex.ToString();
                UIHelpers.LogUI.Fn_WriteLogsForUI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    _saveWebDriverContext.driver.Close();
                }
            }
        }




        [When(@"clicks to create board button")]
        public void WhenClicksToCreateBoardButton()
        {
            try
            {
                pageObjBoard.Fn_SubmitCreateBoard();
            }
            catch (Exception Ex)
            {

                exceptionString = Ex.ToString();
                UIHelpers.LogUI.Fn_WriteLogsForUI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    _saveWebDriverContext.driver.Close();
                }
            }
        }





        [Then(@"new board should be created")]
        public void ThenNewBoardShouldBeCreated()
        {
            try
            {
                string actualBoardName;
                actualBoardName = pageObjBoard.Fn_GetNewlyCreatedBoardName();
                Assert.That(actualBoardName == expBoardName, Is.True);
            }
            catch (Exception Ex)
            {

                exceptionString = Ex.ToString();
                UIHelpers.LogUI.Fn_WriteLogsForUI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    _saveWebDriverContext.driver.Close();
                }
            }
        }


        //===============================



        [When(@"clicks to more option form menu box")]
        public void WhenClicksToMoreOptionFormMenuBox()
        {
            try
            {
                pageObjBoardMenu.Fn_ClickToMoreOption();
            }
            catch (Exception Ex)
            {

                exceptionString = Ex.ToString();
                UIHelpers.LogUI.Fn_WriteLogsForUI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    _saveWebDriverContext.driver.Close();
                }
            }
        }





        [When(@"clicks to close board")]
        public void WhenClicksToCloseBoard()
        {
            try
            {
                pageObjBoardMenu.Fn_ClickToClosedBoardOption();
            }
            catch (Exception Ex)
            {

                exceptionString = Ex.ToString();
                UIHelpers.LogUI.Fn_WriteLogsForUI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    _saveWebDriverContext.driver.Close();
                }
            }
        }





        [When(@"clicks to permanently Delte Board")]
        public void WhenClicksToPermanentlyDelteBoard()
        {
            try
            {
                pageObjBoardMenu.Fn_ClickToDelteBoardOption();
            }
            catch (Exception Ex)
            {

                exceptionString = Ex.ToString();
                UIHelpers.LogUI.Fn_WriteLogsForUI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    _saveWebDriverContext.driver.Close();
                }
            }
        }





        [Then(@"board should not be found")]
        public void ThenBoardShouldNotBeFound(Table table)
        {
            try
            {
                dynamic data = table.CreateDynamicInstance();
                expNoBoardFoundText = data.noBoardFoundText;

                string actualNoBoardFoundText = "";
                actualNoBoardFoundText = pageObjBoardMenu.Fn_Get_NoBoardFoundText();

                Assert.That(actualNoBoardFoundText == expNoBoardFoundText, Is.True);
            }
            catch (Exception Ex)
            {

                exceptionString = Ex.ToString();
                UIHelpers.LogUI.Fn_WriteLogsForUI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    _saveWebDriverContext.driver.Close();
                }
            }
        }





        [When(@"inserts list name ""(.*)"" in input list")]
        public void WhenInsertsListNameInInputList(string listName)
        {
            try
            {
                pageObjBoardList.Fn_InsertListName(listName);
            }
            catch (Exception Ex)
            {

                exceptionString = Ex.ToString();
                UIHelpers.LogUI.Fn_WriteLogsForUI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    _saveWebDriverContext.driver.Close();
                }
            }
        }






        [When(@"clicks to add list button")]
        public void WhenClicksToAddListButton()
        {
            try
            {
                pageObjBoardList.Fn_ClickToAddListBtn();
            }
            catch (Exception Ex)
            {

                exceptionString = Ex.ToString();
                UIHelpers.LogUI.Fn_WriteLogsForUI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    _saveWebDriverContext.driver.Close();
                }
            }

        }




        [Then(@"search the list name ""(.*)"" on page and it should exist")]
        public void ThenSearchTheListNameOnPageAndItShouldExist(string listName)
        {
            try
            {
                bool listExists = pageObjBoardList.Fn_SearchNewlyAddedList(listName);
                Assert.IsTrue(listExists);
            }
            catch (Exception Ex)
            {

                exceptionString = Ex.ToString();
                UIHelpers.LogUI.Fn_WriteLogsForUI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    _saveWebDriverContext.driver.Close();
                }
            }
        }






    }
}
