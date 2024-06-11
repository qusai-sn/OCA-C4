
// change paragraph text : 

document.getElementById("p1").addEventListener("mouseover", function(){
    this.innerHTML="can I help you !";  
  });
  document.getElementById("p1").addEventListener("mouseout", function() {
    this.innerHTML="Hello world";  
  });