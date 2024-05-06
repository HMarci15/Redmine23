const apiUrl = 'http://localhost:5148';
const socket = new WebSocket("ws://localhost:5148/ws");
const token = sessionStorage.getItem('token');
const UserName = sessionStorage.getItem('name');
const role = sessionStorage.getItem('role');
if (!token) {
    console.error('Nincs token a localStorage-ban');
    window.location.href = './login.html';
    // Itt valószínűleg valamilyen további kezelést kell végrehajtani
}

socket.onopen = (event) => {
    console.log("WebSocket sikeres !!");
};


   
    fetch(`${apiUrl}/Project/deadlineTask`,{
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
            if(data == null)
            {
                socket.send("0"); 
            }else{
                socket.send(JSON.stringify(data));
            }
        
    
});




fetch(`${apiUrl}/Project`,{
    method: 'GET',
    headers: {
        'Authorization': 'Bearer ' + token ,
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
    a.innerHTML = `Üdvözlünk, ${UserName}! Az ön rangja ${role}!`;
    const form = document.createElement('form');
    form.classList.add('d-flex');

    const logoutButton = document.createElement('button');
    logoutButton.textContent = 'Kijelentkezés';
    logoutButton.classList.add('btn');
    logoutButton.classList.add('btn-danger');
    logoutButton.setAttribute("type", "button");

    logoutButton.addEventListener('click', function () {
        sessionStorage.clear(); // Törli a nevet a localStorage-ból
        window.location.href = 'login.html'; // Átirányítás a login.html oldalra
    });

    div.appendChild(a);
    
    form.appendChild(logoutButton);
    
    div.appendChild(form);
    
    nav.appendChild(div);

    document.body.insertBefore(nav, document.body.firstChild);
}
socket.onmessage = (event) => {
    alert(`Önnek ${event.data} db közeli határidős feladata van!!`);
   
};

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
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <a href="list.html#${item.id}"><button type="button" class="btn btn-primary">Feladatok</button></a>
                        <span style="margin-right: 5px;"></span> <!-- Üres span elem a gombok között -->
                        <a href="addtask.html#${item.id}"><button type="button" class="btn btn-primary">Hozzáadás</button></a>
                    </div>
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



//deadline task

document.getElementById("showDeadlineTasksBtn").addEventListener("click", function() {
   
    fetch(`${apiUrl}/Project/deadlineTask`,{
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
      displayDeadlineTasks(data);
      document.getElementById("showDeadlineTasksBtn").style.display = "none";
      document.getElementById("hideDeadlineTasksBtn").style.display = "inline-block";
  })
  .catch(error => console.error('Hiba:', error));

});

document.getElementById("hideDeadlineTasksBtn").addEventListener("click", function() {
  document.getElementById("deadlineTasksTableContainer").style.display = "none";
  document.getElementById("hideDeadlineTasksBtn").style.display = "none";
  document.getElementById("showDeadlineTasksBtn").style.display = "inline-block";
});

function changeButtonName(buttonId, newName) {
    const button = document.getElementById(buttonId);
    if (button) {
        button.textContent = newName;
    }
} 

if(role == "Manager") {
//selftask
document.getElementById("showSelfTasksBtn").addEventListener("click", function() { // Event listener hozzáadása a saját feladatok gombhoz
   
    fetch(`${apiUrl}/Project/selfTask`, {
        method: 'GET',
        headers: {
            'Authorization': 'Bearer ' + token,
            'Content-Type': 'application/json'
        }
    }) // Másik végpont hívása
  .then(response => {
      if (!response.ok) {
          throw new Error('Hiba a válaszban');
      }
      return response.json();
  })
  .then(data => {
      console.log('Saját feladatok:', data);
      displaySelfTasks(data);
      document.getElementById("showSelfTasksBtn").style.display = "none";
      document.getElementById("hideSelfTasksBtn").style.display = "inline-block";
  })
  .catch(error => console.error('Hiba:', error));

});

document.getElementById("hideSelfTasksBtn").addEventListener("click", function() {
  document.getElementById("selfTasksTableContainer").style.display = "none";
  document.getElementById("hideSelfTasksBtn").style.display = "none";
  document.getElementById("showSelfTasksBtn").style.display = "inline-block";
});
}
else {
    document.getElementById("showSelfTasksBtn").addEventListener("click", function() { // Event listener hozzáadása a saját feladatok gombhoz
   
        fetch(`${apiUrl}/Project/selfTask`, {
            method: 'GET',
            headers: {
                'Authorization': 'Bearer ' + token,
                'Content-Type': 'application/json'
            }
        }) // Másik végpont hívása
      .then(response => {
          if (!response.ok) {
              throw new Error('Hiba a válaszban');
          }
          return response.json();
      })
      .then(data => {
          console.log('Saját feladatok:', data);
          displaySelfTasks(data);
          document.getElementById("showSelfTasksBtn").style.display = "none";
          document.getElementById("hideSelfTasksBtn").style.display = "inline-block";
      })
      .catch(error => console.error('Hiba:', error));
    
    });
    
    document.getElementById("hideSelfTasksBtn").addEventListener("click", function() {
      document.getElementById("selfTasksTableContainer").style.display = "none";
      document.getElementById("hideSelfTasksBtn").style.display = "none";
      document.getElementById("showSelfTasksBtn").style.display = "inline-block";
    });
    changeButtonName('showSelfTasksBtn', 'Összes feladat megjelenítése');
    changeButtonName('hideSelfTasksBtn', 'Összes feladat elrejtése');
    changeButtonName('selfTasksTitle', 'Összes feladat');

}

function displayDeadlineTasks(tasks) {
  const tableBody = document.getElementById('deadlineTasksBody');
  tableBody.innerHTML = ''; 

  tasks.forEach(task => {
      const row = `
          <tr>
              <td>${task.id}</td>
              <td>${task.name}</td>
              <td>${task.description}</td>
              <td>${task.date.replace('T', ' ').substring(0, 10)}</td>
          </tr>
      `;
      tableBody.innerHTML += row;
  });

  document.getElementById("deadlineTasksTableContainer").style.display = "block";
}

function displaySelfTasks(tasks) {
  const tableBody = document.getElementById('selfTasksBody');
  tableBody.innerHTML = ''; 

  tasks.forEach(task => {
      const row = `
          <tr>
              <td>${task.id}</td>
              <td>${task.name}</td>
              <td>${task.description}</td>
              <td>${task.date.replace('T', ' ').substring(0, 10)}</td>
          </tr>
      `;
      tableBody.innerHTML += row;
  });

  document.getElementById("selfTasksTableContainer").style.display = "block";
}