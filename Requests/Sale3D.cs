using PayfullApi_sdk.App_Code.Responses;

namespace PayfullApi_sdk.App_Code.Requests
{
    public class Sale3D:Sale
    {
        const string USE3D = "1";
        private string returnUrl;
        public string ReturnUrl { get; set; }
        public Sale3D(Config config) : base(config)
        {
        }
        protected void CreateRequest()
        {
            this.paramss.Add("return_url", this.ReturnUrl);
            this.paramss.Add("use3d", USE3D);
            base.CreateRequest();
        }
        public object Execute()
        {
            this.CreateRequest();
            string response = Request.Send(base.endpoint, this.paramss);
            string responseData = Response.ProcessTHDResponse(response);
            return responseData;
        }
    }
}