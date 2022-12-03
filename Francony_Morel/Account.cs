namespace Francony_Morel
{
    abstract class Account
    {
        protected int id; //!Verifier si l'incrémentation fonctionne malgré le static
        protected double sold;
        protected double debitMax;
        public Account(Owner owner, double sold, int id, double debitMax)
        {
            this.id = id;
            this.sold = sold;
            this.debitMax = debitMax;
        }

        //constructeur par défaut
        public Account()
        {
            this.sold = 0;
            id++;
            this.debitMax = 0;
        }

        public int Id { get => id; set => id = value; }
        public double Sold { get => sold; set => sold = value; }
        public double DebitMax { get => debitMax; set => debitMax = value; }

        // methode pour créer un compte courant / epargne
        
    }
}