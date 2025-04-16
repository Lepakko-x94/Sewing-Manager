using Microsoft.AspNetCore.Components.Forms;

namespace SewingManager.UseCases.Materials.Interfaces;

public interface IFileStorageService
{
    Task<string?> SaveImageAsync(IBrowserFile file, int maxWidth, int maxHeight);
}