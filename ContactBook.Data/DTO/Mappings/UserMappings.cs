using ContactBook.Model;

namespace ContactBook.Data.DTO.Mappings
{
    public class UserMappings
    {
        public static UserResponseDTO GetUserResponse(User user)
        {
            return new UserResponseDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
        }

        public static User GetUser(RegistrationRequestDTO registrationRequest)
        {
            return new User
            {
                FirstName = registrationRequest.FirstName,
                LastName = registrationRequest.LastName,
                Email = registrationRequest.Email,
                PhoneNumber = registrationRequest.PhoneNumber,
                UserName = string.IsNullOrWhiteSpace(registrationRequest.UserName) ? registrationRequest.Email : registrationRequest.UserName,
            };
        }
    }
}
