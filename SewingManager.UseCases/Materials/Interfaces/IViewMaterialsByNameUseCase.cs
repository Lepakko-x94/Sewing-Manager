using SewingManager.CoreBusiness;

namespace SewingManager.UseCases.Materials.Interfaces;

public interface IViewMaterialsByNameUseCase
{
    Task<IEnumerable<Material>> ExecuteAsync(string name = "");
}