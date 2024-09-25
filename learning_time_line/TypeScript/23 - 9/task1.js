// 1. Identify if a Number is Even or Odd
var num = 27;
if (num % 2 === 0) {
    console.log("".concat(num, " is even"));
}
else {
    console.log("".concat(num, " is odd"));
}
// 2. Filter Expensive Products from an Array
var prices = [100, 250, 400, 150, 500, 75];
var threshold = 200;
for (var i = 0; i < prices.length; i++) {
    if (prices[i] > threshold) {
        console.log("".concat(prices[i], " is higher than the threshold of ").concat(threshold));
    }
}
var users = [
    { name: "qusai", age: 23, isAdmin: true },
    { name: "ali", age: 25, isAdmin: false },
    { name: "bassam", age: 21, isAdmin: true },
    { name: "qusai2", age: 19, isAdmin: true },
    { name: "qusai3", age: 18, isAdmin: false }
];
var oldestAdmin = null;
for (var i = 0; i < users.length; i++) {
    if (users[i].isAdmin) {
        if (oldestAdmin === null || users[i].age > oldestAdmin.age) {
            oldestAdmin = users[i];
        }
    }
}
if (oldestAdmin !== null) {
    console.log("The oldest admin is ".concat(oldestAdmin.name, " with age ").concat(oldestAdmin.age));
}
else {
    console.log("There are no admins in the list.");
}
