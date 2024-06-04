/*
1
Write a function named tellFortune that:
takes 4 arguments: number of children,
partner's name, geographic location, job title.
outputs your fortune to the screen like so:
"You will be a X in Y, and married to Z with N kids."

Ex: tellFortune('software engineer', 'Jordan', 'Alice', 3);
=> "You will be a software engineer in Jordan, and married to Alice with 3 kids."
*/

function tellFortune(n_children , p_name , location , job  ){

return  "You will be a "+job+" in "+location+", and married to "+p_name+" with "+n_children+" kids." ;

}
console.log(tellFortune(4,"Alice","Italy","Doctor"));



/*
2
Write a function named calculateDogAge that:
takes 1 argument: your puppy's age.
calculates your dog's age based on the conversion
rate of 1 human year to 7 dog years.
outputs the result to the screen like so:
"Your doggie is NN years old in dog years!"

Ex: calculateDogAge(1);
=> "Your doggie is 7 years old in dog years!"
*/

function calculateDogAge(age){
    dog_age= age*7;
    return "Your doggie is "+dog_age+" years old in dog years!"
}
console.log(calculateDogAge(3));

/*
3
Write a function named calculateSupply that:
takes 2 arguments: age, amount per day.
calculates the amount consumed for rest of the life (based on a constant max age 100).
outputs the result to the screen like so:
"You will need NN to last you until the ripe old age of X"

Ex: calculateSupply(30, 3);
=> 'You will need 76650 cups of tea to last you until the ripe old age of 100;
*/

function calculateSupply(age, amount_per_day){
    const max_age = 100 ;

    let life_span = (max_age - age)*365 ; //in days :T
    let tea_need = life_span*amount_per_day; 
    let result = "You will need "+tea_need+" cups of tea to last you until the ripe old age of 100";
    return result ;
}

console.log(calculateSupply(23,2));



/*
4
Write a function called greet that:
takes 1 argument: name.
and it will return hello + name

Ex: greet("Adam")
=> "Hello Adam"
*/

function greet(name){
    return "hello "+name;
}
console.log(greet("qusai"));


/*
5
what is the error:

function double(cat) {
  return 2 * x;
}

// asnwer : u r using an un-defined variable x ;


function double(7) {
  return 2 * 7;
}

// asnwer :u r using a value 7 in the parameter place , must be a variable tot a data ; 


function double('7') {
  return 2 * 'x';
}

// asnwer : same mistake , u r using the value "7" in the parameter place + u r doing multiplication between string and number. 


*/



/*
6
fix these functions:
func double1(x {
  return 2 * x ;
}
*/
// asnwer : 

function double1(x) {
    return 2 * x ;
  } // it was destroyed , 

/*
functiondouble2 x)
return 2 * x;
}
*/
// asnwer : 

function double2 (x){
return 2 * x;
}  

/*
function (x) double3 {
  return 2 * x;

*/

// asnwer :

function double3(x){
    return 2 * x;
}  



/*
7
Write a function called cube that:
accept 1 parameter and calculate the cube of this number

Ex: cube(4)
=> 64
*/

function cube(x){
    return x*x*x ;
}
console.log(cube(5));


/*
8
Write a function called multiply that:
accept 2 parameters and calculate the multiply of these 2 numbers

Ex: multiply(3,4)
=> 12
Ex: multiply(5,4)
=> 20
*/

function multiply(x,y){
    return x*y;
}
console.log(multiply(3,4));




/*
9
Write a function called canIGetADrivingLicense that:
accept 1 parameter represent the age
and if the age greater than or equal to 20 return "yes you can"
otherwise return "please come back after X years to get one"

Ex: canIGetADrivingLicense(21)
=> "yes you can"

Ex: canIGetADrivingLicense(17)
=> "please come back after 3 years to get one"

Ex: canIGetADrivingLicense(20)
=> "yes you can"

*/

function canIGetADrivingLicense(age){
    const legal_age = 20-age ;
    if(age=>20){
      return "yes you can";  
    }else{
       return "please come back after "+legal_age+" years to get one" ; 
    }
}
console.log(canIGetADrivingLicense(23));


/*
10
Write a function called sameLength
that accepts two strings as arguments,
and returns true if those strings have the same length, and false otherwise.

**hint: how we can know string length   Ex: : "tree".length   => 4

Ex: sameLength("tree","clue")
=> true

Ex: sameLength("tree","car")
=> false
*/

function sameLength(str1 , str2){
    if(str1.length == str2.length ){
        return true ;
    }else {
        return false ;
    }
}
console.log(sameLength("hi","hello"));


/*
11
Write a function called largerNubmer
that accept two numbers as arguments,
and return the first larger numbers

Ex: largerNubmer(5,6)
=> 6

Ex: largerNubmer(5,3)
=> 5
*/

function largerNubmer(x,y){
    if(x>y){
        return x ;
    }else{
        return y ;
    }
}


/*
12
Write a function called smallerNubmer
that accept three numbers as arguments,
and return the first smaller number

Ex: smallerNubmer(8,6,7)
=> 6

Ex: smallerNubmer(5,99,34)
=> 5

Ex: smallerNubmer(5,99,3)
=> 3

Ex: smallerNubmer(5,3,3)
=> 3
*/

