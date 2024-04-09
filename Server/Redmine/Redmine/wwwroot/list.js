const apiUrl = 'http://localhost:5148'; // Az API URL-je, amelyről lekéred az adatokat
const projectId = 1; // Az aktuális projekt azonosítója, ami a Swagger-ben van megadva

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
    tableBody.innerHTML = ''; // Előző sorok törlése (ha voltak)
    
    task.forEach((item, index) => {
        const row = `
            <tr>
                <td>${item.taskId}</td>
                <td>${item.name}</td>
                <td>${item.description}</td>
                <td>${item.deadLine}</td>
            </tr>
        `;
        tableBody.innerHTML += row;
    });
}
    