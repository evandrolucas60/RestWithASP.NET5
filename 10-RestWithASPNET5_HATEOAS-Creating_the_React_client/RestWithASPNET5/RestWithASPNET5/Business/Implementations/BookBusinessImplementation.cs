using RestWithASPNET5.Data.Converter.Implementations;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Hypermedia.Utils;
using RestWithASPNET5.Model;
using RestWithASPNET5.Repository;

namespace RestWithASPNET5.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookBusinessImplementation(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        // Method responsible for returning all people,
        List<BookVO> IBookBusiness.FindAll()
        {
            return _converter.Parse(_repository.FindAll()); ;
        }

        PagedSearchVO<BookVO> IBookBusiness.FindWithPagedSearch(string title, string sortDirection, int pageSize, int page)
        {
            var sort = (!string.IsNullOrWhiteSpace(sortDirection)) && !sortDirection.Equals("desc") ? "asc" : "desc";
            var size = (pageSize < 1) ? 10 : pageSize;
            var offset = page > 0 ? (page - 1) * size : 0;

            string query = @"select * from books p where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(title)) query = query + $" and p.Title like '%{title}%' ";
            query += $" order by p.Title {sort} OFFSET {offset} ROWS FETCH NEXT {size} ROWS ONLY";

            string countQuery = @"select count(*) from books p where 1 = 1 ";
            if (!string.IsNullOrWhiteSpace(title)) countQuery = countQuery + $" and p.Title like '%{title}%' ";

            var books = _repository.FindWithPagedSearch(query);
            int totalResults = _repository.GetCount(countQuery);

            return new PagedSearchVO<BookVO>
            {
                CurrentPage = page,
                List = _converter.Parse(books),
                PageSize = size,
                SortDirections = sort,
                TotalResults = totalResults
            };
        }

        // Method responsible for returning one book by ID
        BookVO IBookBusiness.FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        // Method responsible to crete one new book
        public BookVO Create(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        // Method responsible for updating one book
        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }

        // Method responsible for deleting a book from an ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
          
    }
}