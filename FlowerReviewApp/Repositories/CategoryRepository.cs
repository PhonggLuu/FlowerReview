using FlowerReviewApp.Interfaces;
using FlowerReviewApp.Models;

namespace FlowerReviewApp.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SONUNGVIENREVIEWContext _context;
        public CategoryRepository(SONUNGVIENREVIEWContext context)
        {
            _context = context;
        }
        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
        }

        public Category GetCategory(string name)
        {
            return _context.Categories.Where(c => c.CategoryName.Contains(name)).FirstOrDefault();
        }

        public ICollection<Product> GetProductsByCategory(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryID == categoryId).ToList();
        }

        public bool IsCategoryExists(int id)
        {
            return _context.Categories.Any(c => c.CategoryId == id);
        }
    }
}
