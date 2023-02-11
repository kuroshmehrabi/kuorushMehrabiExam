using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Infrastructure.RepositoryInterfaces;
using Library.Models;

namespace Library.Infrastructure.RepositoryClasses
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {

        public CategoryRepository(Context dbContext) : base(dbContext) { }
    }
}