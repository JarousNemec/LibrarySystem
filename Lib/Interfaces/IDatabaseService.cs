using Database.Tables;

namespace Lib.Interfaces;

public interface IDatabaseService
{
    #region tables CRUD

    bool CreateBook(Book book);
    Book? ReadBook(Guid id);
    bool UpdateBook(Book book);
    bool DeleteBook(Guid id);

    bool CreateAuthor(Author author);
    Author? ReadAuthor(Guid id);
    bool UpdateAuthor(Author author);
    bool DeleteAuthor(Guid id);

    bool CreateGenre(Genre genre);
    Genre? ReadGenre(Guid id);
    bool UpdateGenre(Genre genre);
    bool DeleteGenre(Guid id);

    bool CreateMember(Member member);
    Member? ReadMember(Guid id);
    bool UpdateMember(Member member);
    bool DeleteMember(Guid id);

    bool CreateLoan(Loan loan);
    Loan? ReadLoan(Guid id);
    bool UpdateLoan(Loan loan);
    bool DeleteLoan(Guid id);

    bool CreateReview(Review review);
    Review? ReadReview(Guid id);
    bool UpdateReview(Review review);
    bool DeleteReview(Guid id);

    #endregion

    #region tables special actions

    Book?[] GetBooksByName(string text);
    Book?[] GetBooksByAuthor(Guid id);
    Book?[] GetBooksByGenre(Guid id);

    Book?[] ReadAllBooks();

    Loan?[] GetMemberLoans(Guid memberId);

    //reviews
    Review?[] GetAllBookReviews(Guid bookId);
    
    //users
    Member? GetMemberByUserId(string userId);

    #endregion
}