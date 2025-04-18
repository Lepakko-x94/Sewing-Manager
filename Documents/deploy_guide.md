# Інструкція з деплою проекту

## Вимоги
- .NET 8 SDK для компіляції проєкту.
- Visual Studio 2022 для зручної публікації.
- Акаунт Azure із доступом до створення App Service.
- Локально протестований проєкт (`SewingManager.Webapp`).

## Підготовка
- Переконайтеся, що додаток працює через `dotnet run` або F5 у Visual Studio.
- У `Program.cs` перевірте наявність `builder.Services.AddRazorComponents().AddInteractiveServerComponents()` для підтримки `InteractiveServer`.
- Перевірте залежності в `.csproj` (наприклад, `Microsoft.AspNetCore.Components.Server`) та їх сумісність із .NET 8.

## Деплой
1. У **Azure Portal** створіть App Service:
   - Виберіть .NET 8 (LTS), Windows/Linux, Free F1 для тестів.
   - Задайте ім’я, наприклад, `sewing-manager-webapp`.
2. Завантажте профіль публікації через **Get publish profile**.
3. У Visual Studio:
   - Клацніть правою кнопкою миші на `SewingManager.Webapp` > **Publish**.
   - Імпортуйте профіль із Azure, виберіть **Release**, натисніть **Publish**.
4. Після завершення відкрийте URL, наприклад, `https://sewing-manager-webapp.azurewebsites.net`.

## Перевірка та налаштування
- Перегляньте додаток у браузері. Якщо сторінки, як `Imports.razor`, відображаються, розгортання успішне.
- Увімкніть WebSockets у Azure (**Configuration** > **General settings**) для коректної роботи SignalR у `InteractiveServer`.
- Якщо виникають помилки, перевірте логи через **Log Stream** або **Diagnose and solve problems** у Azure Portal.
- Для продакшну розгляньте платний план (наприклад, B1) для кращої продуктивності.
