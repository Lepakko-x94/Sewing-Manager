using SewingManager.CoreBusiness;
using SewingManager.UseCases.Materials.Interfaces;
using SewingManager.UseCases.PluginInterfaces;

namespace SewingManager.UseCases.Materials
{
    public class ViewMaterialByIdUseCase : IViewMaterialByIdUseCase
    {
        private readonly IMaterialRepository _materialRepository;

        public ViewMaterialByIdUseCase(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task<Material> ExecuteAsync(int materialId)
        {
            return await _materialRepository.GetMaterialByIdAsync(materialId);
        }
    }
}
