document.addEventListener('DOMContentLoaded', function () {
    fetch('/api/admin/employees/GetCurrentCount')
        .then(response => response.json())
        .then(data => {
            document.getElementById('total-count').textContent = `Total Employees: ${data}`;
        })
        .catch(error => {
            console.error('Error fetching employee count:', error);
            document.getElementById('total-count').textContent = 'Error loading count';
        });
});