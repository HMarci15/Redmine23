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
    const name = localStorage.getItem('name'); // Kiolvassuk a nevet
    const header12 = document.createElement('h1');
    header12.textContent = `Üdvözöllek, ${name}!`;

    header12.style.textAlign = 'center'; // Középre igazítja a szöveget
    header12.style.padding = '20px'; // Ad egy kis térközt a szöveg körül
    header12.style.backgroundColor = '#0d6efd'; // Ad egy háttérszínt
    header12.style.marginBottom = '20px'; // Ad egy kis térközt a fejléc és a többi elem között
    header12.style.borderRadius = '5px'; // Lekerekíti a széleket

    document.body.insertBefore(header12, document.body.firstChild);
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