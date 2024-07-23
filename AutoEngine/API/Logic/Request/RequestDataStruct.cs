using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAutoService.AutoEngine.API.Logic.Generic
{
    // below class represnts the data structure for payload required to make requests
    public class RequestDataStruct 
    {
        //===========================================================================
        //                          Member Variables Declartaion
        //===========================================================================
        public string rootUrl { get; set; } // stores the root url
        public string requestPath { get; set; } // holds the request path
        public string requestMethod { get; set; } // stores the request method e.g. get, post etc
        public IDictionary<string, string> queryParameters { get; set; } // holds the query paramaters in dictonary<string key, string value>

        public IRestResponse requestResponse; // holds the response of a request

        //===========================================================================
        //                          Constructor
        //===========================================================================
        public RequestDataStruct()
        {
            queryParameters = new Dictionary<string, string>();
        }
    }
}
