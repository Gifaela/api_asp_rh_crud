using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClienteApi.Models.Login
{
    [Table("Login")]
    public class login
    {

        [Key]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]

        public string Password { get; set; }

    }
}
