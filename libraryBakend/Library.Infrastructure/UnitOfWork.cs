using Library.Infrastructure.RepositoryClasses;
using Library.Infrastructure.RepositoryInterfaces;
using Library.Models;

namespace Library.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue;
        private ICategoryRepository _categoryRepository;
        private ILibraryRepository _libraryRepository;
        private IUserRepository _userRepository;
        private IUserRoleRepository _userRoleRepository;
        private IProvinceRepository _provinceRepository;
        private Context _dbContext;

        public Context DbContext
        {
            get
            {
                if (_dbContext == null)
                    _dbContext = new Context();
                return _dbContext;
            }
        }
        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(DbContext);
                return _categoryRepository;
            }
        }
        public ILibraryRepository LibraryRepository
        {
            get
            {
                if (_libraryRepository == null)
                    _libraryRepository = new LibraryRepository(DbContext);
                return _libraryRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(DbContext);
                return _userRepository;
            }
        }

        public IUserRoleRepository UserRoleRepository
        {
            get
            {
                if (_userRoleRepository == null)
                    _userRoleRepository = new UserRoleRepository(DbContext);
                return _userRoleRepository;
            }
        }
        public IProvinceRepository ProvinceRepository
        {
            get
            {
                if (_provinceRepository == null)
                    _provinceRepository = new ProvinceRepository(DbContext);
                return _provinceRepository;
            }
        }

        public async Task Commit() => await DbContext.SaveChangesAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
