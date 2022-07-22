using System.ComponentModel.DataAnnotations;
using Financeiro.Domain.Entities;

namespace Financeiro.Application.DTOs
{
    public class BankDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário preencher o Nome")]
        [MinLength(3)]
        [MaxLength(100)]
        [Display(Name = "Nome")]
        public string Name { get; set; } 
        public int PersonId { get; set; }
        [Display(Name = "Pessoa")]
        public Person Person { get; set; }         
    }
}