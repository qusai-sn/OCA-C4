let click_count = 0;
document.getElementById("blue").addEventListener("click", function(){
    if (click_count %2===0) {
        document.getElementById("blue").style.backgroundColor = "red";
        console.log("clicked red");
    } else {
        document.getElementById("blue").style.backgroundColor = "blue";
        console.log("clicked blue");
    }
    
    click_count++;
});

