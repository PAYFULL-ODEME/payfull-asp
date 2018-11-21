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

        public string PaymentTitle { get { return this.paymentTitle; } set { this.paymentTitle = value; } }
        public string PassiveData { get { return this.passiveData; } set { this.passiveData = value; } }
        public string Currency { get { return this.currency; } set { this.currency = value; } }
        public string Total { get { return this.total; } set { this.total = value; } }
        public string Installment { get { return this.installment; } set { this.installment = value; } }
        public string BankId { get { return this.bankId; } set { this.bankId = value; } }
        public string Gateway { get { return this.gateway; } set { this.gateway = value; } }
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
            this.paramss.Add("payment_title", this.paymentTitle);
            this.paramss.Add("passive_data", this.passiveData);
            this.paramss.Add("currency", this.currency);
            this.paramss.Add("total", this.total);
            this.paramss.Add("installments", this.installment);
            this.paramss.Add("bank_id", this.bankId);
            this.paramss.Add("gateway", this.gateway);
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