using ContactBook.Model;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ContactBook.Core.Interfaces
{
    public interface ITokenGenerator
    {
        Task<string> GenerateToken(User user, IConfiguration _configuration);
    }
}
