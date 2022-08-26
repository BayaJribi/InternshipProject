using System.ComponentModel.DataAnnotations;

namespace Dashboard_DW_V2.ViewModel
{
    public class Login
    {
        [Required]
        [EmailAddress]
        [Display(Name ="Email")]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
