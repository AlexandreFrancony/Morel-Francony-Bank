namespace Francony_Morel
{
    class Epargne : Account
    {
        public int taux;
        public Epargne(Owner owner, double sold, int id, double debitMax, int taux) : base(owner, sold, id, debitMax)
        {
            this.taux = taux;
        }

        //getter et setter
        public int Taux { get => taux; set => taux = value; }
    }
}
