namespace Francony_Morel
{
    internal abstract class Account
    {
        private static int id = 1; //!Verifier si l'incrémentation fonctionne malgré le static
        private Owner owner;

        private double sold;
        
        public Account(Owner owner, double sold)
        {
            this.owner = owner;
            this.sold = sold;
            id++;
        }

        public static int Id { get => id; set => id = value; }
        public Owner Owner { get => owner; set => owner = value; }
        public double Sold { get => sold; set => sold = value; }
    }
}
