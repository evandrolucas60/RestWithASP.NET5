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

        public User? ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, SHA256.Create());
            return _context.users.FirstOrDefault(u => (u.Username == user.Username) && (u.Password == pass));
        }

        public User? ValidateCredentials(string username)
        {
            return _context.users.SingleOrDefault(u => u.Username == username);
        }

        public bool RevokeToken(string username)
        {
            var user = _context.users.SingleOrDefault(u => (u.Username == username));
            if (user is null) return false;
            user.RefreshToken = null;
            _context.SaveChanges();
            return true;
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

        private string ComputeHash(string input, HashAlgorithm algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            var builder = new StringBuilder();
            foreach ( var b in hashedBytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }    
    }
}
