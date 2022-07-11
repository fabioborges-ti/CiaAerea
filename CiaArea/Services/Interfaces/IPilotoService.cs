using CiaArea.ViewModels.Piloto;

namespace CiaArea.Services.Interfaces
{
    public interface IPilotoService
    {
        DetalhePilotoVM Add(IncluirPilotoVM data);
        DetalhePilotoVM Update(EditarPilotoVM dados);
        bool Remove(Guid id);
        IEnumerable<ListarPilotoVM> Get();
        DetalhePilotoVM GetById(Guid id);
    }
}
