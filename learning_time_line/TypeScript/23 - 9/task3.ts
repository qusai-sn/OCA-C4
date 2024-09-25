// Task 1: Verify Interface Properties
// You are given an object that follows an interface Person with properties name and age.Check if the age is 
// above 18 and print "Adult" if true, otherwise print "Minor."
interface Person { 
    name: string;
    age: number;
    check: ()=> string ;
    
}

let person : Person = { 
    name: "Yman",
    age: 27,
    check: ()=> {
        if (this.age > 18) {
            return "Adult";
        }else{
            return "Minor";
        }
    }
}

console.log(person.check());

// Task 2: Iterate Through an Array in an Interface
// You are given an object that follows an interface Teacher with properties name and 
// subjects(an array of subjects).Print all the subjects the teacher teaches.

interface Teachers {
    name : string ; 
    subjects : string [];
    printSubjects : () => void ;

}

let teacher : Teachers = {
    name : "Yman" , 
    subjects : ["Maths", "Science", "English"],
    printSubjects : function(){
        this.subjects.forEach(subject => {
            console.log(subject);
        });
    }
}

teacher.printSubjects();


// Task 3: Modify Object in an Array of Interfaces
// You are given an array of Product interfaces, where each product has a name, price, and quantity.Write a
// script to increase the price of each product by 10 % if the quantity is greater than 5.

interface Product {
    name: string;
    price: number;
    quantity: number;
}

let products: Product[] = [
    { name: "Laptop", price: 1000, quantity: 10 },
    { name: "Mouse", price: 50, quantity: 3 },
    { name: "Keyboard", price: 100, quantity: 7 },
    { name: "Monitor", price: 200, quantity: 2 }
];

interface Discount { 
    amount: number;
    products: Product[];
    discount: ()=> Product[];

}

let applyDiscount : Discount = {
    amount : 10 , 
    products: products,
    discount : function() { 
        let list : Product[] = this.products ;
        let Discounted_list : Product[]=[];
        list.forEach(product => { 
            if(product.quantity > 5){
                product.price = product.price - (product.price * this.amount / 100);
                Discounted_list.push(product);
            }
        })
        return Discounted_list;

    } 
}

console.log(applyDiscount.discount());


// Task 4 : Validate Optional Function in Interface with Default Behavior
// You have an interface Device with an optional method start().If the device has a start method, it should 
// be called, otherwise, log "Device starting with default settings."

 