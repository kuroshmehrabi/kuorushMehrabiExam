using Library.Data;
using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.RepositoryInterfaces
{
    public interface IUserRepository : IRepository<User, int>
    {
       
    }
}
