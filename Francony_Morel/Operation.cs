namespace Francony_Morel
{
    internal class Operation
    {
        private int id;
        private int amount;
        private DateTime date; //!Check avec le prof si l'utilisation de DateTime est Autorisé
        private string libellé;

        public Operation(int id, int amount, DateTime date, string libellé)
        {
            this.id = id;
            this.amount = amount;
            this.date = date;
            this.libellé = libellé;
        }

        public int Id { get => id; set => id = value; }
        public int Amount { get => amount; set => amount = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Libellé { get => libellé; set => libellé = value; }

        //TODO: méthode retrait
        //TODO: méthode versement
        //TODO: méthode virement
    }
}
