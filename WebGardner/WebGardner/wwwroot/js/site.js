// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var objHomeHeader = document.getElementById("homeHeader");
var objHomeP = document.getElementById("homeP");

objHomeHeader.addEventListener("mouseover", greenText);
objHomeHeader.addEventListener("mouseout", blackText);
objHomeP.addEventListener("mouseover", greenText);
objHomeP.addEventListener("mouseout", blackText);

function greenText(event) {
    var target = event.target;
    target.style.color = "greenyellow";
}
function blackText(event) {
    var target = event.target;
    target.style.color = "black";
}

//var objHex = document.getElementById("hexId");

//objHex.addEventListener("input",isHex);


//var inputString = "";
//var maxHexValue = "FFFF";

//var zero = "0".charCodeAt(0);
//var F = "F".charCodeAt(0);

//function isHex(event) {
//    if ((!between(event.charCodeAt(last), zero, F)) && inputString > maxHexValue)
//    {
//        alert("Invalid input. Value must be Hexadecimal");
//        objHex.value = "";
//        inputString = "";
//    }
//    else {
//        inputString += event;
//    }
//}
//function between(x, min, max) {
//    return x >= min && x <= max;
//}
