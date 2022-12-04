namespace Francony_Morel
{
    abstract class Account
    {
        protected int id;
        protected double sold;
        protected double debitMax;
        protected Operation[] operations;
        public Account(Owner owner, double sold, int id, double debitMax, Operation[] operations)
        {
            this.id = id;
            this.sold = sold;
            this.debitMax = debitMax;
            this.operations = operations;
        }

        //constructeur par défaut
        public Account()
        {
            this.sold = 0;
            id++;
            this.debitMax = 0;
            this.operations = new Operation[0];
        }

        //getter et setter
        public int Id { get => id; set => id = value; }
        public double Sold { get => sold; set => sold = value; }
        public double DebitMax { get => debitMax; set => debitMax = value; }
        public Operation[] Operations { get => operations; set => operations = value; }
    }
}