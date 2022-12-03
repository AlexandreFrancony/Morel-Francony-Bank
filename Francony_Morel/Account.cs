namespace Francony_Morel
{
    abstract class Account
    {
        protected int id;
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

        //getter et setter
        public int Id { get => id; set => id = value; }
        public double Sold { get => sold; set => sold = value; }
        public double DebitMax { get => debitMax; set => debitMax = value; }
    }
}