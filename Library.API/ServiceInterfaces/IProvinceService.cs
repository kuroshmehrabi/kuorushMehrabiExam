using Library.Data;
using Library.DTO;

namespace Library.Services.ServiceInterfaces
{
    public interface IProvinceService
    {
        Task<Province> MapToEntity(ProvinceDTO province);
        Task<ProvinceDTO> MapToDTO(Province province);
        Task<IEnumerable<ProvinceDTO>> GetProvinces();
        Task<ProvinceDTO> GetProvince(int provinceId);
        Task<ProvinceDTO> AddProvince(ProvinceDTO province);
        Task RemoveProvince(int provinceId);
        Task<ProvinceDTO> UpdateProvince(ProvinceDTO province);
        Task<IEnumerable<ProvinceDTO>> GetAllProvinceWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize);
    }
}
