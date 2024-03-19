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
            
            updateEmployeeTitle();
        })
        .catch(error => {
            console.error('Error loading departments:', error);
        });
    updateEmployeeTitle()
});


$(document).ready(function () {
    $("#name-input").focusout(function () {
       updateEmployeeTitle();
    });
});

function updateEmployeeTitle() {
    let nameInput = document.getElementById('name-input');
    let employeeTitle = document.querySelector('.employee-title');

    if(nameInput && employeeTitle && nameInput.value) {
        employeeTitle.textContent = nameInput.value;
    }
}