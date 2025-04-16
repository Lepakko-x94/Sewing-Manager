using Microsoft.AspNetCore.Components.Forms;
using SewingManager.CoreBusiness;

namespace SewingManager.UseCases.Materials.Interfaces;

public interface IAddMaterialUseCase
{
    Task ExecuteAsync(Material material, IBrowserFile? file);
}