# Генерація документації для C#

## 1. XML-документація в C#

1. **Увімкнення XML-документації**:

   - У файлі `.csproj` додайте:

     ```xml
     <GenerateDocumentationFile>true</GenerateDocumentationFile>
     ```

   - Це створює XML-файл (наприклад, `MyProject.xml`) під час збірки.

2. **Написання XML-коментарів**:

   - Використовуйте `///` з тегами, такими як `<summary>`, `<param>`, `<returns>`.

   - Приклад:

     ```csharp
     /// <summary>Обчислює суму двох цілих чисел.</summary>
     /// <param name="a">Перше ціле число.</param>
     /// <param name="b">Друге ціле число.</param>
     /// <returns>Сума цілих чисел.</returns>
     public int Sum(int a, int b) => a + b;
     ```

3. **Збірка**:

   - Виконайте `dotnet build`, щоб створити XML-файл.

## 2. Використання DocFX

**DocFX** генерує статичний сайт із XML-коментарів та Markdown-файлів.

### Налаштування

- Встановлення: `dotnet tool install -g docfx`
- Ініціалізація: У папці `docs` виконайте `docfx init -q`, щоб створити `docfx.json` та `toc.yml`.

### Кроки

1. **Налаштування** `docfx.json`:

   ```json
   {
     "metadata": [{ "src": ["../MyProject.csproj"], "dest": "api" }],
     "build": { "content": ["api/**.yml", "articles/**.md"], "dest": "_site" }
   }
   ```

2. **Налаштування змісту (TOC)**:

   - Відредагуйте `toc.yml`, щоб замінити стандартний TOC на власний.

   - Приклад `toc.yml`:

     ```yaml
     - name: Генерація документації
       href: articles/generate_docs.md
     - name: Лінтинг
       href: articles/linting.md
     - name: Довідка API
       href: api/index.yml
     ```

   - Переконайтеся, що файли (наприклад, `generate_docs.md`, `linting.md`) є в папці `articles/`.

3. **Додавання Markdown-файлів**:

   - Розмістіть `generate_docs.md` та `linting.md` у папці `articles/`.
   - Перевірте, чи шляхи в `toc.yml` відповідають розташуванню файлів.

4. **Генерація**:

   - Виконайте `docfx docfx.json` для створення метаданих та обробки TOC.

5. **Попередній перегляд**:

   - Виконайте `docfx docfx.json --serve` та відкрийте `http://localhost:8080`, щоб перевірити TOC.

6. **Збірка**:

   - Виконайте `docfx build docfx.json`, щоб створити сайт у папці `_site`.

## 3. Видалення DocFX

Якщо DocFX більше не потрібен, виконайте наступні дії для його видалення:

1. **Видалення глобальної установки**:

   - Якщо DocFX встановлено глобально, видаліть його командою:

     ```bash
     dotnet tool uninstall -g docfx
     ```

2. **Видалення локальної установки**:

   - Якщо DocFX додано як залежність у проекті, видаліть його з `.csproj`:

     ```bash
     dotnet remove package DocFX
     ```

3. **Очищення файлів DocFX**:

   - Видаліть папку `docs` (або іншу, де ініціалізовано DocFX) разом із файлами `docfx.json`, `toc.yml`, `articles/`, `api/`, `_site/` тощо.

4. **Перевірка**:

   - Переконайтеся, що команда `docfx --version` не повертає результату (для глобального видалення).
