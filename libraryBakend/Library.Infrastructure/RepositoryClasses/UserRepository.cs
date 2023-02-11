using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Data.Models;
using Library.Infrastructure.RepositoryInterfaces;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using Library.Infrastructure;

namespace Library.Infrastructure.RepositoryClasses
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        public UserRepository(Context dbContext) : base(dbContext)
        {
        }
    }
}
