namespace Francony_Morel
{
    class Courant : Account
    {
        private double decouvert;
        public Courant(double sold, int id, double decouvert) : base(owner, sold, id)
        {
            this.decouvert = decouvert;
        }

        public double Decouvert { get => decouvert; set => decouvert = value; }

        //Constructeurs
        public Courant() : base()
        {
            this.decouvert = 0;
        }

        public static Courant CreateCourant()
        {
            Console.WriteLine("Veuillez saisir le découvert autorisé :");
            double decouvert = Utils.saisieDouble();
            return new Courant(0, 0, decouvert);
        }
    }
}