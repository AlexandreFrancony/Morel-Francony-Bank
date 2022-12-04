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

        //méthode Créditer permettant d'ajouter de l'argent à un compte //*Verifié!
        public static void Créditer(Account account, double amountc)
        {

            if (amountc > 0)
            {
                account.Sold += amountc;
                account.operations.Add(new Operation(amountc, "Crédit"));

                Console.WriteLine("Crédit effectué");
                Console.WriteLine("Nouveau solde : " + account.Sold);
            }
            else
            {
                Console.WriteLine("Le montant doit être positif");
            }
        }

        //méthode Retrait permettant de retirer de l'argent d'un compte //*Verifié!
        public static void Retrait(Account account, double amountr)
        {
            if (amountr > 0)
            {
                if (amountr <= account.DebitMax)

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
                else
                {
                    Console.WriteLine("Le montant est supérieur au découvert autorisé");
                }
            }
            else
            {
                Console.WriteLine("Le montant doit être positif");
            }
        }

        //méthode Virement permettant de transférer de l'argent d'un compte à un autre //*Verifié!
        public static void Virement(Account account1, Account account2, double amountv)
        {
            //if (account1.Banque == account2.Banque)
            //{
            Retrait(account1, amountv);
            Créditer(account2, amountv);
            account1.operations.Add(new Operation(-amountv, "Virement vers " + account2.Id));
            account2.operations.Add(new Operation(amountv, "Virement de " + account1.Id));
            Console.WriteLine("Virement effectué");
            Console.WriteLine("Nouveau solde du compte ayant effectué un retrait : " + account1.Sold);
            Console.WriteLine("Nouveau solde du compte ayant été crédité : " + account2.Sold);
            //}
        }

        //méthode Afficher historique des opérations d'un compte //*Verifié!
        public static void AfficherHistorique(Account account)
        {
            Console.WriteLine("Historique des opérations du compte " + account.Id);
            foreach (Operation operation in account.operations)
            {
                Console.WriteLine("Opération " + operation.Id + " : " + operation.Libellé + " de " + operation.Amount + "€ le " + operation.Date);
            }
        }
    }
}
