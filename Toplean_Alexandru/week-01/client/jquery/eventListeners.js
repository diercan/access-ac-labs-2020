$("#menu1Numeric").on('keyup', function () {
    var a = $(this).val();
    document.getElementById('result1').innerHTML = "Total: " +
        20 * parseInt(a) + " lei";
});
$("#menu2Numeric").on('keyup', function () {
    var a = $(this).val();
    document.getElementById('result2').innerHTML = "Total: " +
        20 * parseInt(a) + " lei";
});




