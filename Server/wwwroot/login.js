document.getElementById("loginForm").addEventListener("submit", function(event) {
    event.preventDefault(); 
    
    var email = document.getElementById("email").value;
    var password = document.getElementById("password").value;
    
    var url = `http://localhost:5148/Project/login?email=${email}&password=${password}`; 
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
        window.location.href = "index.html";
    })
    .catch(error => {
        console.error('Error:', error);
        document.getElementById("errorMessage").style.display = "block";
        document.getElementById("password").classList.add("error-input");
    });
});