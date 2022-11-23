namespace Francony_Morel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choix = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("1. ");
                Console.WriteLine("2. ");
                Console.WriteLine("3. ");
                Console.WriteLine("4. ");
                Console.WriteLine("9. Quitter");
                Console.Write("Votre choix : ");
                choix = Utils.saisieNombre();
                switch (choix) 
                {//Le choix 0 doit Rester vide pour le cas où l'utilisateur ne rentre rien
                    case 1:
                    break;

                    case 2://Création
                    break;

                    case 3://Infos
                    break;

                    case 4://Read Data
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