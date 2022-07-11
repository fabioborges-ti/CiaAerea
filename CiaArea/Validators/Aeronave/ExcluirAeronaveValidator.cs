using CiaArea.Data.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CiaArea.Validators.Aeronave
{
    public class ExcluirAeronaveValidator : AbstractValidator<Guid>
    {
        private readonly AppDbContext _context;

        public ExcluirAeronaveValidator(AppDbContext context)
        {
            _context = context;

            RuleFor(id => _context.Aeronaves
                            .Include(a => a.Voos)
                            .Include(a => a.Manutencoes)
                            .FirstOrDefault(a => a.Id.Equals(id)))
                            .Cascade(CascadeMode.Stop)
                            .NotNull().WithErrorCode("Id da aeronave inválido")
                            .Must(aeronave => aeronave!.Voos.Count == 0).WithMessage("Não é possível excluir uma aeronave que já realizou voos.")
                            .Must(aeronave => aeronave!.Manutencoes.Count == 0).WithMessage("Não é possível excluir uma aeronave que já realizou manutenções.");
        }
    }
}
