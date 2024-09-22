namespace Database.Tables;

public class Book
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public Guid AuthorId { get; set; }
    public virtual Author Author { get; set; }

    public Guid GenreId { get; set; }
    public virtual Genre Genre { get; set; }

    public DateOnly PublishedDate { get; set; }

    public string Isbn { get; set; }
    /*
o BookId
o Title
o AuthorId
o GenreId
o PublishedDate
o ISBN
     */
}