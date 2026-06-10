namespace Varehus
{
    internal class App
    {
        public static void Run()
        {
            Warehouse warehouse = new Warehouse();

            warehouse.AddProduct(new Product("EL-001", "TV 55\"", 8999m), 5);
            warehouse.AddProduct(new Product("EL-002", "Laptop", 12999m), 3);
            warehouse.AddProduct(new Product("MAT-001", "Kaffe 500g", 89m), 50);
            warehouse.AddProduct(new Product("MAT-002", "Havregrøt", 35m), 100);
            warehouse.AddProduct(new Product("KLE-001", "T-skjorte L", 299m), 20);

            Menu.ShowMain();
        }


    }

}
