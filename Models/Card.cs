using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayfullApi_sdk.App_Code.Models
{
    public class Card
    {
        private string cardHolderName;
        private string cardNumber;
        private string expireYear;
        private string expireMonth;
        private string cvc;

        public string CardHolderName { get { return this.cardHolderName; } set { this.cardHolderName = value; } }
        public string CardNumber { get { return this.cardNumber; } set { this.cardNumber = value; } }
        public string ExpireYear { get { return this.expireYear; } set { this.expireYear = value; } }
        public string ExpireMonth { get { return this.expireMonth; } set { this.expireMonth = value; } }
        public string Cvc { get { return this.cvc; } set { this.cvc = value; } }
    }
}