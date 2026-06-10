namespace Varehus
{
    internal class Product
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ProductCode { get; private set; }

        public Product(string productCode, string name, decimal price)
        {
            Name = name;
            Price = price;
            ProductCode = productCode;
        }

        internal void SetId(int id) { Id = id; }


    }
}
