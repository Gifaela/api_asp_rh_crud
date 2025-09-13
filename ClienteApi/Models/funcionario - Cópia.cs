using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteApi.Models
{
    [Table("Funcionarios")]
    public class funcionario
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string MyName { get; set; }
        [Required]
        public double MyCpf { get; set; }
        [Required]
        public string Myemail { get; set; }
        [Required]
        [EmailAddress]
        public string Mybirthdate { get; set; }
        [Required]
        public string Myferias { get; set; }

        public int MyPhone { get; set; }
        


    }
}
