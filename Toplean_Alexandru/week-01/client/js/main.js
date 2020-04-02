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