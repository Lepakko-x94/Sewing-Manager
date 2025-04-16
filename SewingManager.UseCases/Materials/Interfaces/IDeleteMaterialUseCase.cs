namespace SewingManager.UseCases.Materials.Interfaces;

public interface IDeleteMaterialUseCase
{
    Task ExecuteAsync(int materialId);
}