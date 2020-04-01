var dailyMenu = {
    Name: "Pizza Capricioasa 32 cm",
    Ingredients: "Sos de pizza, șunculița, mozzarella, ciuperci champignon, salam italian, pește anchois, măsline, capere aromate, oregano parfumat",
    Allergens: "Lactoză, Gluten",
    Price: "20,00 RON",
    isOrdered: false
}
console.log(dailyMenu);
document.getElementById("dailyMenuName").innerHTML = dailyMenu.Name;
document.getElementById('dailyMenuIngredients').innerHTML = dailyMenu.Ingredients;
document.getElementById('dailyMenuAllergens').innerHTML = dailyMenu.Allergens;
document.getElementById('dailyMenuPrice').innerHTML = dailyMenu.Price;
document.getElementById('dailyMenuisOrdered').innerHTML = "Comanda";
function Order() {
    if (dailyMenu.isOrdered) {
        document.getElementById('dailyMenuisOrdered').innerHTML = "Anuleaza comanda";
        dailyMenu.isOrdered = false;
    }
    else {
        document.getElementById('dailyMenuisOrdered').innerHTML = "Comanda";
        dailyMenu.isOrdered = true;
    }
}