document.addEventListener('DOMContentLoaded', function () {
    fetch('/api/Departments/GetDepartments')
        .then(response => response.json())
        .then(departments => {
            const select = document.getElementById('department-input');

            departments.forEach(department => {
                const option = new Option(department.name, department.id);
                select.add(option);
            });
            if (select.selectize) {
                select.selectize.destroy();
            }
            $(select).selectize({
                create: true,
                sortField: 'text'
            });
        })
        .catch(error => {
            console.error('Error loading departments:', error);
            document.getElementById('department-input').innerHTML = '<option>Error loading departments</option>';
        });
});

$(document).ready(function () {
    $("#name-input").focusout(function () {
        let name = $("#name-input").val();

        if (name.length !== 0) {
            $('.employee-title').text(name);
        }
    });
});
