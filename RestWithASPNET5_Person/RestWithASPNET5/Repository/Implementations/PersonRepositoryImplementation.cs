using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestWithASPNET5.Context;
using RestWithASPNET5.Model;
using System;

namespace RestWithASPNET5.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepositoryImplementation(ApplicationDbContext context)
        {
            _context = context;
        }

        //Method responsible for creating a person
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception )
            {

                throw;
            }
            
            return person;
        }

        //Method responsible for deleting a person from an Id
        public void Delete(long id)
        {
            var result = _context.persons.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        //Method responsible for return a list of person
        public List<Person> FindAll()
        {
           return _context.persons.ToList();
        }


        //Method responsible for return a person from a ID
        public Person FindByID(long id)
        {
            return _context.persons.SingleOrDefault(p => p.Id.Equals(id));
        }


        //Method responsible for Update a person information
        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;

            var result = _context.persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            

            return person;
        }

        //Method responsible for verify if exists a person by your Id
        public bool Exists(long id)
        {
            return _context.persons.Any(p => p.Id.Equals(id));
        }
    }
}
