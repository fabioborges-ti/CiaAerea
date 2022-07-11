using CiaArea.Data.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CiaArea.Validators.Piloto
{
    public class ExcluirPilotoValidator : AbstractValidator<Guid>
    {
        private readonly AppDbContext _context;

        public ExcluirPilotoValidator(AppDbContext context)
        {
            _context = context;

            RuleFor(id => _context.Pilotos.Include(p => p.Voos).FirstOrDefault(p => p.Id.Equals(id)))
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Id do piloto inválido")
                .Must(piloto => piloto.Voos.Count == 0).WithMessage("Não é possível excluir um piloto que já realizou voos.");
        }
    }
}
