

/*     // Bejelentkezési funkció
document.getElementById('loginForm').addEventListener('submit', function(event) {
    event.preventDefault();
    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;
    // Szerveroldali hitelesítés
    console.log('Bejelentkezési adatok:', username, password);

    // Fetch a végpontra
    fetch(`${apiUrl}/project/login`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ Email: username, Password: password })
    })
    .then(response => response.json())
    .then(data => {
        // Itt kezeld a választ (pl. kiírás vagy más feldolgozás)
        console.log('Válasz a szerverről:', data);
    })
    .catch(error => console.error('Hiba:', error));
});
 */

// Bejelentkezési funkció
document.getElementById('loginForm').addEventListener('submit', async function(event) {
    event.preventDefault();
    var username = document.getElementById('username').value;
    var password = document.getElementById('password').value;
    // Szerveroldali hitelesítés
    console.log('Bejelentkezési adatok:', username, password);

    try {
        // Fetch a végpontra
        const response = await fetch(`${apiUrl}/project/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ Email: username, Password: password })
        });

        if (response.ok) {
            const data = await response.json();
            // Visszaküldött felhasználónév kiíratása
            console.log('Visszaküldött felhasználónév:', data.Username);
            // Itt további műveleteket végezhetsz a felhasználónévvel
        } else {
            console.error('Hiba a szerver válaszában:', response.status, response.statusText);
        }
    } catch (error) {
        console.error('Hiba a fetch során:', error);
    }
});
