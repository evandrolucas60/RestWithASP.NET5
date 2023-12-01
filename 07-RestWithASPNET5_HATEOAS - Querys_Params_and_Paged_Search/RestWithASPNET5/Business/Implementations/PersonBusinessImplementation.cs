using RestWithASPNET5.Data.Converter.Implementations;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;
using RestWithASPNET5.Repository;
using System;

namespace RestWithASPNET5.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IPersonRepository _repository;
        private readonly PersonConverter _coverter;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
            _coverter = new PersonConverter();
        }

        //Method responsible for creating a person
        public PersonVO Create(PersonVO person)
        {
            var personEntity = _coverter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _coverter.Parse(personEntity);
        }

        //Method responsible for deleting a PersonVO from an Id
        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        //Method responsible for return a list of PersonVO
        public List<PersonVO> FindAll()
        {
            return _coverter.Parse(_repository.FindAll());
        }


        //Method responsible for return a PersonVO from a ID
        public PersonVO FindByID(long id)
        {
            return _coverter.Parse(_repository.FindByID(id));
        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _coverter.Parse(_repository.FindByName(firstName, lastName));
        }


        //Method responsible for Update a PersonVO information
        public PersonVO Update(PersonVO person)
        {
            var personEntity = _coverter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _coverter.Parse(personEntity);
        }

        //Method responsible for disable a person from an ID
        public PersonVO Disable(long id)
        {
            var personEntity = _repository.Disable(id);
            return _coverter.Parse(personEntity);
        }
    }
}