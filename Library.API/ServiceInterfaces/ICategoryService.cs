using Library.Data;
using Library.DTO;

namespace Library.Services.ServiceInterfaces
{
    public interface ICategoryService
    {
        Task<Category> MapToEntity(CategoryDTO category);
        Task<CategoryDTO> MapToDTO(Category category);
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategory(int id);
        Task<CategoryDTO> AddCategory(CategoryDTO category);
        Task RemoveCategory(int category);
        Task<CategoryDTO> UpdateCategory(CategoryDTO category);
        Task<IEnumerable<CategoryDTO>> GetAllCategoryWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize);
    }
}
