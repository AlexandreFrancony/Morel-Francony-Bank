namespace Francony_Morel
{
    internal class Utils
    {
        public static int saisieNombre()
        {
            //Saisie d'un nombre entier non null et retourne le nombre
            int? nombre = null;
            while (nombre == null)
            {
                try
                {
                    nombre = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Le nombre ne peut pas être vide, Veuillez recommencer.");
                }
            }
            return (int)nombre;
        }

        public static string saisieString()
        {
            string? s = "";
            while (s == "" || s == null)
            {
                s = Console.ReadLine();
                if (s == "" || s == null)
                {
                    Console.WriteLine("La saisie ne peut pas être vide, veuillez recommencer.");
                }
            }
            return s;
        }

        public static void Wait()
        {
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
        }
    }
}
