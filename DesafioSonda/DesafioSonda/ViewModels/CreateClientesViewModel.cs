using DesafioSonda.Domain.Core;
using DesafioSonda.Web.Utilities;
using System;
using System.ComponentModel.DataAnnotations;

namespace DesafioSonda.ViewModels
{
    public class CreateClientesViewModel
    {
        [Required(ErrorMessage = "O nome não pode ser vazio.")]
        [MinLength(40, ErrorMessage = "O nome deve ter no mínimo 40 caracteres.")]
        [MaxLength(250, ErrorMessage = "O nome deve ter no máximo 250 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O cpf não pode ser vazio.")]
        [RegularExpression(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})",
                        ErrorMessage = "O cpf informado não é válido.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "A data de nascimento não pode ser vazio.")]
        [Display(Name ="Data Nascimento")]
        [Maior18anos]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O sexo não pode ser vazio.")]
        public Sexo Sexo { get; set; }
    }
}