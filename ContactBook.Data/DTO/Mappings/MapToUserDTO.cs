using ContactBook.Model;

namespace ContactBook.Data.DTO.Mappings
{
    public class MapToUserDTO
    {
        public static UserDTO ToUserDTO(User user)
        {
            var dto =  new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AvatarUrl = user.AvatarUrl,
                PublicId = user.PublicId,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsActive = user.IsActive,
            };
            return dto;
        }

        
    }
}