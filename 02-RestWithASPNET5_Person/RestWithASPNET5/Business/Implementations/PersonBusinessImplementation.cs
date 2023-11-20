using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RestWithASPNET5.Context;
using RestWithASPNET5.Model;
using RestWithASPNET5.Repository;
using System;

namespace RestWithASPNET5.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
        }

        //Method responsible for creating a person
        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        //Method responsible for deleting a person from an Id
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        //Method responsible for return a list of person
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }


        //Method responsible for return a person from a ID
        public Person FindByID(long id)
        {
            return _repository.FindByID(id);
        }


        //Method responsible for Update a person information
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}