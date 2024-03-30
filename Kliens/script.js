//Bejelentkezési funkció
document.getElementById('loginForm').addEventListener('submit', function(event)
{
event.preventDefault()
var username = document.getElementById('username').value;
var password = document.getElementById('password').value;
//szerveroldali hitelesítés 
console.log('Bejelentkezési adatok:', username, password);
});

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