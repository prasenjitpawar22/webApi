


namespace MyWebAPICore.Models;

public class Contacts
{
    public Guid Id { get; set; }
    public String FullName { get; set; }
    public String Email { get; set; }
    public long Phone { get; set; }
    public String Address { get; set; }
    public int Age { get; set; }
}