
using SewingManager.CoreBusiness;
using SewingManager.UseCases.Materials.Interfaces;
using SewingManager.UseCases.PluginInterfaces;

namespace SewingManager.UseCases.Materials
{
    public class ViewMaterialCategoriesByNameUseCase : IViewMaterialCategoriesByNameUseCase
    {
        private readonly IMaterialRepository _materialRepository;

        public ViewMaterialCategoriesByNameUseCase(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<IEnumerable<MaterialCategory>> ExecuteAsync(string name = "")
        {
            return await _materialRepository.GetMaterialCategoriesByNameUseCase(name);
        }
    }
}
