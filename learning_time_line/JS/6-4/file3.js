// 1. Write a JS code to print numbers from 1 to 10

function one_to_ten ( ){
    for(let i=1 ; i<=10 ; i++){
        console.log(i);
    }
}

/*2. Write a JS code to print Even numbers in arr :
   var arr = [13,23,12,45,22,48,66,100]
*/

function even(array){
    for(i of array){
        if(i%2==0){
            console.log("even" + " : "+ i);
        }else{
            console.log("odd" + " : " + i);
        }
    }
}



/* 
3. Write a JS code to print a pattern using for loop

   1 
   1 2 
   1 2 3 
   1 2 3 4 
   1 2 3 4 5 
   1 2 3 4 5 6 
   1 2 3 4 5 6 7 
   1 2 3 4 5 6 7 8 

*/


function Pyramid() {
    var rows = 9;
    var arr = [];
    for (var i = 1; i <= rows; i++) {
      for (var j = 1; j <= i; j++) {
        arr.push(j);
        console.log(j);
      }
      console.log("\n");
    }
  }

 /* 
 Check if a string contains the letter “y”. Print “yes” if it does and “no” if it does not.
let x = "don’t know why"

*/

function check_y(str){
    let i = str.length;
    while (i--) {
      if(str.charAt(i)!='y'){
        continue ;
      }else{
        console.log("yes");
        break;
      }
    }
    console.log("no");
}