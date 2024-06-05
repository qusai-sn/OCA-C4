document.getElementById("p1").addEventListener("mouseover", function(){
    
    this.innerHTML="can I help you !";  
});
document.getElementById("p1").addEventListener("mouseout", function() {
    this.innerHTML="Hello world";  
});


function changeImage(element) {
    document.querySelector("img").src = "images/" + element.value + ".jpg"
  }

  function changeImage() {
    var gameValue = document.getElementById("img").value;
    document.getElementById("select-game-picture").src = "img/game_" + gameValue + ".png";
  }