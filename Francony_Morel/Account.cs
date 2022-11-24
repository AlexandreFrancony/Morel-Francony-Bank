namespace Francony_Morel
{
    abstract class Account
    {
        protected int id; //!Verifier si l'incrémentation fonctionne malgré le static
        protected double sold;
        
        public Account(Owner owner, double sold, int id)
        {
            this.sold = sold;
            this.id = id;
        }

        //constructeur par défaut
        public Account()
        {
            this.sold = 0;
            id++;
        }

        public int Id { get => id; set => id = value; }
        public double Sold { get => sold; set => sold = value; }

        public Account CreateAccount()
        {
            Console.WriteLine("Veuillez choisir le type de compte que vous souhaitez créer :");
            Console.WriteLine("1 - Compte courant");
            Console.WriteLine("2 - Compte épargne");
            int choice = Utils.saisieInt();
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Veuillez saisir le découvert autorisé :");
                    double decouvert = Utils.saisieDouble();
                    return Courant.CreateCourant();
                case 2:
                    Console.WriteLine("Veuillez saisir le taux d'intérêt :");
                    int taux = Utils.saisieInt();
                    return CreateEpargne();
                default:
                    Console.WriteLine("Veuillez saisir un choix valide");
                    return null;
            }
        }
    }
}