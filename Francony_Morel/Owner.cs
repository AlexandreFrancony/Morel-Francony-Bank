namespace Francony_Morel
{
    internal class Owner
    {
        private string name;
        private int card_id;
        private string address;

        public Owner(string name, int card_id, string address)
        {
            this.name = name;
            this.card_id = card_id;
            this.address = address;
        }

        public string Name { get => name; set => name = value; }
        public int Card_id { get => card_id; set => card_id = value; }
        public string Address { get => address; set => address = value; }
    }
}
