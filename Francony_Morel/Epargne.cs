namespace Francony_Morel
{
    class Epargne : Account
    {
        int taux;
        public Epargne(Owner owner, double sold, int id, int taux) : base(owner, sold, id)
        {
            this.taux = taux;
        }
    }
}
