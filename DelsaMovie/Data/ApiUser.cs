using Microsoft.AspNetCore.Identity;

namespace DelsaMovie.Data
{
    public class ApiUser:IdentityUser
    {
        public string FirstName { get; set; }   
        public string LastName { get; set; }    
    }
}
