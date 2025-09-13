using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteApi.Models
{
    [Table("Funcionarios")]
    public class funcionario
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Esta anotação faz a chave ser auto incrementada
        public int Id { get; set; }
        [Required]
        public string MyName { get; set; }
        [Required]
        public double MyCpf { get; set; }
        [Required]
        public string Myemail { get; set; }
        [Required]

        public string Mybirthdate { get; set; }
        [Required]
        public string Myferias { get; set; }
        [Required]
        public int MyPhone { get; set; }
        [Required]
        public double MySalario { get; set; }        
        [Required]
       
        public string MyCargo { get; set; }

        


    }
}
