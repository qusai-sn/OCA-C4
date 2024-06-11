document.getElementById('userForm').addEventListener('submit', function (x) {
    x.preventDefault();

    let checkboxes = document.querySelectorAll('input[type="checkbox"]');
    const checkedValues = Array.from(checkboxes).filter(checkbox => checkbox.checked).map(checkbox => checkbox.value); // idk HOW BUT IT WORKS 
    const formData = {
        name: document.getElementById('name').value,
        age: document.getElementById('age').value,
        gender: document.getElementById('gender').value,
        birthDate: document.getElementById('birthDate').value,
        image: document.getElementById('image').value,
        description: document.getElementById('description').value,
        majorUniversity: document.getElementById('majorUniversity').value,
        siblingsNumber: document.getElementById('siblingsNumber').value,
        siblingsDescription: document.getElementById('siblingsDescription').value,
        checkboxes : checkedValues
    };

    // let name = document.getElementById('name').value;
    // let age = document.getElementById('age').value;
    // let gender = document.getElementById('gender').value;
    // let birthdate = document.getElementById('birthDate').value;
    // let image = document.getElementById('image').value;
    // let description = document.getElementById('description').value;
    // let majorUniversity = document.getElementById('majorUniversity').value;
    // let siblingsNumber = document.getElementById('siblingsNumber').value;
    // let siblingsDescription = document.getElementById('siblingsDescription').value;


    localStorage.setItem('userdata', JSON.stringify(formData));
    Card(formData);

    
    document.getElementById('userForm').reset();
});



function Card(data) {
     
    const name = document.createElement('h3');
    name.innerHTML = data.name ;

    const Age = document.createElement('p');
    Age.innerHTML = data.age ;

    const gender = document.createElement('p');
    gender.innerHTML = data.gender ;

    const birthdate = document.createElement('p');
    birthdate.innerHTML = data.birthDate ;

    const img = document.createElement('p');
    img.innerHTML = data.image ;

    const des = document.createElement('p');
    des.innerHTML = data.description ;

    const uni = document.createElement('p');
    uni.innerHTML = data.majorUniversity ;

    const siblingsNumber = document.createElement('p');
    siblingsNumber.innerHTML = data.siblingsNumber ;

    const siblingsDes = document.createElement('p');
    siblingsDes.innerHTML = data.siblingsDescription;

    const coding = document.createElement('p');
    coding.innerHTML = data.checkboxes; //THANKS GOD IT WORKS !!! CELEBRATION !

    let con = document.getElementById('cardsContainer');
    
    con.appendChild(name);
    con.appendChild(Age);
    con.appendChild(gender);
    con.appendChild(birthdate);
    con.appendChild(img);
    con.appendChild(des);
    con.appendChild(uni);
    con.appendChild(siblingsNumber);
    con.appendChild(siblingsDes);
    con.appendChild(coding);



    
}


window.onload = function() {
    const cards = JSON.parse(localStorage.getItem('cards')) || [];
    cards.forEach(displayCard);
};
