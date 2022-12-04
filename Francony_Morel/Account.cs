namespace Francony_Morel
{
    abstract class Account
    {
        protected int id;
        protected double sold;
        protected double debitMax;
        protected List<Operation> operations;
        public Account(Owner owner, double sold, int id, double debitMax)
        {
            this.id = id;
            this.sold = sold;
            this.debitMax = debitMax;
            this.operations = new List<Operation>();
        }

        //getter et setter
        public int Id { get => id; set => id = value; }
        public double Sold { get => sold; set => sold = value; }
        public double DebitMax { get => debitMax; set => debitMax = value; }
        public List<Operation> Operations { get => operations; set => operations = value; }
    }
}