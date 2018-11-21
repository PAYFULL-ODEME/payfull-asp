namespace PayfullApi_sdk.App_Code.Models
{
    public class User
    {
        

        string operation = "add";
        private string name;
        private string surname;
        private string email;
        private string phoneNumber;
        private string tcNumber;
        private string password;
        private string address;
        private string company;
        private string taxNumber;
        private string taxOffice;
        public string Name { get { return this.name; } set { this.name = value; } }
        public string Surname { get { return this.surname; } set { this.surname = value; } }
        public string Email { get { return this.email; } set { this.email = value; } }
        public string PhoneNumber { get { return this.phoneNumber; } set { this.phoneNumber = value; } }
        public string TcNumber { get { return this.tcNumber; } set { this.tcNumber = value; } }
        public string Password { get { return this.password; } set { this.password = value; } }
        public string Address { get { return this.address; } set { this.address = value; } }
        public string Company { get { return this.company; } set { this.company = value; } }
        public string TaxNumber { get { return this.taxNumber; } set { this.taxNumber = value; } }
        public string TaxOffice { get { return this.taxOffice; } set { this.taxOffice = value; } }
    }
}