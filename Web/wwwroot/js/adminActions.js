document.addEventListener('DOMContentLoaded', function () {
    function updateTotalCount() {
        fetch('/api/admin/employees/GetCurrentCount')
            .then(response => response.json())
            .then(data => {
                document.getElementById('total-count').textContent = `Total Employees: ${data}`;
            })
            .catch(error => {
                console.error('Error fetching employee count:', error);
            });
    }

    updateTotalCount();

    function deleteEmployee(id) {
        const token = document.getElementsByName("__RequestVerificationToken")[0].value;
        fetch(`/api/admin/employees/Delete/${id}`, {
            method: 'Delete',
            headers: {'X-CSRF-TOKEN': token},
        })
            .then(response => {
                if (response.ok) {
                    let statusElement = document.getElementById(`is-deleted-status-${id}`);
                    if (statusElement) {
                        statusElement.textContent = 'True';
                    }

                    const deleteButton = document.querySelector(`[data-id='${id}']`);
                    if (deleteButton) {
                        deleteButton.remove();
                    }
                    updateTotalCount();
                } else {
                    throw new Error('Delete action failed');
                }
            })
            .catch(error => {
                console.error('Error deleting employee:', error);
            });
    }

    document.querySelectorAll('.delete-btn').forEach(button => {
        button.addEventListener('click', function () {
            const id = Number(this.getAttribute('data-id'));
            if (confirm("Are you sure you want to delete this employee?")) {
                deleteEmployee(id);
            }
        });
    });
});