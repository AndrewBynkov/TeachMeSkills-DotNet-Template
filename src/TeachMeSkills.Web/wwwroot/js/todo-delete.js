function start() {
    document.addEventListener("click", function (event) {
        if (event.target.dataset.delete != undefined) {
            alert("Operation completed successfully");
        }
    });
}

document.addEventListener("DOMContentLoaded", start);
