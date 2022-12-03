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
                Console.WriteLine("3. ");
                Console.WriteLine("4. ");
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
                        Console.WriteLine("ID\tNom\t\tCarte d'identité\tAdresse");
                        Bank.DisplayOwners(bank);
                        Utils.Wait();
                    break;

                    case 3:
                    break;

                    case 4:
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