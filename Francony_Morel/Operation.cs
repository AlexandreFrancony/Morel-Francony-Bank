namespace Francony_Morel
{
    internal class Operation
    {
        private static int CompteurID = 0;
        private int id;
        private double amount;
        private DateTime date;
        private string libellé;

        public Operation(double amount, string libellé)
        {
            CompteurID++;
            id = CompteurID;
            this.amount = amount;
            date = DateTime.Now;
            this.libellé = libellé;
        }

        public int Id { get => id; set => id = value; }
        public double Amount { get => amount; set => amount = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Libellé { get => libellé; set => libellé = value; }

        //méthode Créditer
        public void Créditer(Account account, double amount)
        {
            Console.WriteLine("Solde actuel: " + account.Sold);
            if (amount > 0)
            {
                account.Sold += amount;
                account.operations.Add(new Operation(amount, "Crédit"));
                Console.WriteLine("Crédit effectué");
                Console.WriteLine("Nouveau solde : " + account.Sold);
            }
        }

        //méthode Retrait
        public void Retrait(Account account, double amount)
        {
            Console.WriteLine("Solde actuel : " + account.Sold);
            if (amount > 0)
            {
                if (amount >= account.DebitMax)
                {
                    if (account is Courant)
                    {
                        if (account.Sold - amount >= -((Courant)account).Decouvert)
                        {
                            account.Sold -= amount;
                            account.operations.Add(new Operation(-amount, "Retrait"));
                            Console.WriteLine("Retrait effectué");
                            Console.WriteLine("Nouveau solde : " + account.Sold);
                        }
                        else
                        {
                            Console.WriteLine("Solde insuffisant");
                        }
                    }
                    else if (account is Epargne)
                    {
                        if (account.Sold - amount > 0)
                        {
                            account.Sold -= amount;
                            account.operations.Add(new Operation(-amount, "Retrait"));
                            Console.WriteLine("Retrait effectué");
                            Console.WriteLine("Nouveau solde : " + account.Sold);
                        }
                        else
                        {
                            Console.WriteLine("Solde insuffisant");
                        }
                    }
                }
            }
        }

        //méthode Virement
        public void Virement(Account account1, Account account2, double amount)
        {
            //if (account1.Banque == account2.Banque)
            //{
            Retrait(account1, amount);
            Créditer(account2, amount);
            account1.operations.Add(new Operation(-amount, "Virement vers " + account2.Id));
            account2.operations.Add(new Operation(amount, "Virement de " + account1.Id));
            Console.WriteLine("Virement effectué");
            Console.WriteLine("Nouveau solde du compte ayant effectué un retrait : " + account1.Sold);
            Console.WriteLine("Nouveau solde du compte ayant été crédité : " + account2.Sold);
            //}
        }

        //méthode Afficher historique des opérations
        public void AfficherHistorique(Account account)
        {
            Console.WriteLine("Historique des opérations du compte " + account.Id);
            foreach (Operation operation in account.operations)
            {
                Console.WriteLine("Opération " + operation.Id + " : " + operation.Libellé + " de " + operation.Amount + "€ le " + operation.Date);
            }
        }
    }
}