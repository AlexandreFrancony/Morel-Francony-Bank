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

        //Méthode pour créer un owner //*Verifié!
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

        //Méthode pour ajouter un owner //*Verifié!
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

        //méthode pour afficher tout les owners d'une banque //*Verifié!
        public static void DisplayOwners(Bank bank)
        {
            Console.WriteLine("ID\tNom\t\tCard ID\t\tAdresse");
            for (int i = 0; i < bank.owners.Length; i++)
            {
                Console.WriteLine($"{i}\t{bank.owners[i].Name}\t{bank.owners[i].Card_id}\t{bank.owners[i].Address}");
            }
        }

        //Méthode pour supprimer un owner //*Verifié!
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

        //méthode qui permet de créer un compte avec tout ses attributes défit dans la classe Account //*Verifié!
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

        //méthode permettant d'ajouter un compte au tableau de compte de son propriétaire //*Verifié!
        public void AddAccount(Owner owner, Account account)
        {
            owner.AddAccount(account);
        }

        //méthode Display accounts //*Verifié!
                                   //!"euros" à revoir! => CF table ascii
        public static void DisplayAccounts(Owner owner)
        {
            for (int i = 0; i < owner.Accounts.Length; i++)
            {
                if (owner.Accounts[i] is Courant)
                {
                    Console.WriteLine("ID\tType\t\tSold\t\tDébit maximum\tDécouvert autorisé");
                    Console.WriteLine($"{i}\tCourant\t\t{owner.Accounts[i].Sold}"+"euros"+$"\t\t{owner.Accounts[i].DebitMax}"+"euros" + $"\t\t{((Courant)owner.Accounts[i]).Decouvert}"+"euros"+"\n");
                }
                else if (owner.Accounts[i] is Epargne)
                {
                    Console.WriteLine("ID\tType\t\tSold\t\tDébit maximum\tTaux d'intérêt");
                    Console.WriteLine($"{i}\tEpargne\t\t{owner.Accounts[i].Sold}"+"euros"+$"\t\t{owner.Accounts[i].DebitMax}"+"euros" + $"\t\t{((Epargne)owner.Accounts[i]).taux}"+"%"+"\n");
                }
            }
        }

        //méthode qui permet de supprimer un compte //*Verifié!
        public void RemoveAccount(Owner owner, Account account)
        {
            owner.RemoveAccount(account);
        }

        //méthode pour modifier débitMax //*Verifié!
        public void ModifierDebitMax(Account account)
        {
            Console.WriteLine("Quel est le nouveau débit maximum ?");
            double debitMax = Utils.saisieDouble();
            ((Courant)account).DebitMax = debitMax;
        }

        //méthode pour modifier découvert //*Verifié!
        public void ModifierDecouvert(Courant account)
        {
            Console.WriteLine("Quel est le nouveau découvert autorisé ?");
            double decouvert = Utils.saisieDouble();
            ((Courant)account).decouvert = decouvert;
        }

        //méthode pour modifier taux //*Verifié!
        public void ModifierTaux(Epargne account)
        {
            Console.WriteLine("Quel est le nouveau taux d'intérêt ?");
            int taux = Utils.saisieInt();
            ((Epargne)account).taux = taux;
        }

        //Méthode pour modifier les attributs d'un compte (Epargne/Courant) en fonction de son type //*Verifié!
        public void Modifier(Account toModify)
        {
            if(toModify is Courant)
            {
                Console.WriteLine("Le compte est un compte courant");
                Console.WriteLine("Quel attribut voulez-vous modifier ?\n1. Débit maximum\n2. Découvert autorisé");
                int choice = Utils.saisieInt();
                if (choice == 1)
                {
                    ModifierDebitMax(toModify);
                }
                else if (choice == 2)
                {
                    ModifierDecouvert((Courant)toModify);
                }
                else
                {
                    Console.WriteLine("Choix invalide, veuillez réessayer.");
                }
            }
            else if(toModify is Epargne)
            {
                Console.WriteLine("Le compte est un compte épargne");
                Console.WriteLine("Quel attribut voulez-vous modifier ?\n1. Débit maximum\n2. Taux d'intérêt");
                int choice = Utils.saisieInt();
                if (choice == 1)
                {
                    ModifierDebitMax(toModify);
                }
                else if (choice == 2)
                {
                    ModifierTaux((Epargne)toModify);
                }
                else
                {
                    Console.WriteLine("Choix invalide, veuillez réessayer.");
                }
            }
            else
            {
                Console.WriteLine("Le type de compte (Epargne/Courant) n'a pas été trouvé, veuillez contacter le développeur");
            }
        }
    }
}
