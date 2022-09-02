

namespace MyWebAPICore.Models;
public class AddContactRequest
{
    public String FullName { get; set; }
    public String Email { get; set; }
    public long Phone { get; set; }
    public String Address { get; set; }
}