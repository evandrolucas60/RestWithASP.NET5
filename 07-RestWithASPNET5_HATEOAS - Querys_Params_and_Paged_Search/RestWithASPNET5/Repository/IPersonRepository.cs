using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Model;

namespace RestWithASPNET5.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
    }
}
