// ...
if (response.ok) {
    const data = await response.json();
    // Visszaküldött felhasználónév kiíratása
    console.log('Visszaküldött felhasználónév:', data.Username);
    // Felhasználónév kiíratása a HTML-be
    document.getElementById('loggedInUser').textContent = `Bejelentkezett felhasználó: ${data.Username}`;
    // Itt további műveleteket végezhetsz a felhasználónévvel
} else {
    console.error('Hiba a szerver válaszában:', response.status, response.statusText);
}
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