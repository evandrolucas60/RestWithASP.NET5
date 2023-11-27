using RestWithASPNET5.Context;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;
using System.Security.Cryptography;
using System.Text;

namespace RestWithASPNET5.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
                
            return _context.users.FirstOrDefault(u => (u.Username == user.Username) && (u.Password == pass));
        }

        private string ComputeHash(string input, SHA256 algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}
