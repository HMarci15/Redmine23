const apiUrl = 'http://localhost:5148'; 
const projectId = 1; 

fetch(`${apiUrl}/Project/${projectId}/tasks`)
    .then(response => {
        if (!response.ok) {
            throw new Error('Hiba a válaszban');
        }
        return response.json();
    })
    .then(data => {
        console.log('Feladat adatok:', data);
        displayProject(data);
    })
    .catch(error => console.error('Hiba:', error));

function displayProject(task) {
    const tableBody = document.getElementById('taskTableBody');
    tableBody.innerHTML = ''; 
    
    task.forEach((item, index) => {
        const row = `
            <tr>
                <td>${item.taskId}</td>
                <td>${item.name}</td>
                <td>${item.description}</td>
                <td>${item.deadLine.replace('T', ' ').substring(0, 16)}</td>
            </tr>
        `;
        tableBody.innerHTML += row;
    });
}
    