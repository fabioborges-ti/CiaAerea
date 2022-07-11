using CiaArea.Data.Contexts;
using CiaArea.ViewModels.Aeronave;
using FluentValidation;

namespace CiaArea.Validators.Aeronave
{
    public class EditarAeronaveValidator : AbstractValidator<EditarAeronaveVM>
    {
        private readonly AppDbContext _context;

        public EditarAeronaveValidator(AppDbContext context)
        {
            _context = context;

            RuleFor(a => a.Fabricante)
                .NotEmpty()
                .WithMessage("É necessário informar o fabricante da aeronave.")
                .MaximumLength(50)
                .WithMessage("O nome do fabricante deve ter no máximo 50 caracteres.");

            RuleFor(a => a.Modelo)
                .NotEmpty()
                .WithMessage("É necessário informar o modelo da aeronave.")
                .MaximumLength(50)
                .WithMessage("O modelo deve ter no máximo 50 caracteres.");

            RuleFor(a => a.Codigo)
                .NotEmpty()
                .WithMessage("É necessário informar o código da aeronave.")
                .MaximumLength(10)
                .WithMessage("O código deve ter no máximo 50 caracteres.");

            RuleFor(a => a)
                .Must(aeronave => _context.Aeronaves.Count(a => a.Codigo.Equals(aeronave.Codigo) && a.Id != aeronave.Id) == 0)
                .WithMessage("Já existe uma aeronave com esse código.");
        }
    }
}
