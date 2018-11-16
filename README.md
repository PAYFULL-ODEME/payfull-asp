C# PAyfull SDK Alpha
How Tou Use
Config config = new Config
            {
                ApiKey = "hazem",
                ApiSecret = "hazemarian",
                ApiUrl = "https://test.payfull.com/integration/api/v1"
            };
            Sale sale = new Sale(config)
            {
                PaymentTitle = "Payment Title",
                PassiveData = "PassiveData",
                Currency = "TRY",
                Total = "13.00",
                BankId = "Akbank",
                Gateway = "10001",
                Installment = "1",
                MerchantTrxId = "xxx-0411684-0354354"
            };
            Card card = new Card
            {
                CardHolderName = "Name Surname",
                CardNumber = "4355084355084358",
                ExpireMonth = "12",
                ExpireYear = "2030",
                Cvc = "000"
            };
            sale.SetPaymentCard(card);
            Customer customer = new Customer
            {
                Name = "Name",
                Surname = "Surname",
                Email = "faruk@payfull.com",
                PhoneNumber = "05399999999",
                TcNumber = "13416836798"
            };
            sale.SetCustomerInfo(customer);
            var response = sale.Execute();