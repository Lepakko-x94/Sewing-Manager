
using Microsoft.AspNetCore.Components.Forms;
using SewingManager.CoreBusiness;
using SewingManager.UseCases.Materials.Interfaces;
using SewingManager.UseCases.PluginInterfaces;

namespace SewingManager.UseCases.Materials
{
    public class EditMaterialUseCase : IEditMaterialUseCase
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IFileStorageService _fileStorageService;

        public EditMaterialUseCase(IMaterialRepository materialRepository, IFileStorageService fileStorageService)
        {
            _materialRepository = materialRepository;
            _fileStorageService = fileStorageService;
        }

        public async Task ExecuteAsync(Material material, IBrowserFile? file)
        {
            if (file != null)
            {
                material.ImageUrl = await _fileStorageService.SaveImageAsync(file, 1024, 1024);
            }

            await _materialRepository.UpdateMaterialAsync(material);
        }
    }
}
