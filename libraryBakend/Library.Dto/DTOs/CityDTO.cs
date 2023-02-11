namespace Library.DTO
{
    public class CityDTO
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public ProvinceDTO Province { get; set; }
    }
}
