const apiUrl = 'http://localhost:5148'; // Az API URL-je, amelyről lekéred az adatokat

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

function displayProject(task) {
const tableBody = document.getElementById('taskTableBody');
tableBody.innerHTML = ''; // Előző sorok törlése (ha voltak)

task.forEach((item, index) => {
    const row = `
        <tr>
            <td>${item.projectId}</td>
            <td>${item.name}</td>
            <td>${item.description}</td>
            <td>${item.projectTypeName}</td>
            <td>
                <a href="list.html"><button type="button" class="btn btn-primary">Feldatok</button></a>
                <a href="addtask.html"><button type="button" class="btn btn-primary">Hozzáadás</button></a>
            </td>
        </tr>

    `;
    tableBody.innerHTML += row;
});
}


//Projektlista lekérdezése
function getProjects(){
    //szerveroldali lekérdezés
    console.log('Projektlista lekérdezése');
}
getProjects();

//Feladatok listázása
function getTasks(projectId){
    //szerveroldali lekérdezés
    console.log('Feladatok listázása a következő projekthez:', projectId);
}

//Új feladat hozzáadása
function addTask(projectId, taskName, taskDescription, developerId){
//szerveroldali hozzáadás
console.log('Új feladat hozáadása:', projectId, taskName, taskDescription, developerId);

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
    .then(response => response.json())
    .then(data => {
        var tasks = data; // feltételezzük, hogy a válasz egy tömb feladatokat tartalmaz

        var tasksBody = document.getElementById("tasksBody");
        tasksBody.innerHTML = ""; // Ürítsük ki a táblázatot

        // Adjuk hozzá a feladatokat a táblázathoz
        tasks.forEach(function(task) {
            var row = document.createElement("tr");
            row.innerHTML = `<td>${task.task}</td><td>${task.deadline}</td><td>${task.responsible}</td>`;
            tasksBody.appendChild(row);
        });

        // Jelenítsük meg a táblázatot
        document.getElementById("tasksTableContainer").style.display = "block";
    })
    .catch(error => console.error('Error:', error));
});