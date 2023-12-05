using RestWithASPNET5.Data.Converter.Implementations;
using RestWithASPNET5.Model;
using RestWithASPNET5.Repository;
using System;

namespace RestWithASPNET5.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _coverter;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _coverter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            var bookEntity = _coverter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _coverter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BookVO> FindAll()
        {
            return _coverter.Parse(_repository.FindAll());
        }

        public BookVO FindByID(long id)
        {
            return _coverter.Parse(_repository.FindByID(id));
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _coverter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _coverter.Parse(bookEntity);
        }
    }
}