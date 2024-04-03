//Bejelentkezési funkció
document.getElementById('loginForm').addEventListener('submit', function(event)
{
event.preventDefault()
var username = document.getElementById('username').value;
var password = document.getElementById('password').value;
//szerveroldali hitelesítés 
console.log('Bejelentkezési adatok:', username, password);
});