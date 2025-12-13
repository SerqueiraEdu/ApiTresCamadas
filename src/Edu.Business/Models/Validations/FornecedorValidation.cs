using Edu.Business.Models.Validations.Documentos;
using FluentValidation;

namespace Edu.Business.Models.Validations
{
    public class FornecedorValidation : AbstractValidator<Fornecedor>
    {
        public FornecedorValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

            When(f => f.TipoFornecedor == TipoFornecedor.PesooaFisica, () =>
            {
                RuleFor(f => f.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

                RuleFor(f => CpfValidacao.Validar(f.Documento)).Equal(true)
                    .WithMessage("O documento fornecido é inválido.");
            });

            When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            {
                RuleFor(f => f.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
                    .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

                RuleFor(f => CnpjValidacao.Validar(f.Documento)).Equal(true)
                    .WithMessage("O documento fornecido é inválido.");
            });
        }
    }
}
