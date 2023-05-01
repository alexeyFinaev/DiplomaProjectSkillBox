

function ColorBut() {
    var btn = document.getElementById("formButton");

    btn.style.visibility = "visible";
}
function OnChange() {
    var userName = document.getElementById("nameUser");
    var emaleForm = document.getElementById("emale");
    var textForm = document.getElementById("text");

    if (userName.value != "" && emaleForm.value != "" && textForm.value!= "") {

        ColorBut();
    }
}


