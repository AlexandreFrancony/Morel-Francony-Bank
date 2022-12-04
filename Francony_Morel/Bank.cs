namespace Francony_Morel
{
    class Bank
    {
        private Owner[] owners;

        public Bank(Owner[] owners)
        {
            this.owners = owners;
        }

        public Owner[] Owners { get => owners; set => owners = value; }

        //Méthode pour créer un owener
        public static Owner CreateOwner()
        {
            Console.Write("\nNom du propriétaire : ");
            string name = Utils.saisieString();
            Console.Write("\nNuméro de carte d'identité : ");
            int card_id = Utils.saisieInt();
            Console.Write("\nAdresse : ");
            string address = Utils.saisieString();
            Account[] accounts = new Account[0];
            Owner owner = new Owner(name, card_id, address, accounts);
            return owner;
        }

        //Méthode pour ajouter un owner
        public void AddOwner(Owner owner)
        {
            Owner[] newOwners = new Owner[owners.Length + 1];
            for (int i = 0; i < owners.Length; i++)
            {
                newOwners[i] = owners[i];
            }
            newOwners[owners.Length] = owner;
            owners = newOwners;
        }

        //méthode pour afficher tout les owners d'une banque
        public static void DisplayOwners(Bank bank)
        {
            Console.WriteLine("ID\tNom\t\tCard ID\t\tAdresse");
            for (int i = 0; i < bank.owners.Length; i++)
            {
                Console.WriteLine($"{i}\t{bank.owners[i].Name}\t{bank.owners[i].Card_id}\t{bank.owners[i].Address}");
            }
        }

        //Méthode pour supprimer un owner
        public void RemoveOwner(Owner owner)
        {
            Owner[] newOwners = new Owner[owners.Length - 1];
            int j = 0;
            for (int i = 0; i < owners.Length; i++)
            {
                if (owners[i] != owner)
                {
                    newOwners[j] = owners[i];
                    j++;
                }
            }
            owners = newOwners;
        }

        //méthode CreateAccount
        public static Account CreateAccount(Owner owner, int id)
        {
            int choice = 0;
            while (choice != 1 || choice != 2)
            {
                Console.WriteLine("Voulez-vous créer un compte courant ou un compte épargne ?\n1. Compte courant\n2. Compte épargne\n");
                choice = Utils.saisieInt();
                if (choice == 1)
                {
                    Console.WriteLine("Quel est le solde du compte?");
                    double soldCourant = Utils.saisieDouble();
                    Console.WriteLine("Quel est le débit maximum du compte?");
                    double debitMaxCourant = Utils.saisieDouble();
                    Console.WriteLine("Quel est le montant du découvert autorisé ?");
                    double decouvert = Utils.saisieDouble();
                    return new Courant(owner, soldCourant, id, debitMaxCourant, decouvert);
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Quel est le solde du compte?");
                    double soldEpargne = Utils.saisieDouble();
                    Console.WriteLine("Quel est le débit maximum du compte?");
                    double debitMaxEpargne = Utils.saisieDouble();
                    Console.WriteLine("Quel est le taux d'intérêt ?");
                    int taux = Utils.saisieInt();
                    return new Epargne(owner, soldEpargne, id, debitMaxEpargne, taux);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Choix invalide, veuillez réessayer.");
                }
            }
            return new Courant(owner, 0, id, 0, 0);
        }

        //méthode addAccount
        public void AddAccount(Owner owner, Account account)
        {
            owner.AddAccount(account);
        }

        //méthode Display accounts
        public static void DisplayAccounts(Owner owner)
        {
            for (int i = 0; i < owner.Accounts.Length; i++)
            {
                if (owner.Accounts[i] is Courant)
                {
                    Console.WriteLine("ID\tType\t\tSold\t\tDébit maximum\t\tDécouvert autorisé");
                    Console.WriteLine($"{i}\tCourant\t\t{owner.Accounts[i].Sold}"+"€"+$"\t\t{owner.Accounts[i].DebitMax}"+"€" + $"\t\t{((Courant)owner.Accounts[i]).Decouvert}"+"€"+"\n");
                }
                else if (owner.Accounts[i] is Epargne)
                {
                    Console.WriteLine("ID\tType\t\tSold\t\tDébit maximum\t\tTaux d'intérêt");
                    Console.WriteLine($"{i}\tEpargne\t\t{owner.Accounts[i].Sold}"+"€"+$"\t\t{owner.Accounts[i].DebitMax}"+"€" + $"\t\t{((Epargne)owner.Accounts[i]).taux}"+"%"+"\n");
                }
            }
        }

        //méthode removeAccount
        /*public void RemoveAccount(Owner owner, Account account)
        {
            owner.RemoveAccount(account);
        }*/

        //méthode pour modifier débitMax
        public void ModifierDebitMax(Account account)
        {
            Console.WriteLine("Quel est le nouveau débit maximum ?");
            double debitMax = Utils.saisieDouble();
            ((Courant)account).DebitMax = debitMax;
        }

        //méthode pour modifier découvert
        public void ModifierDecouvert(Courant account)
        {
            Console.WriteLine("Quel est le nouveau découvert autorisé ?");
            double decouvert = Utils.saisieDouble();
            ((Courant)account).decouvert = decouvert;
        }

        //méthode pour modifier taux
        public void ModifierTaux(Epargne account)
        {
            Console.WriteLine("Quel est le nouveau taux d'intérêt ?");
            int taux = Utils.saisieInt();
            ((Epargne)account).taux = taux;
        }

        public void Modifier(Account toModify)
        {
            if(toModify is Courant)
            {
                Console.WriteLine("Le compte est un compte courant");
                Console.WriteLine("Quel est le nouveau découvert autorisé ?");
                double newDecouvert = Utils.saisieDouble();
                ((Courant)toModify).decouvert = newDecouvert;
            }
            else if(toModify is Epargne)
            {
                Console.WriteLine("Le compte est un compte épargne");
                Console.WriteLine("Quel est le nouveau taux d'intérêt ?");
                int newTaux = Utils.saisieInt();
                ((Epargne)toModify).taux = newTaux;
            }
            else
            {
                Console.WriteLine("Le type de compte (Epargne/Courant) n'a pas été trouvé, veuillez contacter le développeur");
            }
        }
    }
}
