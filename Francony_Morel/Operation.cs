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

        //méthode Créditer permettant d'ajouter de l'argent à un compte
        public void Créditer(Account account, double amount)
        {
            Console.WriteLine("Solde actuel: " + account.Sold);
            Console.WriteLine("Sélectionner un montant à créditer: ");
            double amountc = Utils.saisieDouble();
            if (amountc > 0)
            {
                account.Sold += amountc;
                account.operations.Add(new Operation(amount, "Crédit"));
                Console.WriteLine("Crédit effectué");
                Console.WriteLine("Nouveau solde : " + account.Sold);
            }
            else
            {
                Console.WriteLine("Le montant doit être positif");
            }
        }

        //méthode Retrait permettant de retirer de l'argent d'un compte
        public void Retrait(Account account, double amount)
        {
            Console.WriteLine("Solde actuel : " + account.Sold);
            Console.WriteLine("Sélectionner un montant à débiter : ");
            double amountr = Utils.saisieDouble();
            if (amountr > 0)
            {
                if (amountr >= account.DebitMax)
                {
                    if (account is Courant)
                    {
                        if (account.Sold - amountr >= -((Courant)account).Decouvert)
                        {
                            account.Sold -= amountr;
                            account.operations.Add(new Operation(-amountr, "Retrait"));
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
                        if (account.Sold - amountr > 0)
                        {
                            account.Sold -= amountr;
                            account.operations.Add(new Operation(-amountr, "Retrait"));
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
            else
            {
                Console.WriteLine("Le montant doit être positif");
            }
        }

        //méthode Virement permettant de transférer de l'argent d'un compte à un autre
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

        //méthode Afficher historique des opérations d'un compte
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
