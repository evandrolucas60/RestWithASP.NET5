using RestWithASPNET5.Model.Base;

namespace RestWithASPNET5.Model
{
    public class Book : BaseEntity
    {
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
    }
}
