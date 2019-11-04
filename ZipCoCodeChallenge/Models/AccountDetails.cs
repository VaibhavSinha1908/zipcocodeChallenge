using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZipCoCodeChallenge.Models
{
    public class AccountDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }

        
        public int UserId { get; set; }


        public UserDetails User { get; set; }
        public bool IsActive { get; set; }
    }
}
