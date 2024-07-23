using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutoService.AutoEngine.API.Logic.Generic
{
    // below class is a wrapper around RestSharp and we exposed the required functionality
    class RequestWrapper
    {

        //===========================================================================
        //                          Member Variables Declartaion
        //===========================================================================

        RequestDataStruct reqDataStruct = new RequestDataStruct();

        private string rootUrl="";
        private string reqMethod="";
     
        private IDictionary<string,string> queryParaDic = null;



        //===========================================================================
        //                          Constructor
        //===========================================================================
        public RequestWrapper(RequestDataStruct pReqDataStruct)
        {
            // get the date mandatory payload for making request while initialization
            // pReqDataStruct is of type RequestDataStruct which is a structure file

            reqDataStruct = pReqDataStruct;

            rootUrl = reqDataStruct.rootUrl;
            reqMethod = reqDataStruct.requestMethod;
            //reqPath = reqDataStruct.requestPath;
            queryParaDic = reqDataStruct.queryParameters;

        }



        //===========================================================================
        //                          Member Methods
        //===========================================================================

        
        public IRestResponse Fn_Execute_request() // executes the request using RestSharp frameworks
        {
            RestClient client = new RestClient(rootUrl);

            // type casting, in below two steps we are casting string type method name to Enum
            string _reqMethod = (reqMethod).ToUpper();
            Enum.TryParse(_reqMethod, out Method enum_reqMethod);

            // preparing the request object
            RestRequest request = new RestRequest(reqDataStruct.requestPath, enum_reqMethod);

            // adding query parameters to the request
            foreach (KeyValuePair<string, string> entry in queryParaDic)
            {
                request.AddParameter(entry.Key,entry.Value);
            }

            // executing the request and returing the response
            IRestResponse response = client.Execute(request);

            return response;

            
        }
    }
}
