using FlowerReviewApp.Models;

namespace FlowerReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        Category GetCategory(string name);
        ICollection<Product> GetProductsByCategory(int categoryId);
        bool IsCategoryExists(int id);
        bool CreateNewCategory(Category category);
        bool Save();
    }
}
