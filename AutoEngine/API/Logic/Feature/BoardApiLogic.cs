using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestAutoService.AutoEngine.API.Logic.Generic;

namespace TestAutoService.AutoEngine.API.Logic.Specific
{
    // this class is the logic behind the stepfile[boradApiSteps.cs] and [BoradApiSteps.cs] is linked to featurefile[BoardApi.feature]
    class BoardApiLogic
    {
        //===========================================================================
        //                          Member Variables Declartaion
        //===========================================================================


        RequestDataStruct requestDataStruct; // this variable is data structure and holds data for api request/response
        RequestWrapper objRequestTrigger; // this variable is a action class and triggers requests using RestSharp
        IRestResponse objRequestResponse; // this variable is for storing and sharing api response among all steps



        //===========================================================================
        //                          Constructor
        //===========================================================================
        public BoardApiLogic()
        {
            requestDataStruct = new RequestDataStruct();
            //objRequestTrigger = new RequestTrigger(requestDataStruct);
        }



        //===========================================================================
        //                          Member Methods
        //===========================================================================



        // Below are steps definition functions
        //============================================================
        public void Fn_SetRootUrlTokenAndKey(string jsonPath)
        {
            // below method deserializes global json file into dic<string,string>
            // json file path is [\Inputs\API\TestData\Global\getRootUrlKeyToken.json]
            // this json file contains gloal request payload
            IDictionary<string,string> _dic = APIHelpers.Read.ReadOneToOne_JsonFile_ToDic(jsonPath);

            // setting up root url into RequestDataStruct variable so that we can pass it to RequestWrapper for operations
            requestDataStruct.rootUrl = _dic["rootUrl"];
            _dic.Remove("rootUrl");

            // below method adds up two dictionries of type<string,string>
            APIHelpers.Miscellaneous.Fn_AddTwoStringDic(_dic, requestDataStruct.queryParameters);
            requestDataStruct.queryParameters = _dic;
        }




        public void Fn_SetRequestPathAndMethod(string requestPath, string requestMethod)
        {
            requestDataStruct.requestPath = requestPath;
            requestDataStruct.requestMethod = requestMethod;
        }




        public void Fn_NewBoardName(string newBoardName)
        {
            requestDataStruct.queryParameters.Add("name", newBoardName);
        }




        public void Fn_Trigger_Req()
        {
            objRequestTrigger = new RequestWrapper(requestDataStruct);
            objRequestResponse = objRequestTrigger.Fn_Execute_request();
        }





        public string Fn_GetBoardIDFromResponseContent()
        {
            string _content = objRequestResponse.Content;
            var jObject = JObject.Parse(objRequestResponse.Content);
            var _id = jObject.GetValue("id");
            if (_id != null)
            {
                return _id.ToString();
            }
            else
            {
                return "";
            }
            
        }




        public string Fn_GetBoardNameFromResponseContent()
        {
            string _content = objRequestResponse.Content;
            var jObject = JObject.Parse(objRequestResponse.Content);
            string id = jObject.GetValue("name").ToString();
            return id;
        }

      



        public void Fn_UpdateBoardName(string updateBoardName)
        {
            string _boardId = Fn_GetBoardIDFromResponseContent();
            requestDataStruct.requestPath = string.Concat(requestDataStruct.requestPath, _boardId);
            requestDataStruct.queryParameters["name"] = updateBoardName;
        }





        public void Fn_AppendBoradIdToRequestPath()
        {
            string _boardId = Fn_GetBoardIDFromResponseContent();
            requestDataStruct.requestPath = string.Concat(requestDataStruct.requestPath, _boardId);
        }

    }


    // below class is responsible for disposing request data generation during automation
    public static class DisposeObjects
    {
        public static void Fn_DisposeBoardUsingId(string boardId) // this method disposes the board created in trello
        {
            if (boardId !="" || boardId != null)
            {
                IDictionary<string, string> _dic = APIHelpers.Read.ReadOneToOne_JsonFile_ToDic("\\inputs\\API\\TestData\\Global\\getRootUrlKeyToken.json");
                RestClient client = new RestClient(_dic["rootUrl"]);
                RestRequest request = new RestRequest("/1/boards/" + boardId, Method.DELETE);
                request.AddParameter("key", _dic["key"]);
                request.AddParameter("token", _dic["token"]);
                IRestResponse response = client.Execute(request);
            }

        }
    }

}

