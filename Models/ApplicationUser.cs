using System;

using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string Allergens { get; set; }
}




