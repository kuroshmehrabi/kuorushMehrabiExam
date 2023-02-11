using Library.Data;
using Library.DTO;
using Library.Infrastructure;
using Library.Infrastructure.RepositoryInterfaces;
using Library.Services.ServiceInterfaces;

namespace Library.Services.ServiceClasses
{
    public class ProvinceService : IProvinceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProvinceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProvinceDTO> MapToDTO(Province province)
        {
            return new ProvinceDTO()
            {
                ProvinceId = province.ProvinceId,
                ProvinceName = province.ProvinceName
            };
        }

        public async Task<Province> MapToEntity(ProvinceDTO province)
        {
            return await Task.Run(() => new Province()
            {
                ProvinceId = province.ProvinceId,
                ProvinceName = province.ProvinceName,
            });
        }

        public async Task<ProvinceDTO> AddProvince(ProvinceDTO province)
        {
            var data = await MapToEntity(province);
            await _unitOfWork.ProvinceRepository.Add(data);
            return province;
        }

        public async Task<IEnumerable<ProvinceDTO>> GetProvinces()
        {
            var datas = await _unitOfWork.ProvinceRepository.GetAll();
            return datas != null && datas.Any() ? datas.Select(x => MapToDTO(x).Result).AsEnumerable() : null;
        }

        public async Task<ProvinceDTO> GetProvince(int provinceId)
        {
            var data = await _unitOfWork.ProvinceRepository.GetById(provinceId);
            return await MapToDTO(data);
        }

        public async Task RemoveProvince(int provinceId)
        {
            await _unitOfWork.ProvinceRepository.Delete(await _unitOfWork.ProvinceRepository.GetById(provinceId));
        }

        public async Task<ProvinceDTO> UpdateProvince(ProvinceDTO province)
        {
            var data = await _unitOfWork.ProvinceRepository.Add(await MapToEntity(province));
            _unitOfWork.Commit();
            return await MapToDTO(data);
        }

        public async Task<IEnumerable<ProvinceDTO>> GetAllProvinceWithPagination(string sortOrder, string currentFilter, string searchString, int? page, int? pageSize)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            var provinces = await _unitOfWork.ProvinceRepository.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                provinces = provinces.Where(s => s.ProvinceName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {   
                case "name_desc":
                    provinces = provinces.OrderByDescending(s => s.ProvinceName);
                    break;
                default:
                    provinces = provinces.OrderBy(s => s.ProvinceName);
                    break;
            }
            pageSize = pageSize.HasValue ? pageSize : 0;
            int pageNumber = (page ?? 1);
            provinces = provinces.Skip(pageSize.Value * pageNumber).Take(pageSize.Value);
            return provinces != null && provinces.Any() ? provinces.Select(x => MapToDTO(x).Result).AsEnumerable() : null;
        }
    }
}
