

// let x = 250 ;
// create variable Calculate the value of zakat for x ,If you know the percentage of zakat = 2.5 %; 


//1 

let x = 250 ;
let zakat = x*0.025 ;





//2
 
// [ 1,7  9  45, ]
 let array1 = [ 1,7 , 9 , 45 ];

 // ["Str" "alex","moh"
 let array2 = ["Str", "alex", "moh", "the", "fox", "over", "lazy", "dog"]; 

 let array3 = ['the','foxx','over','lazy','dog'];


 // you forget the ","
 // you forget the declaration
 // can't leave last element empty


 
// What the index of "Banana","Tomato"
var fruits=["Tomato","Banana","Watermelon"];
let index_Banana = fruits.indexOf("Banana"); //index is 1
let indexTomato = fruits.indexOf("Tomato"); //index is 0
 





/*
3
Create an array represents your:
1- Favorite Food (2)
2- Favorite Sport (3)
3- Favorite Movie (2)
*/

let qusai = ["mansaf","boxing","the pianest"];
let Food = ["mansaf", "shawarma"];
let Sport = ["Football", "boxing", "MMA"];
let Movie = ["the pianest", "one piece 10"];





/*
4
Create a Variable to return the first element in an array 
Ex: firstOfArray([1,4,5]) => 1
Ex: firstOfArray(["t","u","g","x"]) => "t"
*/

let array_one = [1,4,5];
let array_two = ["t","u","g","x"];

let index_one = array_one[0];
let index_two = array_two[0];





/*
5
Create a Variable to return the lastOfArray element in an array 
Ex: lastOfArray([1,4,5]) => 5
Ex: lastOfArray(["t","u","g","x"]) => "x"
*/
                      
let array_1 = [1,4,5];
let last_index =  array_1[ array_1.length - 1]

var chars = ["t","u","g","x"];
let last_index2 =char[chars.length-1];
/*
6
Using console make this array to be like this one (push, unshift, shift, pop)
var array = [0,5,7,9]
=> [1,3,4,6,8,9,10]
*/

// this is text formating : 

let arr4 =  [1,3,4,6,8,9,10];
let text = "";
for(i of arr4){
    if (i !== arr4[arr4.length-1]){
        text += i +", ";
    } else {
        text += i;
    }
}
console.log("("+text+")")


// another answer : 

var array = [0, 5, 7, 9];

array.pop();
array.shift();
array.shift();
array.shift();
array.unshift(1);
array.push(10);

array.push(3, 4, 6, 8);

console.log(array);




/*
7
Using the console try to figure out what the thing thats (push, unshift, shift, pop) return to you

var array2 = [5,9,-7,3.5]
*/
var arr10 = [5,9,-7,3.5];
arr10.pop();
arr10.unshift(1, 3, 4, 6, 8);
arr10.shift();
arr10.pop();
console.log(arr10); 






/*
8.
Write a JavaScript program to sort the items of an array.
Sample array : var arr1 = [ -3, 8, 7, 6, 5, -4, 3, 2, 1 ];
Sample Output : -4,-3,1,2,3,5,6,7,8
*/
let arr9 = [ -3, 8, 7, 6, 5, -4, 3, 2, 1 ];

arr9.sort((a, b) => a - b);

console.log(arr9);