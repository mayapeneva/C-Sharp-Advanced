namespace OfficeStuff_Exercise
{
    public class Company
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Product { get; set; }

        public Company(string name, int amount, string product)
        {
            this.Name = name;
            this.Amount = amount;
            this.Product = product;
        }
    }
}
