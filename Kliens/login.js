document.getElementById("loginForm").addEventListener("submit", function(event) {
    event.preventDefault(); 
    
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    
    var url = `http://localhost:5148/Login?email=${email}&password=${password}`; 
    var formData = { 
        email: email,
        password: password
    };
    
    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(formData),
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    })
    .then(data => {
        console.log('Success:', data);
        const name = data.name; // Kiszűrjük a név attribútumot
        const header = document.createElement('h1'); // Létrehozunk egy új h1 elemet
        header.textContent = `Üdvözöllek, ${name}!`; // Beállítjuk a fejléc szövegét a név alapján
        document.body.insertBefore(header, document.body.firstChild); // Beszúrjuk a fejlécet az index.html fájl elejére
        //window.location.href = "index.html"; // Ez az átirányítást letiltjuk ideiglenesen
    })
    
    
    .catch(error => {
        console.error('Error:', error);
        document.getElementById("errorMessage").style.display = "block";
        document.getElementById("password").classList.add("error-input");
    });
});