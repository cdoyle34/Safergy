using Microsoft.AspNetCore.Identity;
using System;
namespace SafErgyReal.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Allergies { get; set; }
    }
}


