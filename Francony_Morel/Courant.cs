namespace Francony_Morel
{
    class Courant : Account
    {
        private double decouvert;
        public Courant(Owner owner, double sold, int id, double decouvert) : base(owner, sold, id)
        {
            this.decouvert = decouvert;
        }

        public double Decouvert { get => decouvert; set => decouvert = value; }

        //Constructeurs
        public Courant() : base()
        {
            this.decouvert = 0;
        }
    }
}