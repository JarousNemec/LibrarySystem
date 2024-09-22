namespace Database.Tables;

public class Member
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime MembershipDate { get; set; }
    
    public string UserId { get; set; }
    /*
o MemberId
o FirstName
o LastName
o Email
o MembershipDate
    */
}