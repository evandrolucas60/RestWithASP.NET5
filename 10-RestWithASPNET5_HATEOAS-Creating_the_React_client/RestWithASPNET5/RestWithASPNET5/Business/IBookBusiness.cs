using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Hypermedia.Utils;


namespace RestWithASPNET5.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindByID(long id);
        List<BookVO> FindAll();
        PagedSearchVO<BookVO> FindWithPagedSearch(
            string title, string sortDirection, int pageSize, int page);
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
