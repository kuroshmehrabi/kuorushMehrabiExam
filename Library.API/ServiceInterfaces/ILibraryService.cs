using Library.Data;
using Library.DTO;

namespace Library.Services.ServiceInterfaces
{
    public interface ILibraryService
    {
        Task<Libraryy> MapToEntity(LibraryDTO library);
        Task<LibraryDTO> MapToDTO(Libraryy library);
        Task<IEnumerable<LibraryDTO>> GetLibraries();
        Task<LibraryDTO> GetLibrary(int id);
        Task<LibraryDTO> AddLibrary(LibraryDTO library);
        Task RemoveLibrary(int libraryId);
        Task<LibraryDTO> UpdateLibrary(LibraryDTO library);
        Task<IEnumerable<LibraryDTO>> GetAllLibraryWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize);
    }
}
