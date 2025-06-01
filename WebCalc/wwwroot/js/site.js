// wwwroot/js/site.js

document.addEventListener("DOMContentLoaded", function () {
    // Obtenemos referencias a los elementos del DOM
    var operationSelect = document.getElementById("operation");
    var inputBGroup = document.getElementById("group-inputB");
    var inputBField = document.getElementById("inputB");

    function toggleInputB() {
        // Si la operación seleccionada es "sum", "sub", "mul" o "pow", necesitamos el campo B
        // Si es "div", también necesitamos B. Para "sin", "cos", "tan", "log", "sqrt", no se usa B.
        var op = operationSelect.value;
        if (op === "sin" || op === "cos" || op === "tan" || op === "log" || op === "sqrt") {
            inputBGroup.style.display = "none";
            inputBField.value = ""; // Limpiamos cualquier valor existente
        } else {
            inputBGroup.style.display = "block";
        }
    }

    // Llamamos a la función al cargar la página para establecer el estado inicial
    toggleInputB();

    // Cada vez que el usuario cambie la operación, volteamos la visibilidad del campo B
    operationSelect.addEventListener("change", toggleInputB);
});