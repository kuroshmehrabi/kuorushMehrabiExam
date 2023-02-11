using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Infrastructure.RepositoryInterfaces;
using Library.Models;

namespace Library.Infrastructure.RepositoryClasses
{
    public class LibraryRepository : Repository<Libraryy, int>, ILibraryRepository
    {
        public LibraryRepository(Context dbContext) : base(dbContext) { }
    }
}
