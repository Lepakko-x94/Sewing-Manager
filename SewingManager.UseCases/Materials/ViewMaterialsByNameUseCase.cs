
using SewingManager.CoreBusiness;
using SewingManager.UseCases.Materials.Interfaces;
using SewingManager.UseCases.PluginInterfaces;

namespace SewingManager.UseCases.Materials
{
    public class ViewMaterialsByNameUseCase : IViewMaterialsByNameUseCase
    {
        private readonly IMaterialRepository _materialRepository;

        public ViewMaterialsByNameUseCase(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<IEnumerable<Material>> ExecuteAsync(string name = "")
        {
            return await _materialRepository.GetMaterialsByNameAsync(name);
        }
    }
}
