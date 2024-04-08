/* // API végpont URL-je
const apiUrl = 'http://localhost:7152/api';

// Projektek listázása
fetch(`${apiUrl}/projects`)
    .then(response => response.json())
    .then(data => console.log('Projektek:', data))
    .catch(error => console.error('Hiba:', error));

// Új projekt hozzáadása
const newProject = {
    name: 'Új projekt',
    // További adatok...
};
fetch(`${apiUrl}/projects`, {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json',
    },
    body: JSON.stringify(newProject),
})
.then(response => response.json())
.then(data => console.log('Új projekt hozzáadva:', data))
.catch((error) => console.error('Hiba:', error));

// Feladatok listázása
fetch(`${apiUrl}/tasks`)
    .then(response => response.json())
    .then(data => console.log('Feladatok:', data))
    .catch(error => console.error('Hiba:', error));

// Új feladat hozzáadása
const newTask = {
    name: 'Új feladat',
    description: 'Feladat leírása',
    developer: 'Fejlesztő neve',
    // További adatok...
};
fetch(`${apiUrl}/tasks`, {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json',
    },
    body: JSON.stringify(newTask),
})
.then(response => response.json())
.then(data => console.log('Új feladat hozzáadva:', data))
.catch((error) => console.error('Hiba:', error));     */

// API végpont URL-je
const apiUrl = 'http://localhost:5148';

// Projektek listázása
fetch(`${apiUrl}/project`)
    .then(response => response.json())
    .then(data => {
        const projectList = document.getElementById('projectList');
        data.forEach(project => {
            const option = document.createElement('option');
            option.text = project.name;
            projectList.add(option);
        });
    })
    .catch(error => console.error('Hiba:', error));

// Új projekt hozzáadása
// A példa kedvéért most nem hozzuk létre az új projektet

// Feladatok listázása
fetch(`${apiUrl}/tasks`)
    .then(response => response.json())
    .then(data => {
        const taskList = document.getElementById('taskList');
        data.forEach(task => {
            const div = document.createElement('div');
            div.textContent = task.name;
            taskList.appendChild(div);
        });
    })
    .catch(error => console.error('Hiba:', error));

// Új feladat hozzáadása
// A példa kedvéért most nem hozzuk létre az új feladatot
