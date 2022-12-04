namespace Francony_Morel
{
    class Epargne : Account
    {
        int taux;
        public Epargne(Owner owner, double sold, int id, double debitMax, int taux) : base(owner, sold, id, debitMax, new Operation[0])
        {
            this.taux = taux;
        }
    }
}
