namespace Francony_Morel
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int WhereID = 0;
            int choix = 0;
            Bank bank = new Bank(new Owner[0]);
            do
            {
                Console.Clear();
                Console.WriteLine("Bank Morel&Francony Associates");
                Console.WriteLine("1. Créer un owner");
                Console.WriteLine("2. Afficher tout les owners d'une banque");
                Console.WriteLine("3. Créer un compte");
                Console.WriteLine("4. Affichage de tout les comptes d'un owner");
                Console.WriteLine("9. Quitter");
                Console.Write("Votre choix : ");
                choix = Utils.saisieInt();
                switch (choix)
                {//Le choix 0 doit Rester vide pour le cas où l'utilisateur ne rentre rien
                    case 1:
                        Console.Clear();
                        Console.Write("Création d'un owner...");
                        Owner owner = Bank.CreateOwner();
                        bank.AddOwner(owner);
                        Console.WriteLine("Réussi !");
                        Utils.Wait();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Affichage des owners de la banque");
                        Bank.DisplayOwners(bank);
                        Utils.Wait();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Création d'un compte");
                        Console.WriteLine("A quel owner voulez-vous ajouter un compte ?");
                        Bank.DisplayOwners(bank);
                        Console.Write("ID : ");
                        int id = Utils.saisieInt();
                        bank.Owners[id].AddAccount(Bank.CreateAccount(bank.Owners[id], WhereID));
                        WhereID++;
                        Console.WriteLine("Réussi !");

                        Utils.Wait();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Affichage des comptes d'un owner");
                        Console.WriteLine("De quel owner voulez-vous afficher les comptes ?");
                        Bank.DisplayOwners(bank);
                        Console.Write("ID : ");
                        int id2 = Utils.saisieInt();
                        Bank.DisplayAccounts(bank.Owners[id2]);
                        Utils.Wait();
                        break;

                    case 9://Quitter
                        Console.Clear();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Erreur de saisie, veuillez recommencer");
                        break;
                }
            } while (choix != 9);
        }
    }
}