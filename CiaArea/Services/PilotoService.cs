using CiaArea.Data.Contexts;
using CiaArea.Entities;
using CiaArea.Services.Interfaces;
using CiaArea.Validators.Piloto;
using CiaArea.ViewModels.Piloto;
using FluentValidation;

namespace CiaArea.Services
{
    public class PilotoService : IPilotoService
    {
        private readonly AppDbContext _context;
        private readonly IncluirPilotoValidator _incluirValidator;
        private readonly EditarPilotoValidator _editarValidator;
        private readonly ExcluirPilotoValidator _excluirValidator;

        public PilotoService
        (
            AppDbContext context,
            IncluirPilotoValidator incluirValidator,
            EditarPilotoValidator editarValidator,
            ExcluirPilotoValidator excluirValidator
        )
        {
            _context = context;
            _incluirValidator = incluirValidator;
            _editarValidator = editarValidator;
            _excluirValidator = excluirValidator;
        }

        public DetalhePilotoVM Add(IncluirPilotoVM dados)
        {
            _incluirValidator.ValidateAndThrow(dados);

            var piloto = new Piloto(dados.Nome, dados.Matricula);

            _context.Add(piloto);
            _context.SaveChanges();

            return new DetalhePilotoVM(piloto.Id, piloto.Nome, piloto.Matricula);
        }

        public DetalhePilotoVM Update(EditarPilotoVM dados)
        {
            _editarValidator.ValidateAndThrow(dados);

            var piloto = _context.Pilotos.Find(dados.Id);

            if (piloto == null)
                return null;

            piloto.Nome = dados.Nome;
            piloto.Matricula = dados.Matricula;

            _context.Update(piloto);
            _context.SaveChanges();

            return new DetalhePilotoVM(piloto.Id, piloto.Nome, piloto.Matricula);
        }

        public bool Remove(Guid id)
        {
            _excluirValidator.ValidateAndThrow(id);

            var piloto = _context.Pilotos.Find(id);

            if (piloto == null)
                return false;

            _context.Remove(piloto);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<ListarPilotoVM> Get()
        {
            return _context.Pilotos.Select(p => new ListarPilotoVM(p.Id, p.Nome));
        }

        public DetalhePilotoVM GetById(Guid id)
        {
            var piloto = _context.Pilotos.Find(id);

            if (piloto == null)
                return null;

            return new DetalhePilotoVM(piloto.Id, piloto.Matricula, piloto.Nome);
        }
    }
}
