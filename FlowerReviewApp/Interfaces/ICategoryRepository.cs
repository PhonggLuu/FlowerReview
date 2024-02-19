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
        bool IsReference(int id);
        bool CreateNewCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool Save();
    }
}
