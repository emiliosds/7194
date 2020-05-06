using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Column("Id")]
        [DataType("int")]
        public int Id { get; set; }

        [Column("Title")]
        [DataType("nvarchar")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Esta campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Esta campo deve conter entre 3 e 60 caracteres")]
        public string Title { get; set; }

        [Column("Description")]
        [DataType("nvarchar")]
        [MaxLength(1024)]
        public string Description { get; set; }

        [Column("Price",TypeName = "decimal(18,4)")]
        [DataType("decimal")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }

        [Column("CategoryId")]
        [DataType("int")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}