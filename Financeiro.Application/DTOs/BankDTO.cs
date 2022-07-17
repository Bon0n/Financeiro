using System.ComponentModel.DataAnnotations;

namespace Financeiro.Application.DTOs
{
    public class BankDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário preencher o Nome")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }          
    }
}