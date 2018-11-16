using PayfullApi_sdk.App_Code.Models;
using PayfullApi_sdk.App_Code.Responses;
namespace PayfullApi_sdk.App_Code.Requests
{
    public class Sale : Request
    {
        const string TYPE = "Sale";
        private string paymentTitle;
        private string passiveData;
        private string currency;
        private string total;
        private string installment;
        private string bankId;
        private string gateway;


        public string PaymentTitle { get; set; }
        public string PassiveData { get; set; }
        public string Currency { get; set; }
        public string Total { get; set; }
        public string Installment { get; set; }
        public string BankId { get; set; }
        public string Gateway { get; set; }
        public string MerchantTrxId { get { return this.merchantTrxId; } set { this.merchantTrxId = value; } }
        public Sale(Config config) : base(config,TYPE)
        {
        }
        public void  SetPaymentCard(Card paymentCard)
        {
            this.paramss.Add("cc_name", paymentCard.CardHolderName);
            this.paramss.Add("cc_number",paymentCard.CardNumber);
            this.paramss.Add("cc_month", paymentCard.ExpireMonth);
            this.paramss.Add("cc_year", paymentCard.ExpireYear);
            this.paramss.Add("cc_cvc", paymentCard.Cvc);
        }
        public void SetCustomerInfo(Customer customerInfo)
        {

            this.paramss.Add("customer_firstname", customerInfo.Name);
            this.paramss.Add("customer_lastname", customerInfo.Surname);
            this.paramss.Add("customer_email", customerInfo.Email);
            this.paramss.Add("customer_phone", customerInfo.PhoneNumber);
            this.paramss.Add("customer_tc", customerInfo.TcNumber);
        }
        protected void CreateRequest()
        {
            this.paramss.Add("payment_title", this.PaymentTitle);
            this.paramss.Add("passive_data", this.PassiveData);
            this.paramss.Add("currency", this.Currency);
            this.paramss.Add("total", this.Total);
            this.paramss.Add("installments", this.Installment);
            this.paramss.Add("bank_id", this.BankId);
            this.paramss.Add("gateway", this.Gateway);
            if (this.MerchantTrxId!=null)
            {
                this.paramss.Add("merchant_trx_id", this.MerchantTrxId);
            }
            base.CreateRequest();
        }
        public object Execute()
        {
            this.CreateRequest();
            string response  = Request.Send(base.endpoint, this.paramss);
            object responseData= Response.ProcessResponse(response);
            return responseData;
        }
    }
}