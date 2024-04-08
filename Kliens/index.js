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
            <td>
                <a href="list.html"><button type="button" class="btn btn-primary">Listázás</button></a>
                <a href="addtask.html"><button type="button" class="btn btn-primary">Hozzáadás</button></a>
            </td>
        </tr>

    `;
    tableBody.innerHTML += row;
});
}

// ...
// if (response.ok) {
//     const data = await response.json();
//     // Visszaküldött felhasználónév kiíratása
//     console.log('Visszaküldött felhasználónév:', data.Username);
//     // Felhasználónév kiíratása a HTML-be
//     document.getElementById('loggedInUser').textContent = `Bejelentkezett felhasználó: ${data.Username}`;
//     // Itt további műveleteket végezhetsz a felhasználónévvel
// } else {
//     console.error('Hiba a szerver válaszában:', response.status, response.statusText);
// }
// ...


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
    table = document.getElementById("taskTableBody"); // Módosítás: "taskTableBody"-ra változtatva
    tr = table.getElementsByTagName("tr");
    for (i = 0; i < tr.length; i++) {
      td = tr[i].getElementsByTagName("td")[1]; // Módosítás: a "td" elem indexét "1"-re változtatva, hogy a "Projekt neve" oszlop szerint keressen
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


