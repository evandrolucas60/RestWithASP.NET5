using RestWithASPNET5.Context;
using RestWithASPNET5.Model;
using System;

namespace RestWithASPNET5.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepositoryImplementation(ApplicationDbContext context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return book;
        }

        public void Delete(long id)
        {
           var result = _context.books.SingleOrDefault(b => b.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }


        public List<Book> FindAll()
        {
            return _context.books.ToList();
        }

        public Book FindByID(long id)
        {
            return _context.books.SingleOrDefault(b => b.Id.Equals(id));
        }

        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return null;

            var result = _context.persons.SingleOrDefault(b => b.Id.Equals(book.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return book;
        }

        public bool Exists(long id)
        {
            return _context.books.Any(b => b.Id.Equals(id));
        }
    }
}
