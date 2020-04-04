function myFunction() {
    //var element = document.getElementById("switchable");
    element = document.body;
    element.classList.toggle("dark-mode");

    if(document.getElementById("SupportToggle").style.color != "lightblue")
    {
        document.getElementById("SupportToggle").style.color="lightblue";
        document.getElementById("InformationToggle").style.color="lightblue";
    }
    else{
        document.getElementById("SupportToggle").style.color="blue";
        document.getElementById("InformationToggle").style.color="blue";
    }
   
 }


