using System.Threading.Tasks;

namespace MangoBlog.Entity
{
    public interface ICategoryDao
    {
        Task<bool> AddCategoryAsync(string categoryName);
        Task<bool> DeleteCategoryAsync(string categoryName);
        Task<bool> DeleteCategoryAsync(int id);
        Task<string> GetCategoryByIdAsync(int id);
        Task<bool> IsExist(string categoryName);
    }
}
