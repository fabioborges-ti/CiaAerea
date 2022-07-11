using CiaArea.Data.Contexts;
using CiaArea.ViewModels.Piloto;
using FluentValidation;

namespace CiaArea.Validators.Piloto
{
    public class IncluirPilotoValidator : AbstractValidator<IncluirPilotoVM>
    {
        private readonly AppDbContext _context;

        public IncluirPilotoValidator(AppDbContext context)
        {
            _context = context;

            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("É necessário informar o nome do piloto.")
                .MaximumLength(100).WithMessage("O nome do piloto deve ter no máximo 100 caracteres.");

            RuleFor(a => a.Matricula)
                .NotEmpty().WithMessage("É necessário informar a matrícula do piloto.")
                .MaximumLength(10).WithMessage("A matrícula do piloto deve ter no máximo 10 caracteres.")
                .Must(matricula => !_context.Pilotos.Any(piloto => piloto.Matricula.Equals(matricula))).WithMessage("Já existe um piloto com essa matrícula.");
            //.Must(matricula => _context.Pilotos.Count(p => p.Matricula.Equals(matricula)) == 0).WithMessage("Já existe um piloto com essa matrícula.");
        }
    }
}
