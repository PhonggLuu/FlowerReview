using FlowerReviewApp.Dto;
using FlowerReviewApp.Models;

namespace FlowerReviewApp.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProductById(int id);
        Product GetProductByName(string name);
        ICollection<DetailedProduct> GetFlowerByProduct(int id);
        bool IsProductExists(int id);
        bool IsReference(int productId);
        bool CreateNewProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(Product product);
        bool Save();
    }
}
