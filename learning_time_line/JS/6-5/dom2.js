document.getElementById("add-song").addEventListener("click"  , function(){
    event.preventDefault();
    let regex = /[a-zA-Z]/;
    let song_name = document.getElementById("song-text").value ;
    
    let added_song = document.createElement("li");
    added_song.innerText = song_name ;
    if( regex.test(song_name)){
  
      document.getElementById("songs-list").appendChild(added_song);
  
    }
    document.getElementById("song-text").value = "";
  });
  
  