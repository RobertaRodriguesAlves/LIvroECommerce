using System.ComponentModel.DataAnnotations;

namespace LivrosECommerce.Models
{
    public class Cadastro : BaseModel
    {
        public Cadastro() { }

        public virtual Pedido Pedido { get; set; }
        [Required(ErrorMessage ="Campo obrigatório")]
        public string Nome { get; set; } = "";
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Email { get; set; } = "";
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Telefone { get; set; } = "";
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Endereco { get; set; } = "";
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Complemento { get; set; } = "";
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Bairro { get; set; } = "";
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Municipio { get; set; } = "";
        [Required(ErrorMessage = "Campo obrigatório")]
        public string UF { get; set; } = "";
        [Required(ErrorMessage = "Campo obrigatório")]
        public string CEP { get; set; } = "";
    }
}
