namespace Database.Tables;

public class Loan
{
    public Guid Id { get; set; }

    public Guid BookId { get; set; }
    public virtual Book Book { get; set; }

    public Guid MemberId { get; set; }
    public virtual Member Member { get; set; }

    public DateTime LoanDate { get; set; }

    public DateTime? ReturnDate { get; set; }
    /*
o LoanId
o BookId
o MemberId
o LoanDate
o ReturnDate
     */
}