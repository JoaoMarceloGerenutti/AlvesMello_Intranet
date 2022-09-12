﻿using Microsoft.AspNetCore.Identity;

namespace AlvesMello_IntraNet.Models;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Photo { get; set; }
    public int TelephoneExtension { get; set; }
    public int AM { get; set; }
    public Department Department { get; set; }
}
