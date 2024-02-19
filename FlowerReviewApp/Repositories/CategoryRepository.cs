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
            return _context.Products.Where(p => p.Category.CategoryId == categoryId).ToList();
        }

        public bool IsCategoryExists(int id)
        {
            return _context.Categories.Any(c => c.CategoryId == id);
        }

        public bool IsReference(int id)
        {
            return _context.Products.Any(p => p.Category.CategoryId == id);
        }

        public bool CreateNewCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }
    }
}
