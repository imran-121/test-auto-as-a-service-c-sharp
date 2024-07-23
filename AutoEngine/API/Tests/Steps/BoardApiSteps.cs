using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestAutoService.AutoEngine.API.Logic.Generic;
using TestAutoService.AutoEngine.API.Logic.Specific;

namespace TestAutoService.AutoEngine.API.Tests.Steps
{
    [Binding]
    // below class contains step definition linked to [AutoEngine\API\Tests\Steps\BoardApiSteps.cs]

    public sealed class BoardApiSteps
    {
        //=========================================================
        // Member Variables Declartaion
        //=========================================================

        //// below variables are used for keeping expected values for assertions
        string expUpdatedBoardName = "";
        public static string saveBoardId_ForDisposal = "";

        // below object is from [BoardApiLogic] class with contains logic linked to Board.feature file
        private BoardApiLogic objBoardApiLogic = null;

        // below variables contains info. required for writing exception log files specific to feature
        private string exceptionFileName = "";
        private string exceptionFilePath = "";
        private string exceptionString = "";


        //=========================================================
        // Constructor
        //=========================================================
        public BoardApiSteps()
        {
            objBoardApiLogic = new BoardApiLogic();

            //initializing the variables for exception logging
            exceptionFileName = "BoardApiFeatureExcep.txt";
            exceptionFilePath = "\\Outputs\\API\\Logs\\ExceptionLogs\\";
        }


        //=========================================================
        // Member Methods
        //=========================================================

        // Before and after scenerio executers
        //=========================================================

        [BeforeScenario(tags: "@api_hook", Order = 0)]
        public static void StartUP()
        {
            // storing start scenerio health beat in [\Outputs\API\Logs\APIScenario_HealthLogs.txt]
            APIHelpers.LogAPI.Fn_WriteLogsForAPI("APIScenerio_HealthLogs.txt", "Scenerio Start Beat");
        }

        [AfterScenario(tags: "@api_hook", Order = 0)]
        public static void Dispose()
        {

            // storing end scenerio health beat in [\Outputs\API\Logs\APIScenario_HealthLogs.txt]
            APIHelpers.LogAPI.Fn_WriteLogsForAPI("APIScenerio_HealthLogs.txt", "Scenerio End Beat");
            DisposeObjects.Fn_DisposeBoardUsingId(saveBoardId_ForDisposal);

        }



        // Below are steps functions
        //============================================================
        [Given(@"read root url,key and token from ""(.*)""")]
        public void GivenReadRootUrlKeyAndTokenFrom(string jsonFilePath)
        {
            try
            {
                objBoardApiLogic.Fn_SetRootUrlTokenAndKey(jsonFilePath);
            }
            catch (Exception Ex)
            {
                // converting exception Ex to string and storing it into log file [Outputs\UI\Logs\ExceptionLogs\BoardUiFeatureExcep.txt]
                // wiith purpose of back tracking 
                exceptionString = Ex.ToString();
                APIHelpers.LogAPI.Fn_WriteLogsForAPI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    // if exception occurs then fail the test immediately without exeuting rest steps for scenerio
                    // release the resources
                    Assert.Fail();
                    DisposeObjects.Fn_DisposeBoardUsingId(saveBoardId_ForDisposal);
                }
            }
        }





