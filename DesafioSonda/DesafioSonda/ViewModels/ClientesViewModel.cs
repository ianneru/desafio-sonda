using DesafioSonda.Domain.Core;
using System;

namespace DesafioSonda.ViewModels
{
    public class ClientesViewModel
    {
        public Guid Identificador { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public Sexo Sexo { get; set; }

        public DateTime DataNascimento { get; set; }

        public ClientesViewModel()
        { }

        public ClientesViewModel(Guid identificador, string nome, string cpf, Sexo sexo)
        {
            Identificador = identificador;
            Nome = nome;
            Cpf = cpf;
            Sexo = sexo;
        }

       
    }
}