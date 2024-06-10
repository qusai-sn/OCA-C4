const fs = require('fs');

const ob1 = {
    "grades 1": [78 ,78 ,98 ,44  ],
    "grades 2": [67 ,78 ,58 , 84 ],
    "grades 3": [58 ,78 ,98 ,47  ],
    "grades 4": [98 , 74 , 98 ,97]
};

const jsonString = JSON.stringify(ob1, null, 2);
fs.writeFileSync("new.json", ob1, 'utf8');

const file = fs.readFileSync("new.json", "utf8");
const parsed = JSON.parse(file);

parsed["grades 2"] = [99, 99 ,98, 87];
const str_new = JSON.stringify(parsed, null, 2);

fs.writeFileSync("new.json", str_new, 'utf8');

const final = fs.readFileSync("new.json", "utf8");
console.log("content of the file:");
console.log(final);

