function sumArray() {
    var numbers = [10, 20, 30, 40, 50];
    var sum = 0;
    for (var i = 0; i < numbers.length; i++) {
        sum += numbers[i];
    }
    return sum;
}
var sum = sumArray();
console.log("sum: ", sum);
function AllPositive() {
    var numbers = [10, 20, 30, -40, -50];
    var result = "All Positive";
    for (var i = 0; i < numbers.length; i++) {
        if (numbers[i] < 0) {
            result = "Not All Positive";
        }
    }
    return result;
}
var string = AllPositive();
console.log(string);
function longest_Name() {
    var names = ["John", "Anna", "Peter", "Linda"];
    var longest = "";
    for (var i = 0; i < names.length; i++) {
        if (names[i].length > longest.length) {
            longest = names[i];
        }
    }
    return longest;
}
var longest = longest_Name();
console.log("the longest name is : ", longest);
function CountCharacter(a) {
    var str = "we dont have enough time !!!!";
    var character = a;
    var count = 0;
    for (var i = 0; i < str.length; i++) {
        if (str[i] == character) {
            count++;
        }
    }
    return count;
}
var count = CountCharacter("!");
console.log("the character count is ", count);
function PrimeCheck() {
    var numbers = [10, 3, 5, 8, 13, 17, 18, 23, 24];
    for (var i = 0; i < numbers.length; i++) {
        var num = numbers[i];
        var isPrime = true;
        if (num <= 1) {
            console.log(num, 'is not prime');
            continue;
        }
        for (var j = 2; j <= Math.sqrt(num); j++) {
            if (num % j === 0) {
                isPrime = false;
                break;
            }
        }
        if (isPrime) {
            console.log(num, 'is prime');
        }
        else {
            console.log(num, 'is not prime');
        }
    }
}
PrimeCheck();
