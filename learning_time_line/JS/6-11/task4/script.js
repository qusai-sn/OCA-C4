document.getElementById('myForm').addEventListener('submit', function (x) {



    x.preventDefault();


    document.querySelectorAll('.error').forEach(element => element.innerHTML = '');

    const fname = document.getElementById('fname').value;
    const lname = document.getElementById('lname').value;
    const bdate = document.getElementById('bdate').value;
    const email = document.getElementById('email').value;


    const confirmEmail = document.getElementById('confirmEmail').value;
    const password = document.getElementById('password').value;
    const confirmPassword = document.getElementById('confirmPassword').value;

    let all_true = true;
    
    const nameRegex = /^[a-zA-Z]+$/;
    const dateRegex = /^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.(19|20)\d\d$/;
    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/; //IDK if this will work 

     
    if (nameRegex.test(fname) == false ) {
        document.getElementById('fnameError').innerText = ' Numbers are not allowed';
        all_true = false;
    }
    
    if ( nameRegex.test(lname) == false ) {
        document.getElementById('lnameError').innerText = ' Numbers are not allowed';
        all_true = false;
    }
     
    if ( dateRegex.test(bdate) == false ) {
        document.getElementById('bdateError').innerText = 'The format should be dd.mm.yyyy '  ;
        all_true = false;
    }

    if ( emailRegex.test(email) == false ) {

        document.getElementById('emailError').innerText = 'The e-mail is not valid'  ;
        all_true = false;
    }
    
    if (email !== confirmEmail) {

        document.getElementById('confirmEmailError').innerText = 'Emails do not match' ;
        all_true = false;
    }

    if (password !== confirmPassword) {
        document.getElementById('confirmPasswordError').innerText = 'Passwords do not match';
        all_true = false;
    }

    if (all_true) {
        alert('form submitted !');
        document.getElementById('myForm').reset();
    }
});
