
using System.Collections.Generic;

namespace Library.DTO
{
    public class ProvinceDTO
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public List<CityDTO> Cities { get; set; }
    }
}