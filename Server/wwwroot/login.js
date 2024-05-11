document.getElementById("loginForm").addEventListener("submit", function(event) {
    event.preventDefault(); 
    
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    
    // Jelszó hashelése
    hashel(password)
    .then(hasheltPassword => {
        var url = `http://localhost:5148/Login?email=${email}&password=${hasheltPassword}`;
        
        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
        })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            console.log('Success:', data);
            const name = data.name;
            const token = data.token;
            sessionStorage.setItem('token', token);
            sessionStorage.setItem('name', name); // Tároljuk a nevet
            sessionStorage.setItem('role', data.role); // Tároljuk a szerepkört
            console.log(localStorage.getItem('token'));
            window.location.href = "index.html"; // Átirányítás az index.html-re
        })
        .catch(error => {
            console.error('Error:', error);
            document.getElementById("errorMessage").style.display = "block";
            document.getElementById("password").classList.add("error-input");
        });
    });
});

// Jelszó hashelés
async function hashel(input) {
    const encoder = new TextEncoder();
    const data = encoder.encode(input);
    const hashBuffer = await window.crypto.subtle.digest('SHA-256', data);
    const hashArray = Array.from(new Uint8Array(hashBuffer));
    const hashHex = hashArray.map(byte => byte.toString(16).padStart(2, '0')).join('');
    return hashHex;
}
