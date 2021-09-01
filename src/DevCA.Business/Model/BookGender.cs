namespace DevCA.Business.Model
{
    public class BookGender : Entity
    {
        public long BookId { get; set; }
        
        public string Name { get; set; }

        public Book Book { get; set; }
    }
}