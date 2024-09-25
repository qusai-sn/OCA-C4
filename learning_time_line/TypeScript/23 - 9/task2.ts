function sumArray( ): number {
    let numbers = [10, 20, 30, 40, 50];   
    let sum = 0;   

    for (let i = 0; i < numbers.length; i++) {
        sum += numbers[i];  
    }

    return sum;
}

let sum = sumArray();
console.log("sum: ", sum); 

function AllPositive(): string {

    let numbers = [10, 20, 30, -40, -50];
    let result : string = "All Positive";

    for (let i = 0; i < numbers.length; i++) {

        if (numbers[i] < 0) {
            result = "Not All Positive";  
        }

    }

    return result ;   
}
let string = AllPositive();
console.log(string);  


function longest_Name() : string {
    let names = ["John", "Anna", "Peter", "Linda"];
    let longest : string = "";

    for(let i = 0 ; i < names.length ; i++ ){
        if(names[i].length > longest.length ){
            longest = names[i];
    }}

    return longest;
}

let longest : string = longest_Name();
console.log("the longest name is : ", longest);

function CountCharacter(a : string) : number { 

    let str = "we dont have enough time !!!!";
    let character : string = a;
    let count : number = 0;

    for(let i = 0 ; i<str.length ; i++){
        if(str[i] == character){
            count++;
        }
    }
    return count ;
}

let count : number = CountCharacter("!");
console.log("the character count is ", count);

function PrimeCheck(): void { 
    let numbers = [10, 3, 5, 8, 13, 17, 18, 23, 24];

    for (let i = 0; i < numbers.length; i++) {

        let num: number = numbers[i];
        let isPrime: boolean = true;

        if (num <= 1) {
            console.log(num, 'is not prime');
            continue;  
        }

        for (let j = 2; j <= Math.sqrt(num); j++) {
            if (num % j === 0) {
                isPrime = false;
                break;   
            }
        }

        if (isPrime) {
            console.log(num, 'is prime');
        } else {
            console.log(num, 'is not prime');
        }
    }
}

 
PrimeCheck();


 
