using DesafioSonda.Domain.Entities;
using System;
using Xunit;

namespace DesafioSonda.Domain.Tests.ClienteValidator
{
    public class ClienteValidator
    {
        [Fact(DisplayName = "Cliente com Campo Nome acima de 250 caracteres")]
        public void ClienteCampoNomeAcimade250Caracteres()
        {
            var cliente = new Clientes
            {
                Identificador = Guid.NewGuid(),
                Nome = RandomStrings.RandomString(1000),
                Cpf = "72513665090",
                DataNascimento = new DateTime(1980, 2, 9),
                Sexo = Core.Sexo.Feminino
            };

            Assert.False(cliente.isValid());
        }
    }
}
