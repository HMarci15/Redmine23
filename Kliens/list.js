const apiUrl = 'http://localhost:5148'; 
const projectId = parseInt(location.href.split('#')[1]); 
const token = sessionStorage.getItem('token');

if(!token) {window.location.href = './login.html';}
fetch(`${apiUrl}/Project/${projectId}/tasks`, {
    method: 'GET',
    headers: {
        'Authorization': 'Bearer ' + token,
        'Content-Type': 'application/json'
    }
})
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
                <td>${item.id}</td>
                <td>${item.name}</td>
                <td>${item.description}</td>
                <td>${item.deadline.replace('T', ' ').substring(0, 10)}</td>
            </tr>
        `;
        tableBody.innerHTML += row;
    });
}
    