        [Given(@"with below request path and method")]
        public void GivenWithBelowRequestPathAndMethod(Table table)
        {
            try
            {
                dynamic data = table.CreateDynamicInstance();
                objBoardApiLogic.Fn_SetRequestPathAndMethod((string)data.requestPath, (string)data.requestMethod);
            }
            catch (Exception Ex)
            {
                exceptionString = Ex.ToString();
                APIHelpers.LogAPI.Fn_WriteLogsForAPI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    
                    Assert.Fail();
                    DisposeObjects.Fn_DisposeBoardUsingId(saveBoardId_ForDisposal);
                }
            }
        }





        [Given(@"set the new board name as ""(.*)""")]
        public void GivenSetTheNewBoardNameAs(string newBoardName)
        {
            try
            {
                objBoardApiLogic.Fn_NewBoardName(newBoardName);
            }
            catch (Exception Ex)
            {
                exceptionString = Ex.ToString();
                APIHelpers.LogAPI.Fn_WriteLogsForAPI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    DisposeObjects.Fn_DisposeBoardUsingId(saveBoardId_ForDisposal);
                }
            }

        }




        [When(@"request is triggred")]
        public void WhenRequestIsTriggred()
        {
            try
            {
                objBoardApiLogic.Fn_Trigger_Req();
            }
            catch (Exception Ex)
            {
                exceptionString = Ex.ToString();
                APIHelpers.LogAPI.Fn_WriteLogsForAPI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    DisposeObjects.Fn_DisposeBoardUsingId(saveBoardId_ForDisposal);
                }
            }
        }




        [Given(@"request is triggred")]
        public void GivenRequestIsTriggred()
        {
            try
            {
                objBoardApiLogic.Fn_Trigger_Req();
            }
            catch (Exception Ex)
            {
                exceptionString = Ex.ToString();
                APIHelpers.LogAPI.Fn_WriteLogsForAPI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    DisposeObjects.Fn_DisposeBoardUsingId(saveBoardId_ForDisposal);
                }
            }
        }





        [Then(@"newly created board id should exists in response content")]
        public void ThenNewlyCreatedBoardIdShouldExistsInResponseContent()
        {
            try
            {
                string newlyCreatedBoardId = objBoardApiLogic.Fn_GetBoardIDFromResponseContent();
                saveBoardId_ForDisposal = newlyCreatedBoardId;
                Assert.IsFalse(string.IsNullOrEmpty(newlyCreatedBoardId));
            }
            catch (Exception Ex)
            {
                exceptionString = Ex.ToString();
                APIHelpers.LogAPI.Fn_WriteLogsForAPI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    DisposeObjects.Fn_DisposeBoardUsingId(saveBoardId_ForDisposal);
                }
            }
        }





        [When(@"update board name as ""(.*)""")]
        public void WhenUpdateBoardNameAs(string updateBoardName)
        {
            try
            {
                expUpdatedBoardName = updateBoardName;
                objBoardApiLogic.Fn_UpdateBoardName(updateBoardName);
            }
            catch (Exception Ex)
            {
                exceptionString = Ex.ToString();
                APIHelpers.LogAPI.Fn_WriteLogsForAPI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    DisposeObjects.Fn_DisposeBoardUsingId(saveBoardId_ForDisposal);
                }
            }
        }





        [When(@"with below request path and method")]
        public void WhenWithBelowRequestPathAndMethod(Table table)
        {
            try
            {
                dynamic data = table.CreateDynamicInstance();


                objBoardApiLogic.Fn_SetRequestPathAndMethod((string)data.requestPath, (string)data.requestMethod);
            }
            catch (Exception Ex)
            {
                exceptionString = Ex.ToString();
                APIHelpers.LogAPI.Fn_WriteLogsForAPI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    DisposeObjects.Fn_DisposeBoardUsingId(saveBoardId_ForDisposal);
                }
            }
        }






        [Then(@"verify board name value from update request response")]
        public void ThenVerifyBoardNameValueFromUpdateRequestResponse()
        {
            try
            {
                saveBoardId_ForDisposal = objBoardApiLogic.Fn_GetBoardIDFromResponseContent();

                string actualBaordName = objBoardApiLogic.Fn_GetBoardNameFromResponseContent();
                Assert.AreEqual(actualBaordName, actualBaordName);
            }
            catch (Exception Ex)
            {
                exceptionString = Ex.ToString();
                APIHelpers.LogAPI.Fn_WriteLogsForAPI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    DisposeObjects.Fn_DisposeBoardUsingId(saveBoardId_ForDisposal);
                }
            }
        }



        

        [When(@"append board id to requestpath")]
        public void WhenAppendBoardIdToRequestpath()
        {
            try
            {
                objBoardApiLogic.Fn_AppendBoradIdToRequestPath();
            }
            catch (Exception Ex)
            {
                exceptionString = Ex.ToString();
                APIHelpers.LogAPI.Fn_WriteLogsForAPI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    DisposeObjects.Fn_DisposeBoardUsingId(saveBoardId_ForDisposal);
                }
            }
        }

        [Then(@"board should be deleted")]
        public void ThenBoardShouldBeDeleted()
        {
            try
            {
                string id = objBoardApiLogic.Fn_GetBoardIDFromResponseContent();
                Assert.IsTrue(id == "");
            }
            catch (Exception Ex)
            {
                exceptionString = Ex.ToString();
                APIHelpers.LogAPI.Fn_WriteLogsForAPI(exceptionFileName, Ex.ToString(), exceptionFilePath);
            }
            finally
            {
                if (exceptionString != "")
                {
                    Assert.Fail();
                    DisposeObjects.Fn_DisposeBoardUsingId(saveBoardId_ForDisposal);
                }
            }
        }




        //[scope(Tag="test",Feature="featureName")]
    }
}
