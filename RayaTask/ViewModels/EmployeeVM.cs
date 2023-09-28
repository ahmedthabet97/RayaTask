using System.ComponentModel.DataAnnotations;

namespace RayaTask.ViewModels
{
    public class EmployeeVM
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [MinLength(8,ErrorMessage ="Name Men Length is 8 char")]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Job is required")]
        public string Job { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        public double Salary { get; set; }
        public bool IsApproved { get; set; } = false;
    }
}
