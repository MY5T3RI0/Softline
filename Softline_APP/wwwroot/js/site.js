let editBtn = document.getElementById('edit');
let deleteBtn = document.getElementById('delete');
let modalWindow = document.getElementById('record_not_set_modal');
let modal = new bootstrap.Modal(modalWindow);
let modalBtn = document.getElementById("modal-close-btn");

editBtn.addEventListener('click', function () {
    let record_id = editBtn.getAttribute("href");
    if (!record_id) modal.show();
});

deleteBtn.addEventListener('click', function () {
    let record_id = editBtn.getAttribute("asp-route-id");
    if (!record_id) modal.show();
});

modalBtn.addEventListener('click', function () {
    modal.hide();
});

let records = document.querySelectorAll('.record');
records.forEach(function (record) {
    record.addEventListener('click', function () {
        let is_on = record.classList.contains("checked");
        records.forEach(x => x.classList.remove("checked"));
        if (is_on) {
            record.classList.remove("checked");
            editBtn.removeAttribute("href");
            deleteBtn.removeAttribute("href");
        }
        else {
            record.classList.add("checked");
            let record_id = record.querySelector('.record_id').textContent;
            editBtn.setAttribute("href", `/Goal/Edit/?id=${record_id}`);
            deleteBtn.setAttribute("href", `/Goal/Delete/?id=${record_id}`);
        }
    });
});