/* 1. Write a JavaScript program that returns rate as text
less than 50 return ==> Fail
equal or between 50 and 59 ===> E
equal or between 60 and 69 ===> D
equal or between 70 and 79 ===> C
equal or between 80 and 89 ===> B
equal or between 90 and 100 ===> A
*/



 

function grades (x){

    if(x=>90 && x<=99){
        return "A";
    } else if(x=>80 && x<=89){
        return "B";
    } else if(x=>70&&x<=79){
        return "C";
    } else if(x=>60 && x<=69){
        return "d";
    } else if(x=>50 && x<=59){
        return "E";
    }else {
        return "Fail";
    }

}

let grade = grades(77);
alert(grade);