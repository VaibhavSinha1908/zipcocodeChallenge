using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZipCoCodeChallenge.Models
{
    public class UserDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "The name is required.")]
        [StringLength(100)]
        public string Name { get; set; }


        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "The email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Monthly Salary")]
        [Required(ErrorMessage = "The monthly salary is required.")]
        [DataType(DataType.Currency)]
        public decimal MonthlySalary { get; set; }


        [Display(Name = "Monthly Expense")]
        [Required(ErrorMessage = "The monthly expense is required.")]
        [DataType(DataType.Currency)]
        public decimal MonthlyExpense { get; set; }

    }
}
