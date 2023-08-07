using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ToplantiProjem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int SurName { get; set; }
    }
}
