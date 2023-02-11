using Library.DTO;
using System.Collections.Generic;

namespace MLibrary.DTO
{
    public class UserRoleDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<UserDTO> Users { get; set; }
    }
}
