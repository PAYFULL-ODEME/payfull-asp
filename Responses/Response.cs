using Newtonsoft.Json;
using System;

namespace PayfullApi_sdk.App_Code.Responses
{
    public class Response
    {
        public static object ProcessResponse(string response)
        {
            var responseData = JsonConvert.DeserializeObject(response);
            return responseData;
        }
    }
}