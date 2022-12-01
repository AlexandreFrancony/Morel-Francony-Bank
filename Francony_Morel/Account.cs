namespace Francony_Morel
{
    abstract class Account
    {
        protected int id; //!Verifier si l'incrémentation fonctionne malgré le static
        protected double sold;
        
        public Account(Owner owner, double sold, int id)
        {
            this.sold = sold;
            this.id = id;
        }

        //constructeur par défaut
        public Account()
        {
            this.sold = 0;
            id++;
        }

        public int Id { get => id; set => id = value; }
        public double Sold { get => sold; set => sold = value; }
    }
}