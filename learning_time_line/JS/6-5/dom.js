document.addEventListener('DOMContentLoaded', function() {



let password = document.getElementById("password");
let repeat_password = document.getElementById("repeat-password");
document.getElementById("submit").style.visibility = "hidden";  

let error_count = 0 ;
password.addEventListener("change" , function(){

   let pass_string = password.value ; 
   let re_pass_string = repeat_password.value ;
   
   console.log(pass_string  );

   if(pass_string.length < 6){
    console.log("too short ");
    document.getElementById("error-1").innerHTML = "too short";
    }else{
    document.getElementById("error-1").innerHTML = " ";
   }

  if(pass_string!=re_pass_string){
    document.getElementById("error-2").innerHTML = "passwords didn't match";
    console.log( "passwords didn't match");
  }else{
    document.getElementById("error-2").innerHTML = " ";
    console.log( "passwords match");
  }
  console.log( re_pass_string);
  if (pass_string !== re_pass_string || pass_string.length < 6) {
    document.getElementById("submit").style.visibility = "hidden";
    console.log("hidden");
} else {
    document.getElementById("submit").style.visibility = "visible";
    console.log("visible");
}

     
});

repeat_password.addEventListener("change" , function(){

  let pass_string = password.value ; 
  let re_pass_string = repeat_password.value ;
  
  if(pass_string!=re_pass_string){
    document.getElementById("error-2").innerHTML = "passwords didn't match";
    console.log( "passwords didn't match");
  }else{
    document.getElementById("error-2").innerHTML = " ";
    console.log( "passwords match");
  }
  console.log( re_pass_string);

  if (pass_string !== re_pass_string || pass_string.length < 6) {
    document.getElementById("submit").style.visibility = "hidden";
    console.log("hidden");
} else {
    document.getElementById("submit").style.visibility = "visible";
    console.log("visible");
}

    
});

 




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




document.getElementById("p1").addEventListener("mouseover", function(){
  this.innerHTML="can I help you !";  
});
document.getElementById("p1").addEventListener("mouseout", function() {
  this.innerHTML="Hello world";  
});











function change_flag(value) {
  document.getElementById("img").src = value;
}
function change_size(value) {
  document.getElementById("p-2").style.fontSize = value;
}
function change_family(value) {
  document.getElementById("p-2").style.fontFamily = value;
}

  function change_style() {
    var p_2 = document.getElementById("p-2");
    var italic  = document.getElementById("italic");
    var bold  = document.getElementById("bold");
    var underline  = document.getElementById("underline");
  
    p_2.style.fontStyle = italic.checked ? "italic" : "normal";
    p_2.style.fontWeight = bold.checked ? "bold" : "normal";
    p_2.style.textDecoration = underline.checked ? "underline" : "none";
  }

});


