using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financeiro.Application.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário preencher o nome")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Pessoa")]
        public string Name { get; set; }

        
        [Required(ErrorMessage = "É necessário informar renda")]
        [Column(TypeName = "decimal(15,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Renda")]
        public decimal? Income { get; set; }
        
        
        [DisplayName("Banco")]
        public BankDTO Bank { get; set; }
        public int BankId { get; set; }
        
    }
}