namespace Demo_MVC.Models
{
	public class ProductSampleData
	{
		List<Product> products;
        public ProductSampleData()
        {
            products = new List<Product>
            {
                new Product{Id = 1, Name = "product 1", Price = 10000, Image = "car-1.png", Description = "Hey Hey Hey Run For Life"},
                new Product{Id = 2, Name = "product 2", Price = 4000, Image = "car-2.png", Description = "Hey Hey Hey Run For Life"},
                new Product{Id = 3, Name = "product 3", Price = 8000, Image = "car-3.png", Description = "Hey Hey Hey Run For Life"}
            };
        }

        public  List<Product> GetAll()
        {
            return products;
        }

        public Product GetById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }
    }
}
