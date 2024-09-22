using System.Diagnostics;
using Database;
using Database.Tables;
using Lib.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Lib.Services;

public class DatabaseService : IDatabaseService
{
    private readonly ApplicationDbContext _database;

    public DatabaseService(ApplicationDbContext database)
    {
        _database = database;
    }
    public bool CreateBook(Book book)
    {
        Guid id = Guid.NewGuid();
        book.Id = id;
        try
        {
            _database.Books.Add(book);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public Book? ReadBook(Guid id)
    {
        return _database.Books.Include(x => x.Author).Include(x => x.Genre).FirstOrDefault(x => x.Id == id);
    }

    public bool UpdateBook(Book book)
    {
        try
        {
            var target = _database.Books.FirstOrDefault(x => x.Id == book.Id);
            if (target == null)
                return false;

            target.Title = book.Title;
            target.Isbn = book. Isbn;
            target.AuthorId = book.AuthorId;
            target.GenreId = book.GenreId;
            target.PublishedDate = book.PublishedDate;
            
            _database.Books.Update(target);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public bool DeleteBook(Guid id)
    {
        try
        {
            var target = _database.Books.FirstOrDefault(x => x.Id == id);
            if (target == null)
                return false;
            _database.Books.Remove(target);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public bool CreateAuthor(Author author)
    {
        Guid id = Guid.NewGuid();
        author.Id = id;
        try
        {
            _database.Authors.Add(author);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public Author? ReadAuthor(Guid id)
    {
        return _database.Authors.FirstOrDefault(x => x.Id == id);
    }

    public bool UpdateAuthor(Author author)
    {
        try
        {
            var target = _database.Authors.FirstOrDefault(x => x.Id == author.Id);
            if (target == null)
                return false;

            target.Name = author.Name;
            target.Bio = author.Bio;
            
            _database.Authors.Update(target);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public bool DeleteAuthor(Guid id)
    {
        try
        {
            var target = _database.Authors.FirstOrDefault(x => x.Id == id);
            if (target == null)
                return false;
            _database.Authors.Remove(target);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public bool CreateGenre(Genre genre)
    {
        Guid id = Guid.NewGuid();
        genre.Id = id;
        try
        {
            _database.Genres.Add(genre);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public Genre? ReadGenre(Guid id)
    {
        return _database.Genres.FirstOrDefault(x => x.Id == id);
    }

    public bool UpdateGenre(Genre genre)
    {
        try
        {
            var target = _database.Genres.FirstOrDefault(x => x.Id == genre.Id);
            if (target == null)
                return false;

            target.Name = genre.Name;
            
            _database.Genres.Update(target);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public bool DeleteGenre(Guid id)
    {
        try
        {
            var target = _database.Genres.FirstOrDefault(x => x.Id == id);
            if (target == null)
                return false;
            _database.Genres.Remove(target);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public bool CreateMember(Member member)
    {
        Guid id = Guid.NewGuid();
        member.Id = id;
        
        try
        {
            _database.Members.Add(member);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public Member? ReadMember(Guid id)
    {
        return _database.Members.FirstOrDefault(x => x.Id == id);
    }

    public bool UpdateMember(Member member)
    {
        try
        {
            var target = _database.Members.FirstOrDefault(x => x.Id == member.Id);
            if (target == null)
                return false;

            target.UserId = member.UserId;
            target.Email = member.Email;
            target.FirstName = member.FirstName;
            target.LastName = member.LastName;
            target.MembershipDate = member.MembershipDate;
            
            _database.Members.Update(target);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public bool DeleteMember(Guid id)
    {
        try
        {
            var target = _database.Members.FirstOrDefault(x => x.Id == id);
            if (target == null)
                return false;
            _database.Members.Remove(target);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public bool CreateLoan(Loan loan)
    {
        Guid id = Guid.NewGuid();
        loan.Id = id;
        
        try
        {
            _database.Loans.Add(loan);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public Loan? ReadLoan(Guid id)
    {
        return _database.Loans.Include(x => x.Book).Include(x => x.Member).FirstOrDefault(x => x.Id == id);
    }

    public bool UpdateLoan(Loan loan)
    {
        try
        {
            var target = _database.Loans.FirstOrDefault(x => x.Id == loan.Id);
            if (target == null)
                return false;

            target.MemberId = loan.MemberId;
            target.BookId = loan.BookId;
            target.LoanDate = loan.LoanDate;
            target.ReturnDate = loan.ReturnDate;
            
            _database.Loans.Update(target);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public bool DeleteLoan(Guid id)
    {
        try
        {
            var target = _database.Loans.FirstOrDefault(x => x.Id == id);
            if (target == null)
                return false;
            _database.Loans.Remove(target);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public bool CreateReview(Review review)
    {
        Guid id = Guid.NewGuid();
        review.Id = id;
        
        try
        {
            _database.Reviews.Add(review);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public Review? ReadReview(Guid id)
    {
        return _database.Reviews.Include(x => x.Book).Include(x => x.Member).FirstOrDefault(x => x.Id == id);
    }

    public bool UpdateReview(Review review)
    {
        try
        {
            var target = _database.Reviews.FirstOrDefault(x => x.Id == review.Id);
            if (target == null)
                return false;

            target.MemberId = review.MemberId;
            target.BookId = review.BookId;
            target.Comment = review.Comment;
            target.Rating = review.Rating;
            target.ReviewDate = review.ReviewDate;
            
            _database.Reviews.Update(target);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public bool DeleteReview(Guid id)
    {
        try
        {
            var target = _database.Reviews.FirstOrDefault(x => x.Id == id);
            if (target == null)
                return false;
            _database.Reviews.Remove(target);
            _database.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            return false;
        }
    }

    public Book?[] GetBooksByName(string text)
    {
        return _database.Books.Include(x => x.Author).Include(x => x.Genre).Where(x => x.Title.Contains(text)).ToArray();
    }

    public Book?[] GetBooksByAuthor(Guid id)
    {
        return _database.Books.Include(x => x.Author).Include(x => x.Genre).Where(x => x.AuthorId == id).ToArray();
    }

    public Book?[] GetBooksByGenre(Guid id)
    {
        return _database.Books.Include(x => x.Author).Include(x => x.Genre).Where(x => x.GenreId == id).ToArray();
    }

    public Book?[] ReadAllBooks()
    {
        return _database.Books.Include(x => x.Author).Include(x => x.Genre).ToArray();
    }

    public Loan?[] GetMemberLoans(Guid memberId)
    {
        return _database.Loans.Include(x => x.Book).Include(x => x.Member).Where(x => x.MemberId == memberId).ToArray();
    }

    public Review?[] GetAllBookReviews(Guid bookId)
    {
        return _database.Reviews.Include(x => x.Book).Include(x => x.Member).Where(x => x.BookId == bookId).ToArray();
    }

    public Member? GetMemberByUserId(string userId)
    {
        return _database.Members.FirstOrDefault(x => x.UserId == userId);
    }
}