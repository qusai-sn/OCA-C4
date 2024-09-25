// 1. Identify if a Number is Even or Odd

let num: number = 27; 
if (num % 2 === 0) {
    console.log(`${num} is even`);
} else {
    console.log(`${num} is odd`);
}

// 2. Filter Expensive Products from an Array

let prices: number[] = [100, 250, 400, 150, 500, 75];  
let threshold: number = 200; 

for (let i: number = 0; i < prices.length; i++) {
    if (prices[i] > threshold) {
        console.log(`${prices[i]} is higher than the threshold of ${threshold}`);
    }
}

// 3. Find the Oldest Admin

interface User {
    name: string;
    age: number;
    isAdmin: boolean;
}

let users: User[] = [
    { name: "qusai", age: 23, isAdmin: true },
    { name: "ali", age: 25, isAdmin: false },
    { name: "bassam", age: 21, isAdmin: true },
    { name: "qusai2", age: 19, isAdmin: true },
    { name: "qusai3", age: 18, isAdmin: false }
];

let oldestAdmin: User | null = null;

for (let i: number = 0; i < users.length; i++) {
    if (users[i].isAdmin) {
        if (oldestAdmin === null || users[i].age > oldestAdmin.age) {
            oldestAdmin = users[i];
        }
    }
}

if (oldestAdmin !== null) {
    console.log(`The oldest admin is ${oldestAdmin.name} with age ${oldestAdmin.age}`);
} else {
    console.log("There are no admins in the list.");
}
