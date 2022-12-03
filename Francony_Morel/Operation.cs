namespace Francony_Morel
{
    class Operation
    {
        private int id;
        private int amount;
        private DateTime date; //!Check avec le prof si l'utilisation de DateTime est Autorisé
        private string libellé;

        public Operation(int id, int amount, DateTime date, string libellé)
        {
            this.id = id;
            this.amount = amount;
            this.date = date;
            this.libellé = libellé;
        }

        public int Id { get => id; set => id = value; }
        public int Amount { get => amount; set => amount = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Libellé { get => libellé; set => libellé = value; }

        //TODO: méthode retrait qui vérifie que le solde du compte this.sold est suffisant

        private void Retrait(Account account, int amount)
        {
            if (account.Sold >= amount)
            {
                account.Sold -= amount;
            }
            else
            {
                Console.WriteLine("Solde insuffisant");
            }
        }

        //TODO: méthode versement

        /*private void Versement(Account account1, Account account2, int amount)
        {
            if(account1 is Courant)
            {
                account1 = (Courant)account1;
                if ((account1.Sold - ((Courant)account1).decouvert)>= amount)
                {
                    account1.Sold -= amount;
                    account2.Sold += amount;
                }
                else
                {
                    Console.WriteLine("Solde insuffisant");
                }
            }
            else
            {
                account1.Sold -= amount;
                account2.Sold += amount;
            }
            if (account1.Sold >= amount)
            {
                account1.Sold -= amount;
                account2.Sold += amount;
            }
            else
            {
                Console.WriteLine("Solde insuffisant");
            }
        }*/
        //TODO: méthode virement
        //TODO: méthode qui vérifie que l'opération est possible selon le type de compte et son solde
    }
}