function smallerNubmer(x,y,z){
    if(x<y && x<z){
        return x ;
    }else if(y<x && y<z){
        return y ;
    }else if(z<x && z<y){
        return z ;
    }
}








/*
13
Write a function called shorterString
that accept five string as an arguments,
and return the first shorter string

Ex: shorterString("air","school","car","by","github")
=> by

Ex: shorterString("air","tr","car","by","github")
=> tr

Ex: shorterString("by","tr","car","air","github")
=> by

Ex: shorterString("air","by","car","school","github")
=> by

Ex: shorterString("air","tr","by","car","github")
=> by

Ex: shorterString("air","tr","car","github","by")
=> by

*/

function shorterString(a,b,c,d,f){
    let strings = [a,b,c,d,f];
    let shortest_str = a ;

    for(i of strings){
        if(i.length < shortest_str.length){
            shortest_str = i ;
        }        
    }
    return shortest_str ;
}

/*
14
Write a function called longerString
that accept four string as an arguments,
and return the first longer string

Ex: longerString("air","school","car","github")
=> school

Ex: longerString("air","schoo","car","github")
=> github

try all the cases (change the order of the longestString)
*/


function longerString(a,b,c,d){
    let strings = [a,b,c,d];
    let longest_str = a ;

    for(i of strings){
        if(i.length > longest_str.length){
            longest_str = i ;
        }        
    }
    return longest_str ;
}




/*
15
Write a function called isEven
that accept 1 argument as a number,
and return true if this number is even
and false if this number is odd

Ex: isEven(1)
=> false
Ex: isEven(2)
=> true

*/

function isEven(x){
    if(x%2==0){
        return true ;
    }else{
        return false ;
    }
}


/*
16
Write a function called isOdd
that accept 1 argument as a number,
and return true if this number is Odd
and false if this number is Even

Ex: isOdd(4)
=> false
Ex: isOdd(5)
=> true

*/


function isOdd(x){
    if(x%2==0){
        return false ;
    }else{
        return true ;
    }
}




/*
17
Write a function called positive
that accept 1 argument as a number,
and return the positive version of the number passed

Ex: positive(4)
=> 4
Ex: positive(-5)
=> 5

*/

function positive(x){
    
    if(x<0){
        x = x*-1;
        return x ; 
    }else {
        return x ; 
    }
}


/*
18
Write a function called fullName
that accept two parameters, firstName and lastName,
and returns the firstName and lastName concatenated
together with a space in between.

Ex: fullName("Adam","McCallen")
=> "Adam McCallen"
Ex: fullName("Alex", "Mercer")
=> "Alex Mercer"
*/

function fullName(f_name, l_name){
    return f_name + " " + l_name ;
}





/*
19
Write a function called average
that takes five numbers as inputs
and returns the average of those numbers.

Ex: average(1,2,3,4,5)
=> 3

Ex: average(5,7,9,3,5)
=> 5.8

*/

function average(a,b,c,d,f){
    let avg = (a+b+c+d+f)/5;
    return avg ;
}



/*
20
Write a function called randomNumber
that didnt takes any parameter
and returns a random number between 0-1
** hint: you can seacrh using MDN

Ex: randomNumber()
=> 0.2278

Ex: randomNumber()
=> 0.475

*/

function randomNumber() {
    return Math.random();
}


/*
21
Write a function called randomBetweenNumbers
that takes 2 parameters
and returns a random number between them
** hint: you can seacrh using MDN

Ex: randomBetweenNumbers(1,8)
=> 7.5412

Ex: randomBetweenNumbers(3,100)
=> 23

*/

function randomBetweenNumbers(min,max){
    return Math.random()*(max-min) + min;
}


/*
22
Write a function called scoreInUniversty
that takes 1 parameters
and returns the alpabet in the unevirsty
A => 95-100
B => 85-94
C => 70-84
D=> 50-69
F=> 0-49

Ex: scoreInUniversty(96)
=> "A"

Ex: scoreInUniversty(3)
=> "F"

Ex: scoreInUniversty(71)
=> "C"
*/

function grades (x){

    if(x=>95 && x<=100){
        return "A";
    } else if(x=>85 && x<=94){
        return "B";
    } else if(x=>70&&x<=84){
        return "C";
    } else if(x=>50 && x<=69){
        return "D";
    } else if(x=>0 && x<=49){
        return "F";
    }
}


/*
23
Write a function called counter
that will returns a number bigger
than the one that returnd before
and start from 0

Ex: counter()
=> 1

Ex: counter()
=> 2

Ex: counter()
=> 3
*/

function counter(){
    let c = 0 ;
    return function() {
        return c++ ;
    }
}


/*
24
Write a function called resetCounter
that will reset the previuos function
and return the number before reset and
a string say that the counter reset

Ex: counter()
=> 1

Ex: counter()
=> 2

Ex: counter()
=> 3

Ex: resetCounter()
=> 3 and the counter reset now

Ex: counter()
=> 1

Ex: counter()
=> 2

Ex: resetCounter()
=> 2 and the counter reset now

Ex: counter()
=> 1
*/

function counter() {
    let c = 0;
    let counter_Function = function() {
        return c++;
    };

    counter_Function.reset = function() {
        c = 0;
    };

    return counter_Function;
}

let c = counter();
console.log(c()); 
console.log(c()); 
c.reset();
console.log(c());