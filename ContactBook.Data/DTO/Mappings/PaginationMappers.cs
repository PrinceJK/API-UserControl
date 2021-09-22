using ContactBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Data.DTO.Mappings
{
    public class PaginationMappers
    {
        public static ICollection<UserDTO> ForUsers(IEnumerable<User> users)
        {
            var result = new List<UserDTO>();
            foreach (var user in users)
            {
                result.Add(new UserDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    IsActive= user.IsActive,
                    AvatarUrl = user.AvatarUrl,
                    PublicId = user.PublicId,
                    CreatedAt = user.CreatedAt,
                    UpdatedAt = user.UpdatedAt,
                });
            }
            return result;
        }
    }
}

