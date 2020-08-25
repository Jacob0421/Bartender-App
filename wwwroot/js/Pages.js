function FindTotal(){
    var drinkChosen = document.getElementById("DrinkSelector").value;
    var totalTextbox = document.getElementById("TotalTxtBox");

    switch (drinkChosen) {

        case "Bourbon Old Fashioned":
            totalTextbox.value =  "$8.50";
            break;
        case "Negroni":
            totalTextbox.value = "$10.50"
            break;
        case "Manhattan":
            totalTextbox.value = "$10.00"
            break;
        case "Long Island Iced Tea":
            totalTextbox.value = "$9.00"
            break;
        case "White Russian":
            totalTextbox.value = "$9.00"
            break;
        case "Margarita":
            totalTextbox.value = "$9.00"
            break;
        case "Bloody Mary":
            totalTextbox.value = "$7.50"
            break;
        case "Dirty Martini":
            totalTextbox.value = "$12.50"
            break;
        case "Painkiller":
            totalTextbox.value = "$11.50"
            break;
        case "Aperol Spritz":
            totalTextbox.value = "$9.00 "
            break;
        case "Other":
            totalTextbox.value = "$13.50"
            break;
    }
    return;
}