namespace Francony_Morel
{
    class Courant : Account
    {
        public double decouvert;

        //constructeur par défaut
        public Courant(Owner owner, double sold, int id, double debitMax, double decouvert) : base(owner, sold, id, debitMax)
        {
            this.decouvert = decouvert;
        }

        //getter et setter
        public double Decouvert { get => decouvert; set => decouvert = value; }
    }
}