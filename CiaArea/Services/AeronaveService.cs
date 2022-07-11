using CiaArea.Data.Contexts;
using CiaArea.Entities;
using CiaArea.Services.Interfaces;
using CiaArea.Validators.Aeronave;
using CiaArea.ViewModels.Aeronave;
using FluentValidation;

namespace CiaArea.Services
{
    public class AeronaveService : IAeronaveService
    {
        private readonly AppDbContext _context;

        private readonly IncluirAeronaveValidator _incluirValidator;
        private readonly EditarAeronaveValidator _editarValidator;
        private readonly ExcluirAeronaveValidator _excluirValidator;

        public AeronaveService
        (
            AppDbContext context,
            IncluirAeronaveValidator incluirValidator,
            EditarAeronaveValidator editarValidator,
            ExcluirAeronaveValidator excluirValidator
        )
        {
            _context = context;

            _incluirValidator = incluirValidator;
            _editarValidator = editarValidator;
            _excluirValidator = excluirValidator;
        }

        public DetalheAeronaveVM Add(IncluirAeronaveVM dados)
        {
            _incluirValidator.ValidateAndThrow(dados);

            var aeronave = new Aeronave(dados.Fabricante, dados.Modelo, dados.Codigo);

            _context.Add(aeronave);
            _context.SaveChanges();

            return new DetalheAeronaveVM(aeronave.Id, aeronave.Fabricante, aeronave.Modelo, aeronave.Codigo);
        }

        public DetalheAeronaveVM Update(EditarAeronaveVM dados)
        {
            _editarValidator.ValidateAndThrow(dados);

            var aeronave = _context.Aeronaves.Find(dados.Id);

            if (aeronave == null)
                return null;

            aeronave.Fabricante = dados.Fabricante;
            aeronave.Modelo = dados.Modelo;
            aeronave.Codigo = dados.Codigo;

            _context.Update(aeronave);
            _context.SaveChanges();

            return new DetalheAeronaveVM(aeronave.Id, aeronave.Fabricante, aeronave.Modelo, aeronave.Codigo);
        }

        public bool Remove(Guid id)
        {
            _excluirValidator.ValidateAndThrow(id);

            var aeronave = _context.Aeronaves.Find(id);

            if (aeronave == null)
                return false;

            _context.Remove(aeronave);
            _context.SaveChanges();

            return true;
        }

        public IEnumerable<ListarAeronaveVM> Get()
        {
            return _context.Aeronaves.Select(a => new ListarAeronaveVM(a.Id, a.Modelo, a.Codigo));
        }

        public DetalheAeronaveVM GetById(Guid id)
        {
            var aeronave = _context.Aeronaves.Find(id);

            if (aeronave == null)
                return null;

            return new DetalheAeronaveVM(aeronave.Id, aeronave.Fabricante, aeronave.Modelo, aeronave.Codigo);
        }
    }
}
