 // Select animal : 


  // [{"name":"Cats","image":"https://static.toiimg.com/thumb/msid-107091667,width-960,height-1280,resizemode-6.cms","id":"1"},{"name":"Dogs","image":"https://static.vecteezy.com/system/resources/thumbnails/005/857/332/small_2x/funny-portrait-of-cute-corgi-dog-outdoors-free-photo.jpg","id":"2"},{"name":"Bees","image":"https://static.scientificamerican.com/sciam/cache/file/B4B598E9-EC22-49E3-878F75A8BBA41699_source.jpg?w=1200","id":"3"},{"name":"Butterfly","image":"https://t3.ftcdn.net/jpg/03/49/57/86/240_F_349578650_GFxBqYI9mLOXCiN4FDS4wsIWKzJVGU5M.jpg","id":"4"}]
 
 function change_image(value) {

  fetch('https://66681676f53957909ff67af8.mockapi.io/users/Animals').then((response) => response.json()).then((animals) => {
    
    const selected = animals.find(

      function(x) {
          console.log(x);
          return x.name === value;

    });


    if (selected) {

      const src = selected.image;
      const id = selected.id ;
      const name = selected.name ;

      document.getElementById("img").src = src;
      document.getElementById("animal-id").innerHTML = "ID :  " + id ;
      document.getElementById("animal-name").innerHTML = "this ^ is a "+ name + " btw." ;

      console.log("image changes");
    } else {
      console.error('not found in the API');
    }
  })
   
}

  

  
 