using CiaArea.ViewModels.Aeronave;

namespace CiaArea.Services.Interfaces
{
    public interface IAeronaveService
    {
        DetalheAeronaveVM Add(IncluirAeronaveVM data);
        DetalheAeronaveVM Update(EditarAeronaveVM data);
        bool Remove(Guid id);
        IEnumerable<ListarAeronaveVM> Get();
        DetalheAeronaveVM GetById(Guid id);
    }
}
