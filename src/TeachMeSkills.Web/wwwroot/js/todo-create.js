const TODO_CREATE_BUTTON = document.querySelector("#button_confirm");

function showAlert() {
    const title = document.querySelector('#title').value;
    const description = document.querySelector('#description').value;

    if (title === "" && description == "") {
        alert("Empty model..");
        return;
    }

    alert(`Your new todo item:\nTitle: ${title}!\nDescription: ${description}`);
}

function run() {
    TODO_CREATE_BUTTON.addEventListener("click", showAlert);
}

document.addEventListener("DOMContentLoaded", run);
