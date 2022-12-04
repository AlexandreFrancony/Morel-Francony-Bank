﻿namespace Francony_Morel
{
    internal class Operation
    {
        private int id;
        private int amount;
        private DateTime date;
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

        //méthode Créditer
        public void Créditer(Account account, double amount)
        {
            if (amount > 0)
            {
                account.Sold += amount;
                //account.Operations.Add(new Operation(amount, "Crédit"));
            }
        }

        //méthode Retrait
        public void Retrait(Account account, double amount)
        {
            if (amount > 0)
            {
                if (amount >= account.DebitMax)
                {
                    if (account is Courant)
                    {
                        if (account.Sold - amount >= -((Courant)account).Decouvert)
                        {
                            account.Sold -= amount;
                            //account.Operations.Add(new Operation(-amount, "Retrait"));
                        }
                    }
                    else if (account is Epargne)
                    {
                        if (account.Sold - amount > 0)
                        {
                            account.Sold -= amount;
                            //account.Operations.Add(new Operation(-amount, "Retrait"));
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
            //}
        }
    }
}