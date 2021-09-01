namespace DevCA.Business.Model
{
    public class Reserve : Entity
    {
        public long UserId { get; set; }

        public long BookId { get; set; }

        public long Returned { get; set; }

        public User User { get; set; }

        public Book Book { get; set; }
    }
}