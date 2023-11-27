using Microsoft.EntityFrameworkCore;
using RestWithASPNET5.Context;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;
using System.Data;
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

        public User RefreshUserInfo(User user)
        {

            if (!_context.users.Any(u => u.Id.Equals(user.Id))) return null;

            var result = _context.users.SingleOrDefault(p => p.Id.Equals(user.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return result;
        }

        private string ComputeHash(string input, SHA256 algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }
    }
}
