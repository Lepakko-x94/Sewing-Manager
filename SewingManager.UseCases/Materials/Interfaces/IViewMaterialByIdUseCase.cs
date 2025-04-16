using SewingManager.CoreBusiness;

namespace SewingManager.UseCases.Materials.Interfaces;

public interface IViewMaterialByIdUseCase
{
    Task<Material> ExecuteAsync(int materialId);
}