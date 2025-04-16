
using SewingManager.UseCases.Materials.Interfaces;
using SewingManager.UseCases.PluginInterfaces;

namespace SewingManager.UseCases.Materials
{
    public class DeleteMaterialUseCase : IDeleteMaterialUseCase
    {
        private readonly IMaterialRepository _materialRepository;

        public DeleteMaterialUseCase(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public async Task ExecuteAsync(int materialId)
        {
            await _materialRepository.DeleteMaterialByIdAsync(materialId);
        }
    }
}
