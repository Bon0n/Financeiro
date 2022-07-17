using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Financeiro.Application.DTOs
{
    public class CardDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário preencher o nome")]
        [MinLength(3)]
        [MaxLength(50)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "É necessário preencher o número do cartão")]
        [MinLength(16)]
        [MaxLength(16)]
        [Display(Name = "Número do cartão")]
        public int Number { get; set; }
        public int Limit { get; set; }
    }
}