using SewingManager.CoreBusiness;

namespace SewingManager.UseCases.PluginInterfaces;

public interface IMaterialRepository
{
    Task<IEnumerable<Material>> GetMaterialsByNameAsync(string name);
    Task DeleteMaterialByIdAsync(int materialId);
    Task AddMaterialAsync(Material material);
    Task<IEnumerable<MaterialCategory>> GetMaterialCategoriesByNameUseCase(string name);
    Task<Material> GetMaterialByIdAsync(int materialId);
    Task UpdateMaterialAsync(Material material);
}