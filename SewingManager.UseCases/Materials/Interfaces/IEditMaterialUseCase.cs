using Microsoft.AspNetCore.Components.Forms;
using SewingManager.CoreBusiness;

namespace SewingManager.UseCases.Materials.Interfaces;

public interface IEditMaterialUseCase
{
    Task ExecuteAsync(Material material, IBrowserFile? file);
}