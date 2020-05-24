import React from "react";

export const DarkMode = () => (
  <React.Fragment>
    <form className="form-inline my-2 my-lg-0">
      <em style={{ color: "white !important" }}>Light Mode &ensp; </em>
      <div className="theme-switch-wrapper">
        <label className="theme-switch" htmlFor="checkbox">
          <input type="checkbox" id="checkbox" onClick={myFunction} />
          <div className="slider round"></div>
        </label>
        <em style={{ color: "white !important" }}>Dark Mode</em>
      </div>
    </form>
  </React.Fragment>
);

function myFunction() {
  //var element = document.getElementById("switchable");
  var element = document.body;
  element.classList.toggle("dark-mode");

  /* if (document.getElementById("SupportToggle")!.style.color != "lightblue") {
    document.getElementById("SupportToggle")!.style.color = "lightblue";
    document.getElementById("InformationToggle")!.style.color = "lightblue";
  } else {
    document.getElementById("SupportToggle")!.style.color = "blue";
    document.getElementById("InformationToggle")!.style.color = "blue";
  } */
}
