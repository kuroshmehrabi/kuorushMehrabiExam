using System.Collections.Generic;

namespace Library.Data;

public class City
{
    public int CityId { get; set; }
    public string CityName { get; set; } = null!;
    public int ProvinceId { get; set; }
    public virtual Province Province { get; set; } = null!;
}
