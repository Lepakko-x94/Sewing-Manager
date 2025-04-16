using SewingManager.Infrastructure;
using SewingManager.UseCases.Materials;
using SewingManager.UseCases.Materials.Interfaces;
using SewingManager.UseCases.PluginInterfaces;
using SewingManager.Webapp.Components;
using SewingManger.Plugins.InMemory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorComponents();

builder.Services.AddSingleton<IMaterialRepository, MaterialRepository>();

builder.Services.AddTransient<IFileStorageService, FileStorageService>();
builder.Services.AddTransient<IViewMaterialsByNameUseCase, ViewMaterialsByNameUseCase>();
builder.Services.AddTransient<IDeleteMaterialUseCase, DeleteMaterialUseCase>();
builder.Services.AddTransient<IAddMaterialUseCase, AddMaterialUseCase>();
builder.Services.AddTransient<IViewMaterialCategoriesByNameUseCase, ViewMaterialCategoriesByNameUseCase>();
builder.Services.AddTransient<IViewMaterialByIdUseCase, ViewMaterialByIdUseCase>();
builder.Services.AddTransient<IEditMaterialUseCase, EditMaterialUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
