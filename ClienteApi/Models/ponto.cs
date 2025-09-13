using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClienteApi.Models.Ponto
{
    [Table("Ponto")]
    public class ponto
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Esta anotação faz a chave ser auto incrementada
        public int PontoId { get; set; }// Valor inicial negativo // Chave primária auto incrementada

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public DateTime? Entrada { get; set; }
        public DateTime? Saida { get; set; }
    }
}
