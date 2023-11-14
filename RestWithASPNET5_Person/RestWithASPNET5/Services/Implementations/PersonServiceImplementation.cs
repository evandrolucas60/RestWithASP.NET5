using RestWithASPNET5.Context;
using RestWithASPNET5.Model;

namespace RestWithASPNET5.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private readonly ApplicationDbContext _context;

        public PersonServiceImplementation(ApplicationDbContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
           return _context.persons.ToList();
        }


        public Person FindByID(long id)
        {
           return new Person 
           { 
            Id = 1,
            FirstName = "Evandro",
            LastName = "Lucas",
            Address = "Jaboatão dos guararapes - PE",
            Gender = "Male"
           };
        }

        public Person Update(Person person)
        {
            return person;
        }

    }
}
