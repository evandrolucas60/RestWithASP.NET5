using RestWithASPNET5.Hypermedia;
using RestWithASPNET5.Hypermedia.Abstract;

namespace RestWithASPNET5.Model
{
    public class BookVO : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public string Title { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
