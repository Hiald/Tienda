$(document).ready(function () {

    function enviarCompra() {
        var chk1 = $('#chk1').is(':checked');
        var chk2 = $('#chk2').is(':checked');
        var chk3 = $('#chk3').is(':checked');
        var chk4 = $('#chk4').is(':checked');
        var chk5 = $('#chk5').is(':checked');
        var chk6 = $('#chk6').is(':checked');
        var chk7 = $('#chk7').is(':checked');
        var chk8 = $('#chk8').is(':checked');
        var chk9 = $('#chk9').is(':checked');
        var chk10 = $('#chk10').is(':checked');
        var chk11 = $('#chk11').is(':checked');
        var chk12 = $('#chk12').is(':checked');

        var arrayprod = [chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8, chk9, chk10, chk11, chk12];
        console.log(arrayprod);
        /* $.ajax({
             url: vgruta + "index/enviarCompra",
             data: {
                 "wemail": wemail,
                 
             },
             cache: false,
             type: "POST",
             success: function (respuesta) {
                 console.log(respuesta);
             },
             error: function () {
                 console.log("No se ha podido obtener la información");
             }
         });
 
         $('#mcompra').modal('hide');
         $('#alertaRegistro').show();*/
    }

    function enviarVenta() {

        /* $.ajax({
             url: vgruta + "index/enviarVenta",
             data: {
                 "wemail": wemail,
                
             },
             cache: false,
             type: "POST",
             success: function (respuesta) {
                 console.log(respuesta);
             },
             error: function () {
                 console.log("No se ha podido obtener la información");
             }
         });
 
         $('#mventa').modal('hide');
         $('#alertaRegistro').show();*/
    }



});