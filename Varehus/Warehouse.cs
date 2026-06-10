namespace Varehus
{
    internal class Warehouse
    {
        private List<StockItem> _stock = new List<StockItem>();
        private int _nextId = 1;

        public void AddProduct(Product product, int startAmount = 0)
        {
            product.SetId(_nextId++);
            _stock.Add(new StockItem(product, startAmount));
        }

        public bool RemoveProduct(int id)
        {
            StockItem item = GetById(id);
            if (item == null) return false;
            _stock.Remove(item);
            return true;
        }

        public bool AddStock(int id, int amount)
        {
            StockItem item = GetById(id);
            if (item == null) return false;
            item.AddStock(amount);
            return true;
        }

        public bool RemoveStock(int id, int amount)
        {
            StockItem item = GetById(id);
            if (item == null) return false;
            return item.RemoveStock(amount);
        }

        public List<StockItem> GetAllStock()
        {
            return new List<StockItem>(_stock);
        }

        public List<StockItem> SearchStock(string input)
        {
            List<StockItem> results = new List<StockItem>();
            foreach (StockItem item in _stock)
            {
                if (item.Product.Name.ToLower().Contains(input) ||
                    item.Product.ProductCode.ToLower().Contains(input) ||
                    item.Product.Price.ToString().Contains(input))
                    results.Add(item);
            }
            return results;
        }

        public StockItem GetById(int id)
        {
            foreach (StockItem item in _stock)
                if (item.Product.Id == id) return item;
            return null;
        }

    }
}
