using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Financeiro.Application.DTOs
{
    public class PurchaseDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário preencher o nome")]
        [MinLength(3)]
        [MaxLength(50)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [MaxLength(100)]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "É necessário informar o preço")]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Preço")]
        public decimal Price { get; set; }        

        [MaxLength(10)]
        [Display(Name = "Parcelas")]
        public int Installments { get; set; }
    }
}