function ListarReporteVenta(iventatipo) {
    $.ajax({
        type: "POST",
        url: gRoute + "vendedor/ListarReporteVenta",
        data: {
            "wventatipo": iventatipo
        },
        success: function (data) {
            console.log(data.rDato);
            $('#spnVentas').html("S/. " + data.rDato[0].total_dec);
            $('#hTotalVenta').html(data.rDato[0].venta_number);
            var ConteoMoneda = data.rDato[0].total_dec.toString().length;
            $('#pGanancia').html("S/. " + data.rDato[0].total_dec);

            $('#pSaldo').html("S/. " + data.rDato[0].total_dec);

            $('#pGananciaGeneral').html("S/. " + data.rDato[0].total_dec);

        },
        error: function (data) {
            console.log(data);
        }
    });

}

function ListarReporteEnvio(iestadoenvio) {
    $.ajax({
        type: "POST",
        url: gRoute + "vendedor/ListarReporteEnvio",
        data: {
            "westadoenvio": iestadoenvio
        },
        success: function (data) {
            console.log(data.rDato);
        },
        error: function (data) {
            console.log(data);
        }
    });


}

$(document).ready(function () {
    ListarReporteVenta(1);
    ListarReporteEnvio(4);
});