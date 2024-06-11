
const cardContainer = document.getElementById('card-container'); 

fetch('https://66681676f53957909ff67af8.mockapi.io/users/Students')
    .then((response) => response.json())
    .then((products) => {

        products.forEach((product) => {


            const name = product.name;
            const id = product.id ;  

            const input = createForm(id , name );
            cardContainer.appendChild(input);
        });
    })
    .catch((error) => {
        console.error('Error fetching data:', error);
    });


    function createForm(id , name) {
        
        const form = document.createElement('div');
        form.classList.add('form-div');

        const input1 = document.createElement('input');
        input1.classList.add('form-control-lg');

        const input2 = document.createElement('input');
        input2.classList.add('form-control-lg');
    
         input1.value = "id : " + id ;
         input2.value = "name : " + name ;
    
        form.appendChild(input1);

        form.appendChild(input2);
        
        return form;
    }
    


     
// [
//     {
//       "id": 4,
//       "title": "Handmade Fresh Table",
//       "price": 687,
//       "description": "Andy shoes are designed to keeping in...",
//       "category": {
//         "id": 5,
//         "name": "Others",
//         "image": "https://placeimg.com/640/480/any?r=0.591926261873231"
//       },
//       "images": [
//         "https://placeimg.com/640/480/any?r=0.9178516507833767",
//         "https://placeimg.com/640/480/any?r=0.9300320592588625",
//         "https://placeimg.com/640/480/any?r=0.8807778235430017"
//       ]
//     }
//     // ...
//   ]

// https://mockapi.io/projects   , u must try this .


// const cardContainer = document.getElementById('card-container');

// function createCard(title, content, id , price_1) {
//     const card = document.createElement('div');
//     card.classList.add('card');

//     const cardTitle = document.createElement('h2');
//     cardTitle.textContent = "discreption :"+title;

//     const cardContent = document.createElement('p');
//     cardContent.textContent = "discreption :"+content;

//     const h2 = document.createElement('h2');
//     h2.textContent = "id : "+id;

//     const price = document.createElement('h3');
//     price.textContent = "price : "+price_1+" $";

//     card.appendChild(h2);
//     card.appendChild(cardTitle);
//     card.appendChild(price);
//     card.appendChild(cardContent);

//     console.log(" id is "+id);
//     console.log(" title is "+title);
//     console.log("this is the "+content);
//     console.log("-----------");

//     return card;
// }



// fetch('https://api.escuelajs.co/api/v1/products')
//     .then((response) => response.json())
//     .then((products) => {
//         products.forEach((product) => {


//             const title = product.title;
//             const description = product.description;
//             const id = product.id ;  
//             const price = product.price ;

             
//             const card = createCard(title, description,  id , price );
//             cardContainer.appendChild(card);

             
//         });
//     })
//     .catch((error) => {
//         console.error('Error fetching data:', error);
//     });


