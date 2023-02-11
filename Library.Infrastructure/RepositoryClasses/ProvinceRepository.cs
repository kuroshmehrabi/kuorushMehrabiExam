using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Infrastructure.RepositoryInterfaces;
using Library.Models;

namespace Library.Infrastructure.RepositoryClasses
{
    public class ProvinceRepository : Repository<Province, int>, IProvinceRepository
    {
        public ProvinceRepository(Context dbContext) : base(dbContext) { }
    }
}
