namespace Francony_Morel
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int WhereID = 0;
            int choix = 0;
            int choixOwner = 0;
            int choixAccount = 0;
            Bank bank = new Bank(new Owner[0]);
            do
            {
                Console.Clear();
                Console.WriteLine("Bank Morel&Francony Associates");
                Console.WriteLine("1. Gestion des propriétaires");
                Console.WriteLine("2. Gestion des comptes");
                Console.WriteLine("3. ");
                Console.WriteLine("4. ");
                Console.WriteLine("5. ");
                Console.WriteLine("6. ");
                Console.WriteLine("7. ");
                Console.WriteLine("8.");
                Console.WriteLine("\n9. Quitter\n");
                Console.Write("Votre choix : ");
                choix = Utils.saisieInt();
                switch (choix)
                {//Le choix 0 doit Rester vide pour le cas où l'utilisateur ne rentre rien
                    case 1: // Menu de gestion des propriétaires
                        do{
                            Console.Clear();
                            Console.WriteLine("Gestion des propriétaires");
                            Console.WriteLine("1. Créer un owner");
                            Console.WriteLine("2. Supprimer un owner");
                            Console.WriteLine("3. Afficher tout les owners");
                            Console.WriteLine("\n9. Retour");
                            choixOwner = Utils.saisieInt();
                            switch(choixOwner)
                            {
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
                                    Console.Write("Suppression d'un owner...");
                                    Bank.DisplayOwners(bank);
                                    Console.Write("ID de l'owner à supprimer : ");
                                    WhereID = Utils.saisieInt();
                                    bank.RemoveOwner(bank.Owners[WhereID]);
                                    Console.WriteLine("Réussi !");
                                    Utils.Wait();
                                    break;

                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Affichage des owners de la banque");
                                    Bank.DisplayOwners(bank);
                                    Utils.Wait();
                                    break;

                                case 9:
                                    break;

                                default:
                                    Console.WriteLine("Choix invalide");
                                    Utils.Wait();
                                    break;
                            }
                        }while(choixOwner != 9);
                        break;

                    case 2: // Menu de gestion des comptes
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Gestion des comptes");
                            Console.WriteLine("1. Créer un compte");
                            Console.WriteLine("2. Supprimer un compte");
                            Console.WriteLine("3. Afficher tout les comptes d'un owner");
                            Console.WriteLine("4. Modifier un compte");
                            Console.WriteLine("\n9. Retour\n");
                            choixAccount = Utils.saisieInt();
                            switch(choixAccount)
                            {
                                case 1:
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

                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Suppression d'un compte\nWIP");
                                    //TODO méthode supprimer un compte
                                    Utils.Wait();
                                    break;

                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Affichage des comptes d'un owner");
                                    Console.WriteLine("De quel owner voulez-vous afficher les comptes ?");
                                    Bank.DisplayOwners(bank);
                                    Console.Write("ID : ");
                                    int id2 = Utils.saisieInt();
                                    Bank.DisplayAccounts(bank.Owners[id2]);
                                    Utils.Wait();
                                    break;

                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("Modification d'un compte\nWIP");
                                    Console.WriteLine("De quel owner voulez-vous modifier le compte ?");
                                    Bank.DisplayOwners(bank);
                                    Console.Write("ID : ");
                                    int id3 = Utils.saisieInt();
                                    Bank.DisplayAccounts(bank.Owners[id3]);
                                    Console.WriteLine("Quel est l'ID du compte à modifier ?");
                                    Console.Write("ID : ");
                                    int id4 = Utils.saisieInt();
                                    Account toModify = bank.Owners[id3].Accounts[id4];
                                    bank.Modifier(toModify);
                                    Utils.Wait();
                                    break;

                                case 9:
                                    break;
                                default:
                                    Console.WriteLine("Choix invalide");
                                    Utils.Wait();
                                    break;
                            }
                        }while(choixAccount != 9);
                        break;

                    case 3:
                        
                        break;
                    case 4:
                        

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