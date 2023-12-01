using RestWithASPNET5.Context;
using RestWithASPNET5.Model;
using RestWithASPNET5.Repository.Generic;

namespace RestWithASPNET5.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Person Disable(long id)
        {
            if (!_context.persons.Any(p => p.Id.Equals(id))) return null;
            var user = _context.persons.SingleOrDefault(p => p.Id.Equals(id));
            if (user != null)
            {
                user.Enabled = false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return user;
        }
    }
}
