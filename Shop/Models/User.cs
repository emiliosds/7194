using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        [Column("Id")]
        [DataType("int")]
        public int Id { get; set; }

        [Column("Username")]
        [DataType("nvarchar")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter no entre 3 e 20 caracteres")]
        public string Username { get; set; }

        [Column("Password")]
        [DataType("nvarchar")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Esse campo deve ter entre 3 e 20 caracteres")]
        [MinLength(3, ErrorMessage = "Esse campo deve ter entre 3 e 20 caracteres")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}