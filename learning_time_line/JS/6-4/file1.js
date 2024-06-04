/* 1. Write a JavaScript program that accept two integers and
 * display the larger.Go to the editor */
/******* Start Your Code *********/
  
function larger ( a ,b ){
    if(a>b){
        return a ;
    }else {
        return b
    }
}
let q1 = larger(3,5);
console.log(q1);


 /******* End Your Code ********* */



/* 2. Write a JavaScript conditional statement to find the sign
 of product of three numbers. Display an alert box with the 
 specified sign. Go to the editor 
Sample numbers : 3, -7, 2 
Output : The sign is - */
/******* Start Your Code *********/
  
function sign ( a ,b , c){
    
    let array_1 = [3, -7, 2 ];
    for( i of array_1){
        if(i>0){
            alert(" the sign is +");
        }else{
            alert(" the sign is -");
        }
    }
}
let q2 = sign();
console.log(q2);




 /******* End Your Code ********* */



/* 3. Write a JavaScript conditional statement to sort three numbers. Display an alert box to show the result. Go to the editor 
Sample numbers : 0, -1, 4 
Output : 4, 0, -1 */


/******* Start Your Code *********/
  
function sorting (a , b , c ){
     let sorted = [] ; 
     if (a > b && a > c ){
        if (b>c){
            sorted = [a , b ,c];
            alert(sorted);
        }else{
            sorted = [a , c , b];
            alert(sorted);
        }
     }else if (b > a && b > c  ){
        if (a>c){
            sorted = [b , a , c];
            alert(sorted);
        }else{
            sorted = [b , c , a];
            alert(sorted);
        }

     }else if(c > b && c > a ) {
        if (a>b){
            sorted = [c , a , b];
            alert(sorted);
        }else{
            sorted = [c , b , a];
            alert(sorted);
        }
     }  
}


let q3 = sorting(0, -1, 4);
 

 /******* End Your Code ********* */





/*4. Write a JavaScript conditional statement to find the largest of five numbers. 
Display an alert box to show the result. Go to the editor 
Sample numbers : -5, -2, -6, 0, -1 
Output : 0 */

/******* Start Your Code *********/
  

function largest (a, b ,c ,d ,f ){

    
    if (a>b && a>c && a>d && a>f){
        alert(a);
    } else if (b>a && b > c && b > d && b > f) {
        alert(b);
    } else if (c > a && c > b && c > d && c > f) {
        alert(c);
    } else if (d > a && d > c && d > b && d > f) {
        alert(d);
    } else {
        alert(f);
    } 

}
 


 /******* End Your Code ********* */





 /* 5.Write the if statement to display "Hello World" if x is greater than y, otherwise alert "Goodbye".*/
/******* Start Your Code *********/
  
function hello(x,y){
    if(x>y){
        alert("hello world ");
    }else {
        alert("Goodby");
    }

}

 /******* End Your Code ********* */