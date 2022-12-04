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
                Console.WriteLine("3. Effectuer une opération");
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
                            Console.WriteLine("5. Afficher l'historique des opération d'un compte");
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
                                    Console.WriteLine("Quel est l'id du propriétaire du compte à supprimer?");
                                    Bank.DisplayOwners(bank);
                                    Console.Write("ID : ");
                                    int id5 = Utils.saisieInt();
                                    Console.WriteLine("Quel est l'id du compte à supprimer?");
                                    Bank.DisplayAccounts(bank.Owners[id5]);
                                    Console.Write("ID : ");
                                    int id6 = Utils.saisieInt();
                                    bank.Owners[id5].RemoveAccount(bank.Owners[id5].Accounts[id6]);
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
                                    Console.WriteLine("Modification d'un compte\n");
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
                                
                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("Affichage de l'historique des opérations d'un compte");
                                    Console.WriteLine("De quel owner voulez-vous afficher l'historique des opérations ?");
                                    Bank.DisplayOwners(bank);
                                    Console.Write("ID : ");
                                    int id22 = Utils.saisieInt();
                                    Bank.DisplayAccounts(bank.Owners[id22]);
                                    Console.WriteLine("Quel est l'ID du compte à afficher ?");
                                    Console.Write("ID : ");
                                    int id23 = Utils.saisieInt();
                                    Account toDisplay = bank.Owners[id22].Accounts[id23];
                                    Operation.AfficherHistorique(toDisplay);
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
                    #region Effectuer une opération
                        Console.Clear();
                        Console.WriteLine("Effectuer une opération");
                        Console.WriteLine("Depuis quel owner voulez-vous effectuer une opération ?");
                        Bank.DisplayOwners(bank);
                        Console.Write("ID : ");
                        int id7 = Utils.saisieInt();
                        Console.WriteLine("Depuis quel compte voulez-vous effectuer une opération ?");
                        Bank.DisplayAccounts(bank.Owners[id7]);
                        Console.Write("ID : ");
                        int id8 = Utils.saisieInt();
                        int choixOperation = 0;
                        do{
                            Console.WriteLine("Quel type d'opération voulez-vous effectuer ?");
                            Console.WriteLine("1. Dépot");
                            Console.WriteLine("2. Retrait");
                            Console.WriteLine("3. Virement");
                            Console.WriteLine("\n9. Retour");
                            Console.Write("Choix : ");
                            choixOperation = Utils.saisieInt();
                            switch(choixOperation)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Dépot");
                                    Console.WriteLine("Solde actuel: " + bank.Owners[id7].Accounts[id8].Sold);
                                    Console.Write("Montant du dépot : ");
                                    double amount1 = Utils.saisieDouble();
                                    Operation.Créditer(bank.Owners[id7].Accounts[id8], amount1);
                                    Console.WriteLine("Réussi !");
                                    Utils.Wait();
                                    break;

                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Retrait");
                                    Console.WriteLine("Solde actuel: " + bank.Owners[id7].Accounts[id8].Sold);
                                    Console.Write("Montant du retrait : ");
                                    double amount2 = Utils.saisieDouble();
                                    Operation.Retrait(bank.Owners[id7].Accounts[id8], amount2);
                                    Console.WriteLine("Réussi !");
                                    Utils.Wait();
                                    break;

                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Virement");
                                    Console.WriteLine("Vers quel owner voulez-vous effectuer un virement ?");
                                    Bank.DisplayOwners(bank);
                                    Console.Write("ID : ");
                                    int id10 = Utils.saisieInt();
                                    Console.WriteLine("Vers quel compte voulez-vous effectuer un virement ?");
                                    Bank.DisplayAccounts(bank.Owners[id10]);
                                    Console.Write("ID : ");
                                    int id11 = Utils.saisieInt();
                                    Console.Write("Montant : ");
                                    double montant3 = Utils.saisieDouble();
                                    Operation.Virement(bank.Owners[id7].Accounts[id8], bank.Owners[id10].Accounts[id11], montant3);
                                    Console.WriteLine("Réussi !");
                                    Utils.Wait();
                                    break;

                                case 9:
                                    Console.Clear();
                                    break;

                                default:
                                    Console.WriteLine("Choix invalide");
                                    Utils.Wait();
                                    break;
                            }
                        }while(choixOperation != 9);
                    #endregion    
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