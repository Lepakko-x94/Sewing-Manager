window.enableDropZone = function (element, inputId) {
    element.addEventListener("dragover", function (e) {
        e.preventDefault();
    });

    element.addEventListener("drop", function (e) {
        e.preventDefault();
        const files = e.dataTransfer.files;
        if (files.length > 0) {
            const input = document.getElementById(inputId);
            const dataTransfer = new DataTransfer();
            dataTransfer.items.add(files[0]); // Тільки перший файл
            input.files = dataTransfer.files;

            // Викликаємо подію вручну, щоб Blazor її побачив
            input.dispatchEvent(new Event("change", { bubbles: true }));
        }
    });
};

window.triggerFileInput = function (inputId) {
    document.getElementById(inputId)?.click();
};
