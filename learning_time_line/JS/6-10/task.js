
// // web storage , local and session . 10MG , 5MG


// // window.localStorage - stores data with no expiration date
// // window.sessionStorage - stores data for one session (data is lost when the browser tab is closed)



// // examples : 

// //check browser support for localStorage and sessionStorage:

// if (typeof(Storage) !== "undefined") {
//     console.log("localStorage/sessionStorage are supported"); 
    
//   } else {
//     console.log("localStorage/sessionStorage are not supported"); 
//   }





// //   The localStorage Object : 

// //   The setItem() method belongs to the Storage Object, which can be either a localStorage object or a sessionStorage object.

// if (typeof(Storage) !== "undefined") {
//     // Store
//     localStorage.setItem("is it working ?", "yes it's wotking "); // keY , value 
 

//     // Retrieve locally stored data 
//     document.getElementById("h2-local").innerHTML = localStorage.getItem("is it working ?");

 
//   } else {
//     document.getElementById("h2-local").innerHTML = "Sorry, your browser does not support Web Storage...";
//   }



// // using local storage to store user data locally .

// function clickCounter() {
//     if (typeof(Storage) !== "undefined") {
//       if (localStorage.clickcount) {
//         localStorage.clickcount = Number(localStorage.clickcount)+1;
//       } else {
//         localStorage.clickcount = 1;
//       }
//       document.getElementById("count-result").innerHTML = "You have clicked the button " + localStorage.clickcount + " time(s).";
//     } else {
//       document.getElementById("count-result").innerHTML = "Sorry, your browser does not support web storage...";
//     }
//   }

 
// //  reser the counter value .

//   function reset_Counter() {
//     if (typeof(Storage) !== "undefined") {
//       localStorage.clickcount = 0 ;
//       document.getElementById("count-result").innerHTML = "click count  = " + localStorage.clickcount  ;
//     } else {
//       document.getElementById("count-result").innerHTML = "Sorry, your browser does not support web storage...";
//     }
//   }



// //   The sessionStorage object is equal to the localStorage object, except that it stores the data for only one session.
// //   The data is deleted when the user closes the specific browser tab.


// function session_clickCounter() {
//     if (typeof(Storage) !== "undefined") {
//       if (sessionStorage.clickcount) {
//         sessionStorage.clickcount = Number(sessionStorage.clickcount)+1;
//       } else {
//         sessionStorage.clickcount = 1;
//       }
//       document.getElementById("session-count-result").innerHTML = "You have clicked the button " + sessionStorage.clickcount + " time(s) in this session.";
//     } else {
//       document.getElementById("session-count-result").innerHTML = "Sorry, your browser does not support web storage...";
//     }
//   }

//   function session_reset_Counter() {
//     if (typeof(Storage) !== "undefined") {
//       sessionStorage.clickcount = 0 ;
//       document.getElementById("session-count-result").innerHTML = "click count for this session  = " + sessionStorage.clickcount  ;
//     } else {
//       document.getElementById("session-count-result").innerHTML = "Sorry, your browser does not support web storage...";
//     }
//   }



