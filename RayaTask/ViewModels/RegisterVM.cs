using System.ComponentModel.DataAnnotations;

namespace RayaTask.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Email Required")]
        [Display(Name ="Name")]
        [MinLength(8,ErrorMessage ="Name Min length 8 char"),MaxLength(50,ErrorMessage ="Name max length 50 char ")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Email Required")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [MinLength(6, ErrorMessage = "Min Length is 6 char")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Required")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
       
    }
}
