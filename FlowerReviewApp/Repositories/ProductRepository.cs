using AutoMapper;
using FlowerReviewApp.Interfaces;
using FlowerReviewApp.Models;

namespace FlowerReviewApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SONUNGVIENREVIEWContext _context;
        public ProductRepository(SONUNGVIENREVIEWContext context)
        {
            _context = context;
        }

        public ICollection<DetailedProduct> GetFlowerByProduct(int productId)
        {
            return _context.DetailedProducts.Where(dp => dp.Product.ProductId == productId).ToList();
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.Where(p => p.ProductId == productId).FirstOrDefault();
        }

        public Product GetProductByName(string productName)
        {
            return _context.Products.Where(p => p.ProductName == productName).FirstOrDefault();
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public bool IsProductExists(int id)
        {
            return _context.Products.Any(p => p.ProductId == id);
        }

        public bool IsReference(int id)
        {
            return _context.DetailedProducts.Any(p => p.Product.ProductId == id);
        }

        public bool CreateNewProduct(Product product)
        {
            _context.Add(product);
            return Save();
        }

        public bool UpdateProduct(Product product)
        {
            _context.Update(product);
            return Save();
        }
        public bool DeleteProduct(Product product)
        {
            _context.Remove(product);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}
