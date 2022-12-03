namespace Francony_Morel
{
    class Courant : Account
    {
        public double decouvert;
        public Courant(Owner owner, double sold, int id, double debitMax, double decouvert) : base(owner, sold, id, debitMax)
        {
            this.decouvert = decouvert;
        }

        public double Decouvert { get => decouvert; set => decouvert = value; }

        //Constructeurs
        public Courant() : base()
        {
            this.decouvert = 0;
        }

        public Courant(double decouvert) : base()
        {
            this.decouvert = decouvert;
        }

        public Courant(double sold, double decouvert) : base()
        {
            this.sold = sold;
            this.decouvert = decouvert;
        }

        //getter et setter
        public double GetDecouvert()
        {
            return decouvert;
        }

        public void SetDecouvert(double decouvert)
        {
            this.decouvert = decouvert;
        }
    }
}