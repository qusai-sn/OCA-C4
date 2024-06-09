document.getElementById("p1").addEventListener("mouseover", function(){
    
    this.innerHTML="can I help you !";  
});
document.getElementById("p1").addEventListener("mouseout", function() {
    this.innerHTML="Hello world";  
});



document.getElementById("blue").addEventListener("click", function(){
  document.getElementById("blue").style.backgroundColor = "red";
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

