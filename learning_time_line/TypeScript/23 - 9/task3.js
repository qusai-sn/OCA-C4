var _this = this;
var person = {
    name: "Yman",
    age: 27,
    check: function () {
        if (_this.age > 18) {
            return "Adult";
        }
        else {
            return "Minor";
        }
    }
};
console.log(person.check());
var teacher = {
    name: "Yman",
    subjects: ["Maths", "Science", "English"],
    printSubjects: function () {
        this.subjects.forEach(function (subject) {
            console.log(subject);
        });
    }
};
teacher.printSubjects();
var products = [
    { name: "Laptop", price: 1000, quantity: 10 },
    { name: "Mouse", price: 50, quantity: 3 },
    { name: "Keyboard", price: 100, quantity: 7 },
    { name: "Monitor", price: 200, quantity: 2 }
];
var applyDiscount = {
    amount: 10,
    products: products,
    discount: function () {
        var _this = this;
        var list = this.products;
        var Discounted_list = [];
        list.forEach(function (product) {
            if (product.quantity > 5) {
                product.price = product.price - (product.price * _this.amount / 100);
                Discounted_list.push(product);
            }
        });
        return Discounted_list;
    }
};
console.log(applyDiscount.discount());
// Task 4 : Validate Optional Function in Interface with Default Behavior
// You have an interface Device with an optional method start().If the device has a start method, it should 
// be called, otherwise, log "Device starting with default settings."
