using DesafioSonda.Domain.Entities;
using FluentValidation;

namespace DesafioSonda.Domain.Validators
{
    public class ClientesValidator : AbstractValidator<Clientes>
    {
        public ClientesValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Nome)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O nome não pode ser vazio.")

                .MinimumLength(40)
                .WithMessage("O nome deve ter no mínimo 40 caracteres.")

                .MaximumLength(250)
                .WithMessage("O nome deve ter no máximo 250 caracteres.");

            RuleFor(x => x.Cpf)
                .NotNull()
                .WithMessage("O cpf não pode ser nulo.")

                .NotEmpty()
                .WithMessage("O cpf não pode ser vazio.")

                .Matches(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})")
                .WithMessage("O cpf não é válido.");

            RuleFor(x => x.DataNascimento)
                .NotNull()
                .WithMessage("A Data de Nascimento não pode ser nula.")

                .NotEmpty()
                .WithMessage("A Data de Nascimento não pode ser vazia.")

                .Must(o => o.Year > 18)
                .WithMessage("Deve possuir mais de 18 anos.");
        }
    }
}