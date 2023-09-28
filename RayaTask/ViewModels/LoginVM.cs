using System.ComponentModel.DataAnnotations;

namespace RayaTask.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Email is required")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
