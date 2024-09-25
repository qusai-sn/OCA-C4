const cities = [
    { name: 'New York', population: 8419600 },
    { name: 'Los Angeles', population: 3980400 },
    { name: 'Chicago', population: 2716000 },
    { name: 'Houston', population: 2328000 },
    { name: 'Phoenix', population: 1690000 },
    { name: 'Philadelphia', population: 1584200 },
    { name: 'San Antonio', population: 1547200 },
    { name: 'San Diego', population: 1423800 },
    { name: 'Dallas', population: 1341000 },
    { name: 'San Jose', population: 1035300 },
    { name: 'Austin', population: 1027500 },
    { name: 'Jacksonville', population: 911500 },
    { name: 'Fort Worth', population: 918800 },
    { name: 'Columbus', population: 905700 },
    { name: 'Charlotte', population: 885700 },
    { name: 'Indianapolis', population: 876800 },
    { name: 'San Francisco', population: 881549 },
    { name: 'Seattle', population: 753675 },
    { name: 'Denver', population: 727211 },
    { name: 'Washington', population: 705749 }
];

cities.sort((a, b) => a.population - b.population);


const numbers = [3, 7, 1, 5, 9, 4, 6, 10, 2, 8, 5, 6, 7, 4, 9, 2, 10, 3, 8, 1, 5, 7, 4, 6, 9, 10, 8, 3, 2, 6, 5, 9, 4, 1, 7, 8, 10, 2, 3, 9];
let counter = {}

