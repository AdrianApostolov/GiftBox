namespace GiftBox.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int NeedId { get; set; }

        public virtual Need Need { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
