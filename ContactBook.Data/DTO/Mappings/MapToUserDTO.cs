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
                Username = user.UserName,
                AvatarUrl = user.AvatarUrl,
                PublicId = user.PublicId,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsActive = user.IsActive,
                Token = user.Token
            };
            return dto;
        }

        public static UserResponseDTO ToUserResponseDTO(User user)
        {
            var dto = new UserResponseDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
                AvatarUrl = user.AvatarUrl,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Token = user.Token
            };
            return dto;
        }
        public static User ToUserRegistrationDTO(RegistrationRequestDTO user)
        {
            var dto = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username, 
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Password = user.PassWord,
                UserName = user.Username,
            };
            return dto;
        }
    }
}