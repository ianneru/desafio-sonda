using DesafioSonda.Core.Exceptions;
using DesafioSonda.Domain.Core;
using DesafioSonda.Domain.Validators;
using System;
using System.Text.RegularExpressions;

namespace DesafioSonda.Domain.Entities
{
    public class Clientes : Entity
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public Sexo Sexo { get; set; }

        public override bool Validate()
        {
            var validator = new ClientesValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Alguns campos estão inválidos, por favor corrija-os!", _errors);
            }

            return true;
        }

        public override bool isValid()
        {
            var validator = new ClientesValidator();
            var validation = validator.Validate(this);

            return validation.IsValid;
        }

        public void RemoveCaracteresCpf()
        {
            Regex rgx = new Regex(@"[^\d]");
            Cpf = rgx.Replace(Cpf, "");
        }
    }
}
