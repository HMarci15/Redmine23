const apiUrl = 'http://localhost:5148'; 
fetch(`${apiUrl}/Project`)
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

window.onload = function() {
    const nav = document.createElement('nav');
    nav.classList.add('navbar');
    nav.classList.add('fixed-top');
    nav.classList.add('bg-primary');

    const div = document.createElement('div');
    div.classList.add('container-fluid');

    const name = localStorage.getItem('name');
    const a = document.createElement('a');
    a.classList.add('navbar-brand');
    a.innerHTML = `Üdvözlünk, ${name}!`;
    const form = document.createElement('form');
    form.classList.add('d-flex');

    const logoutButton = document.createElement('button');
    logoutButton.textContent = 'Kijelentkezés';
    logoutButton.classList.add('btn');
    logoutButton.classList.add('btn-danger');
    logoutButton.setAttribute("type", "button");

    logoutButton.addEventListener('click', function() {
        localStorage.removeItem('name'); // Törli a nevet a localStorage-ból
        window.location.href = 'login.html'; // Átirányítás a login.html oldalra
    });

    div.appendChild(a);
    
    form.appendChild(logoutButton);
    
    div.appendChild(form);
    
    nav.appendChild(div);

    document.body.insertBefore(nav, document.body.firstChild);
}


function displayProject(task) {
const tableBody = document.getElementById('taskTableBody');
tableBody.innerHTML = ''; 

task.forEach((item, index) => {
    const row = `
        <tr>
            <td>${item.id}</td>
            <td>${item.name}</td>
            <td>${item.description}</td>
            <td>${item.projectTypeName}</td>
            <td>
                <a href="list.html"><button type="button" class="btn btn-primary">Feladatok</button></a>
                <a href="addtask.html"><button type="button" class="btn btn-primary">Hozzáadás</button></a>
            </td>
        </tr>

    `;
    tableBody.innerHTML += row;
});
}

function searchOnType() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("taskTableBody");
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
      td = tr[i].getElementsByTagName("td")[3];
      if (td) {
        txtValue = td.textContent || td.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
          tr[i].style.display = "";
        } else {
          tr[i].style.display = "none";
        }
      }       
    }
}

document.getElementById("showTasksBtn").addEventListener("click", function() {
    fetch(`${apiUrl}/Project/deadlineTask`)
    .then(response => {
        if (!response.ok) {
            throw new Error('Hiba a válaszban');
        }
        return response.json();
    })
    .then(data => {
        console.log('Feladat adatok:', data);
        displayTasks(data);
        document.getElementById("showTasksBtn").style.display = "none";
        document.getElementById("hideTasksBtn").style.display = "inline-block";
    })
    .catch(error => console.error('Hiba:', error));

    
});

document.getElementById("hideTasksBtn").addEventListener("click", function() {
    document.getElementById("tasksTableContainer").style.display = "none";
    document.getElementById("hideTasksBtn").style.display = "none";
    document.getElementById("showTasksBtn").style.display = "inline-block";
});

function displayTasks(tasks) {
    const tableBody = document.getElementById('tasksBody');
    tableBody.innerHTML = ''; 

    tasks.forEach(task => {
        const row = `
            <tr>
                <td>${task.taskId}</td>
                <td>${task.name}</td>
                <td>${task.description}</td>
                <td>${task.date.replace('T', ' ').substring(0, 16)}</td>
            </tr>
        `;
        tableBody.innerHTML += row;
    });

    document.getElementById("tasksTableContainer").style.display = "block";
}