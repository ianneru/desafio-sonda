using DesafioSonda.Domain.Core;
using System;

namespace DesafioSonda.Application.DTOs
{
    public class ClientesDTO
    {
        public Guid Identificador { get; set; }
        
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public Sexo Sexo { get; set; }

        public DateTime DataNascimento { get; set; }

        public ClientesDTO()
        { }

        public ClientesDTO(Guid identificador, string nome, string cpf, Sexo sexo)
        {
            Identificador = identificador;
            Nome = nome;
            Cpf = cpf;
            Sexo = sexo;
        }
    }
}
