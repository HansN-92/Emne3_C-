namespace Varehus
{
    internal class StockItem
    {
        public Product Product { get; private set; }
        public int AmountInStock { get; private set; }


        public StockItem(Product product, int startAmount = 0)
        {
            Product = product;
            AmountInStock = startAmount;

        }

        public void AddStock(int amount) 
        {
            AmountInStock += amount; 
        }

        public bool RemoveStock(int amount)
        {
            if (amount > AmountInStock) 
                return false;

            AmountInStock -= amount;
            return true;
        }
    }
}
