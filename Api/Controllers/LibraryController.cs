using Database.Tables;
using Lib.Interfaces;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class LibraryController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDatabaseService _database;

    public LibraryController(ILogger<HomeController> logger, IDatabaseService database)
    {
        _logger = logger;
        _database = database;
    }

    #region CRUD

    //member
    [HttpPost]
    public IActionResult CreateMember([FromBody] Member member)
    {
        return StatusCode(_database.CreateMember(member) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    public IActionResult GetMember(Guid id)
    {
        return Ok(_database.ReadMember(id));
    }

    [HttpPost]
    public IActionResult UpdateMember([FromBody] Member member)
    {
        return StatusCode(_database.UpdateMember(member) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    [HttpPost]
    public IActionResult DeleteMember(Guid id)
    {
        return StatusCode(_database.DeleteMember(id) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    //book
    [HttpPost]
    public IActionResult CreateBook([FromBody] Book book)
    {
        return StatusCode(_database.CreateBook(book) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    public IActionResult GetBook(Guid id)
    {
        return Json(_database.ReadBook(id));
    }

    [HttpPost]
    public IActionResult UpdateBook([FromBody] Book book)
    {
        return StatusCode(_database.UpdateBook(book) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    [HttpPost]
    public IActionResult DeleteBook(Guid id)
    {
        return StatusCode(_database.DeleteBook(id) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    //author
    [HttpPost]
    public IActionResult CreateAuthor([FromBody] Author author)
    {
        return StatusCode(_database.CreateAuthor(author) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    public IActionResult GetAuthor(Guid id)
    {
        return Json(_database.ReadAuthor(id));
    }

    [HttpPost]
    public IActionResult UpdateAuthor([FromBody] Author author)
    {
        return StatusCode(_database.UpdateAuthor(author) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    [HttpPost]
    public IActionResult DeleteAuthor(Guid id)
    {
        return StatusCode(_database.DeleteAuthor(id) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    //genre
    [HttpPost]
    public IActionResult CreateGenre([FromBody] Genre genre)
    {
        return StatusCode(_database.CreateGenre(genre) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    public IActionResult GetGenre(Guid id)
    {
        return Json(_database.ReadGenre(id));
    }

    [HttpPost]
    public IActionResult UpdateGenre([FromBody] Genre genre)
    {
        return StatusCode(_database.UpdateGenre(genre) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    [HttpPost]
    public IActionResult DeleteGenre(Guid id)
    {
        return StatusCode(_database.DeleteGenre(id) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    //loan
    [HttpPost]
    public IActionResult CreateLoan([FromBody] Loan loan)
    {
        return StatusCode(_database.CreateLoan(loan) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    public IActionResult GetLoan(Guid id)
    {
        return Json(_database.ReadLoan(id));
    }

    [HttpPost]
    public IActionResult UpdateLoan([FromBody] Loan loan)
    {
        return StatusCode(_database.UpdateLoan(loan) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    [HttpPost]
    public IActionResult DeleteLoan(Guid id)
    {
        return StatusCode(_database.DeleteLoan(id) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    //review
    [HttpPost]
    public IActionResult CreateReview([FromBody] Review review)
    {
        return StatusCode(_database.CreateReview(review) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    public IActionResult GetReview(Guid id)
    {
        return Json(_database.ReadReview(id));
    }

    [HttpPost]
    public IActionResult UpdateReview([FromBody] Review review)
    {
        return StatusCode(_database.UpdateReview(review) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    [HttpPost]
    public IActionResult DeleteReview(Guid id)
    {
        return StatusCode(_database.DeleteReview(id) ? StatusCodes.Status200OK : StatusCodes.Status410Gone);
    }

    #endregion


    //books
    public IActionResult GetBooksByName(string text)
    {
        if (string.IsNullOrEmpty(text))
            return BadRequest();
        return Json(_database.GetBooksByName(text));
    }

    public IActionResult GetBooksByAuthor(Guid id)
    {
        return Json(_database.GetBooksByGenre(id));
    }

    public IActionResult GetBooksByGenre(Guid id)
    {
        return Json(_database.GetBooksByGenre(id));
    }

    public IActionResult GetAllBooks()
    {
        return Json(_database.ReadAllBooks());
    }

    public IActionResult GetMemberLoanedBooks(Guid memberId)
    {
        return Json(_database.GetMemberLoans(memberId));
    }

    //reviews
    public IActionResult GetAllBookReviews(Guid bookId)
    {
        return Json(_database.GetAllBookReviews(bookId));
    }
    
    //users
    public IActionResult GetMemberByUserId(string userId)
    {
        return Json(_database.GetMemberByUserId(userId));
    }
}