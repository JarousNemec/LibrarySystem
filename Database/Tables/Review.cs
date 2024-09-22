namespace Database.Tables;

public class Review
{
    public Guid Id { get; set; }

    public Guid BookId { get; set; }
    public virtual Book Book { get; set; }

    public Guid MemberId { get; set; }
    public virtual Member Member { get; set; }

    public float Rating { get; set; }

    public string Comment { get; set; }

    public DateTime ReviewDate { get; set; }
    /*
o ReviewId
o BookId
o MemberId
o Rating
o Comment
o ReviewDate
     */
}