namespace Francony_Morel
{
    class Owner
    {
        private string name;
        private int card_id;
        private string address;
        private Account[] accounts;

        public Owner(string name, int card_id, string address, Account[] accounts)
        {
            this.name = name;
            this.card_id = card_id;
            this.address = address;
            this.accounts = accounts;
        }

        public string Name { get => name; set => name = value; }
        public int Card_id { get => card_id; set => card_id = value; }
        public string Address { get => address; set => address = value; }
        public Account[] Accounts { get => accounts; set => accounts = value; }

        public void AddAccount(Account account)// owner1.AddAccount(Accounts.CreateAccount())
        {
            Account[] newAccounts = new Account[accounts.Length + 1];
            for (int i = 0; i < accounts.Length; i++)
            {
                newAccounts[i] = accounts[i];
            }
            newAccounts[accounts.Length] = account;
            accounts = newAccounts;
        }

        public void RemoveAccount(Account account)
        {
            Account[] newAccounts = new Account[accounts.Length - 1];
            int j = 0;
            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i] != account)
                {
                    newAccounts[j] = accounts[i];
                    j++;
                }
            }
            accounts = newAccounts;
        }

        public override string ToString()
        {
            return "Owner [name=" + name + ", card_id=" + card_id + ", address=" + address + "]";
        }


    }
}
