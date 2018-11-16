using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayfullApi_sdk.App_Code.Models
{
    public class PaymentItem
    {
        private string item;
        private string freeAmount;
        private string freeTitle;
        private int quantity;

        public string Item { get { return this.item; } set { this.item = value; } }
        public string FreeAmount { get { return this.freeAmount; } set { this.freeAmount = value; } }
        public string FreeTitle { get { return this.freeTitle; } set { this.freeTitle = value; } }
        public int Quantity { get { return this.quantity; } set { this.quantity = value; } }
    }
}