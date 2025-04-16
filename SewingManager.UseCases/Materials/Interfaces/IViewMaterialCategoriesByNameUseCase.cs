using SewingManager.CoreBusiness;

namespace SewingManager.UseCases.Materials.Interfaces;

public interface IViewMaterialCategoriesByNameUseCase
{
    Task<IEnumerable<MaterialCategory>> ExecuteAsync(string name = "");
}