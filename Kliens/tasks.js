$(document).ready(function() {
    fetch('http://localhost:5148/Project/Developers')
        .then(response => {
            if (!response.ok) {
                throw new Error('Hiba a válaszban');
            }
            return response.json();
        })
        .then(developers => {
            console.log('Fejlesztők:', developers);

            const developerSelect = document.getElementById('developer');
            developerSelect.innerHTML = '';
            developers.forEach(developer => {
                const option = document.createElement('option');
                option.value = developer.id;
                option.textContent = developer.name;
                developerSelect.appendChild(option);
            });
        })
        .catch(error => {
            console.error('Hiba történt a fejlesztők lekérdezése közben:', error);
        });

    $('#taskForm').submit(function(event) {
        event.preventDefault();
        var taskName = $('#taskName').val();
        var taskDescription = $('#taskDescription').val();
        var developerId = $('#developer').val();
        var taskDeadline = $('#taskDeadline').val();
        if (taskName.trim() !== '' && taskDescription.trim() !== '' && developerId.trim() !== '' && taskDeadline.trim() !== '') {
            addTaskToEndpoint(taskName, taskDescription, developerId, taskDeadline);
        }
    });
});

function addTaskToEndpoint(taskName, taskDescription, developerId, taskDeadline) {
    const id = parseInt(localStorage.getItem('id'));
    const apiUrl = 'http://localhost:5148';
    const endpoint = `${apiUrl}/Project/${developerId}/task`;

    const data = {
        name: taskName,
        description: taskDescription,
        projectId: parseInt(location.href.split('#')[1]),
        managerId: id,
        deadline: taskDeadline
    };

    fetch(endpoint, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
    .then(response => {
        if (!response.ok) {
            throw new Error(console.log(data));
        }
        console.log(console.log(data));
        alert('Feladat hozzáadása sikeres!');
    })
    .catch(error => {
        console.error('Hiba:', error);
        alert('Az adott projekthez már hozzá van adva a kiválasztott fejlesztő!');
    });
}
