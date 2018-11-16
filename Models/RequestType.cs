using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayfullApi_sdk.App_Code.Models
{
    public class RequestType
    {
        private string requestType;
        private string requestActionType;
        private string requestPeriod;
        private string repetitionCount;

        public string RequestTyp { get { return this.requestType; } set { this.requestType = value; } }
        public string RequestActionType { get { return this.requestActionType; } set { this.requestActionType = value; } }
        public string RequestPeriod { get { return this.requestPeriod; } set { this.requestPeriod = value; } }
        public string RepetitionCount { get { return this.repetitionCount; } set { this.repetitionCount = value; } }
    }
}