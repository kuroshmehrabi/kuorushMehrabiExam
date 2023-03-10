using System.Collections.Generic;

namespace Library.Data.Models
{
    public class UserRole
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; } = new List<User>();
    }
}