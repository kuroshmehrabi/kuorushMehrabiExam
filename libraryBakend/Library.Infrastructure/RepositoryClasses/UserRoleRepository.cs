using Library.Data.Models;
using Library.Infrastructure.RepositoryInterfaces;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Infrastructure.RepositoryInterfaces;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Infrastructure.RepositoryClasses
{
    public class UserRoleRepository : Repository<UserRole, int>, IUserRoleRepository
    {
        public UserRoleRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
