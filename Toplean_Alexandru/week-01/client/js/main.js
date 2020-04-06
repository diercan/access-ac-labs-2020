function redirectTo(url){
    window.location.href=url;
}

function addTimisoaraOptions(){
    alert("Here");
    element = document.getElementById("regionSelect"); 
    element.disabled = false;
    option = document.createElement("option");
    option.text="Sagului";
    element.add(option);
}

function addRegions(){
    alert("region");
}

function toggleContent(option) {
  var x = document.getElementById(option);
  
  
  if (x.style.display === "none") {
    x.style.display = "block";
    //bacl
   
  


  } else {
    x.style.display = "none";
    
    //alert( document.getElementById("hiddenContent").display);
   // alert(parent.classList);
    

  }
}

function expand(id){
  var element = document.getElementById(id);
  if(element.style.display === "block")
    element.style.display="none";
  else
    element.style.display= "block";
}

function expandIcon(animal){
  switch(animal){
      case "chicken":{
          
          var chicken=document.getElementById("chicken");
          if(chicken.clientWidth== 300){
      
              document.getElementById("chicken").classList.add("normal");
              document.getElementById("pig").classList.add("normal");
              document.getElementById("cow").classList.add("normal");
              document.getElementById("fish").classList.add("normal");
              document.getElementById("pigText").innerHTML="Pig";
              document.getElementById("cowText").innerHTML="Cow";
              document.getElementById("fishText").innerHTML="Fish";
          }
          else{

              if(chicken.clientWidth== 100){
                  chicken.classList.remove("normal");
                  chicken.classList.remove("shrink");
                  chicken.classList.add("expand");
          document.getElementById("pig").classList.remove("normal");
          document.getElementById("pig").classList.add("shrink");

          document.getElementById("cow").classList.remove("normal");
          document.getElementById("cow").classList.add("shrink");

          document.getElementById("fish").classList.remove("normal");
          document.getElementById("fish").classList.add("shrink");


          
          document.getElementById("pigText").innerHTML="";
          document.getElementById("cowText").innerHTML="";
          document.getElementById("fishText").innerHTML="";
          }
      }

          break;
      }
      case "pig":{
          
          var pig=document.getElementById("pig");
          if(pig.clientWidth== 300){
   
              document.getElementById("chicken").classList.add("normal");
              document.getElementById("pig").classList.add("normal");
              document.getElementById("cow").classList.add("normal");
              document.getElementById("fish").classList.add("normal");
              document.getElementById("chickenText").innerHTML="Chicken";
              document.getElementById("cowText").innerHTML="Cow";
              document.getElementById("fishText").innerHTML="Fish";
          }
          else{

              if(pig.clientWidth== 100){
          pig.classList.remove("normal");
          pig.classList.remove("shrink");
          pig.classList.add("expand");
      
          document.getElementById("chicken").classList.remove("normal");
          document.getElementById("chicken").classList.add("shrink");

          document.getElementById("cow").classList.remove("normal");
          document.getElementById("cow").classList.add("shrink");

          document.getElementById("fish").classList.remove("normal");
          document.getElementById("fish").classList.add("shrink");


          
          document.getElementById("chickenText").innerHTML="";
          document.getElementById("cowText").innerHTML="";
          document.getElementById("fishText").innerHTML="";
          }
      }

          break;
      }
      case "cow":{
          
          var cow=document.getElementById("cow");
          if(cow.clientWidth== 300){
           
              document.getElementById("chicken").classList.add("normal");
              document.getElementById("pig").classList.add("normal");
              document.getElementById("cow").classList.add("normal");
              document.getElementById("fish").classList.add("normal");
              document.getElementById("pigText").innerHTML="Pig";
              document.getElementById("chickenText").innerHTML="Chicken";
              document.getElementById("fishText").innerHTML="Fish";
          }
          else{

              if(cow.clientWidth== 100){
                  cow.classList.remove("normal");
                  cow.classList.remove("shrink");
                  cow.classList.add("expand");
          document.getElementById("pig").classList.remove("normal");
          document.getElementById("pig").classList.add("shrink");

          document.getElementById("chicken").classList.remove("normal");
          document.getElementById("chicken").classList.add("shrink");

          document.getElementById("fish").classList.remove("normal");
          document.getElementById("fish").classList.add("shrink");


          
          document.getElementById("pigText").innerHTML="";
          document.getElementById("chickenText").innerHTML="";
          document.getElementById("fishText").innerHTML="";
          }
      }

          break;
      }
      case "fish":{
          
          var fish=document.getElementById("fish");
          if(fish.clientWidth== 300){
           
              document.getElementById("chicken").classList.add("normal");
              document.getElementById("pig").classList.add("normal");
              document.getElementById("cow").classList.add("normal");
              document.getElementById("fish").classList.add("normal");
              document.getElementById("pigText").innerHTML="Pig";
              document.getElementById("chickenText").innerHTML="Chicken";
              document.getElementById("cowText").innerHTML="Cow";
          }
          else{

              if(fish.clientWidth== 100){
                  fish.classList.remove("normal");
                  fish.classList.remove("shrink");
                  fish.classList.add("expand");
          document.getElementById("pig").classList.remove("normal");
          document.getElementById("pig").classList.add("shrink");

          document.getElementById("chicken").classList.remove("normal");
          document.getElementById("chicken").classList.add("shrink");

          document.getElementById("cow").classList.remove("normal");
          document.getElementById("cow").classList.add("shrink");


          
          document.getElementById("pigText").innerHTML="";
          document.getElementById("chickenText").innerHTML="";
          document.getElementById("cowText").innerHTML="";
          }
      }

          break;
      }
  }
}