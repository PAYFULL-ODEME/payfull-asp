using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PayfullApi_sdk.App_Code.Models
{
    public class Customer
    {
        private string name;
        private string surname;
        private string email;
        private string phoneNumber;
        private string tcNumber;
        public string Name { get { return this.name; } set { this.name = value; } }
        public string Surname { get { return this.surname; } set { this.surname = value; } }
        public string Email { get { return this.email; } set { this.email = value; } }
        public string PhoneNumber { get { return this.phoneNumber; } set { this.phoneNumber = value; } }
        public string TcNumber { get { return this.tcNumber; } set { this.tcNumber = value; } }
    }
}