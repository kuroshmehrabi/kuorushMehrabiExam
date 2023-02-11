using Library.Infrastructure.RepositoryInterfaces;
using Library.Models;

namespace Library.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
        Context DbContext { get; }

        ILibraryRepository LibraryRepository { get; }

        IUserRepository UserRepository { get; }

        IUserRoleRepository UserRoleRepository { get; }
        IProvinceRepository ProvinceRepository { get; }
    }
}
