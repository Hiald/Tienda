var dMontoDelivery = 0;
$(document).ready(function () {
    $('#frm1').submit(false);
    fn_ListarCarrito();

    var valueDate = moment().format('YYYY-MM-DD hh:mm:ss');
    $('#txFechaReg').val(valueDate);

    var hddValorCuenta = $('#hddvalorCuenta').val();
    if (hddValorCuenta === "1") {
        fnRouteMain();
    }

    var valorslcTenvio = $('#slctipoEnvio option:selected').attr('value');

    if (valorslcTenvio === "1") {
        $('#divResultado1').css('display', 'block');
        $('#divResultado2').css('display', 'block');
        $('#divResultado3').css('display', 'block');
        $("#payment-paypal").prop("checked", true);
        $('#paypal').collapse('toggle');
        dMontoDelivery = 10;
        fn_ListarCarrito();
    } else {
        $('#divResultado1').css('display', 'none');
        $('#divResultado2').css('display', 'none');
        $('#divResultado3').css('display', 'none');
        $("#payment-cash").prop("checked", true);
        $('#cash').collapse('toggle');
        dMontoDelivery = 0;
        fn_ListarCarrito();
    }

    $('#slctipoEnvio').on('change', function () {
        if (this.value === "1") {
            $('#divResultado1').css('display', 'block');
            $('#divResultado2').css('display', 'block');
            $('#divResultado3').css('display', 'block');
            $("#payment-paypal").prop("checked", true);
            $('#paypal').collapse('toggle');
            dMontoDelivery = 10;
            fn_ListarCarrito();
        } else {
            $('#divResultado1').css('display', 'none');
            $('#divResultado2').css('display', 'none');
            $('#divResultado3').css('display', 'none');
            $("#payment-cash").prop("checked", true);
            $('#cash').collapse('toggle');
            dMontoDelivery = 0;
            fn_ListarCarrito();
        }
    });

    let productoCarrito = JSON.parse(localStorage.getItem('ss_productosCarrito')) || [];
    if (productoCarrito.length === 0) {
        fnRouteMain();
    }

});

function fn_ListarCarrito() {
    $('#bodyPago').html("");
    $('#divsubtotal').html();
    $('#divdelivery').html();
    $('#divtotal').html();

    let productoCarrito = JSON.parse(localStorage.getItem('ss_productosCarrito')) || [];

    var rdsubtotal = 0;
    if (productoCarrito.length === 0) {
        $('#bodyPago').html('<h6 class="widget-product-title"><a>No hay productos en el carrito, Intenta agregar algunos :) </a></h6>');
    } else {

        $.each(productoCarrito, function (index, value) {
            rdsubtotal = rdsubtotal + value.ctPrecio;

            if (index === 0) {
                $('#bodyPago').html(
                    '<div class="media align-items-center pb-2 border-bottom border-top">' +
                    '<a class="d-block mr-2">' +
                    '<img width="64" src="' + value.ctImagen.slice(1, value.ctImagen.length) + '" alt="producto" />' +
                    '</a>' +
                    '<div class="media-body">' +
                    '<h6 class="widget-product-title"><a>' + value.ctNombre + '</a></h6>' +
                    '<div class="widget-product-meta"><span class="text-accent mr-2">S/. ' + (value.ctPrecio / 100).toFixed(2) + '</span>' +
                    '<span class="text-muted">x ' + value.ctCantidad + '</span></div>' +
                    '</div>' +
                    '</div>');
            } else {
                $('#bodyPago').append(
                    '<div class="media align-items-center pb-2">' +
                    '<a class="d-block mr-2">' +
                    '<img width="64" src="' + value.ctImagen.slice(1, value.ctImagen.length) + '" alt="producto" />' +
                    '</a>' +
                    '<div class="media-body">' +
                    '<h6 class="widget-product-title"><a>' + value.ctNombre + '</a></h6>' +
                    '<div class="widget-product-meta"><span class="text-accent mr-2">S/. ' + (value.ctPrecio / 100).toFixed(2) + '</span>' +
                    '<span class="text-muted">x ' + value.ctCantidad + '</span></div>' +
                    '</div>' +
                    '</div>');
            }

        });

        $('#divsubtotal').html('S/. ' + (rdsubtotal / 100).toFixed(2));
        $('#divdelivery').html('S/. ' + (dMontoDelivery).toFixed(2));
        $('#divtotal').html('S/. ' + ((rdsubtotal + (dMontoDelivery * 100)) / 100).toFixed(2));

    }
}

function fn_RegistrarVenta() {

    // VENTA GENERAL
    var ivendedorID = 0;
    var dmonto = 0;
    var digv = 0;
    var dtotal = 0;
    var iTipoVenta = 0; // si es a domicilio o recoger en tienda
    var iTipoPago = 0; // SI ES yape o contra entrega
    var sDescripcion = $('#txNombre').val(); //nombres y apellidos del receptor del pedido
    var dComision = 0;
    var sObservacion = $('#txObservacion').val();
    var sFechaRegistro = $('#txFechaReg').val();

    if ($("#payment-paypal").is(':checked')) {
        iTipoPago = 1; //es yape
    } else {
        iTipoPago = 2; //es contra entrega
    }
    //

    // SUB VENTA
    var obj;
    var listaSubVenta = new Array();

    let productoCarrito = JSON.parse(localStorage.getItem('ss_productosCarrito')) || [];
    if (productoCarrito.length === 0) {
        fnRouteMain();
    } else {

        $.each(productoCarrito, function (index, value) {
            if (index === 0) {
                ivendedorID = value.ctVendedorId;
            }
            obj = new Object();

            obj.productoid = value.ctProductoId;
            obj.icantidad = value.ctCantidad;
            obj.dsubtotal = (value.ctPrecio / 100).toFixed(2);
            obj.sdescripcionadicional = "";
            obj.sfecha_registro = sFechaRegistro;

            listaSubVenta.push(obj);

            dmonto = dmonto + value.ctPrecio;
            dtotal = dtotal + value.ctPrecio;
        });

        digv = parseFloat((dmonto / 100) * 0.18);
    }
    //

    // ENVIO
    var valorslcTenvio = $('#slctipoEnvio option:selected').attr('value');
    var dComisionEnvio = 0;
    if (valorslcTenvio === "1") {
        iTipoVenta = 1;
    } else {
        iTipoVenta = 2;
    }

    var txDireccion = $('#txDireccion').val();
    var txCelularNumero = $('#txCelular').val();
    var iEstadoProvincia = 0;
    var iDistritoCiudad = parseInt($('#slcDistrito option:selected').attr('value'));
    //

    dmonto = dmonto / 100;
    dtotal = ((dtotal + (dMontoDelivery * 100)) / 100).toFixed(2);
    var ListaSerializada = JSON.stringify(listaSubVenta);
    if (valorslcTenvio === "1") {
        if (sDescripcion === "" || txCelularNumero === "" || txDireccion === "" || iDistritoCiudad === 0) {
            $('#cart-aviso').toast("show");
        } else {
            dComisionEnvio = 10;
            $('#modalSmall').modal({
                backdrop: 'static',
                keyboard: false,
                show: true
            });
            $('#spanTexto').html("¡Muchas gracias! Estamos guardando El pago...");

            $.ajax({
                type: "POST",
                url: gRoute + "venta/RegistrarVenta",
                async: true,
                data: {
                    "wivendedorId": ivendedorID,
                    "wdmonto": dmonto,
                    "wdigv": digv,
                    "wdtotal": dtotal,
                    "witipoventa": iTipoVenta,
                    "witipopago": iTipoPago,
                    "wsdescripcion": sDescripcion, //nombre y apellido de la persona que recogera el pedido
                    "wdcomision": dComisionEnvio,
                    "wsobservacion": sObservacion,
                    "wsfecharegistro": sFechaRegistro,
                    "wloenSubventa": ListaSerializada,
                    "wdireccion": txDireccion,  //direccion
                    "wsnumero": txCelularNumero,  //celular
                    "wiestadoprovincia": iEstadoProvincia, //ciudad
                    "wiciudad": iDistritoCiudad,
                    "wspiso": ""
                },
                success: function (data) {
                    console.log(data.iResultadoReg);
                    $('#hddRegVenta').val(data.iResultadoReg);
                    localStorage.clear();
                },
                error: function (data) {
                    console.log(data);
                }
            });

            setTimeout(function () {
                $('#spanTexto').html("");
                $('#spanTexto').html("Enviando su pedido al comerciante...");
                setTimeout(function () {
                    $('#spanTexto').html("");
                    $('#spanTexto').html("Revisando su lista para calcular tiempo...");
                    setTimeout(function () {
                        $('#spanTexto').html("");
                        $('#spanTexto').html("¡Listo! Puedes revisar el estado de tu pedido en el siguiente enlace debajo");
                        $('#spinnerLoading').css("display", "none");
                        $('#btnMiPedido').css("display", "block");
                    }, 1500);
                }, 1500);
            }, 2000);
        }

    } else {

        if (sDescripcion === "" || txCelularNumero === "") {
            $('#cart-aviso').toast("show");
        } else {
            $('#modalSmall').modal({
                backdrop: 'static',
                keyboard: false,
                show: true
            });
            $('#spanTexto').html("¡Muchas gracias! Estamos guardando El pago...");
            dComisionEnvio = 0;

            $.ajax({
                type: "POST",
                url: gRoute + "venta/RegistrarVenta",
                async: true,
                data: {
                    "wivendedorId": ivendedorID,
                    "wdmonto": dmonto,
                    "wdigv": digv,
                    "wdtotal": dtotal,
                    "witipoventa": iTipoVenta,
                    "witipopago": iTipoPago,
                    "wsdescripcion": sDescripcion, //nombre y apellido de la persona que recogera el pedido
                    "wdcomision": dComisionEnvio,
                    "wsobservacion": sObservacion,
                    "wsfecharegistro": sFechaRegistro,
                    "wloenSubventa": ListaSerializada,
                    "wdireccion": txDireccion,  //direccion
                    "wsnumero": txCelularNumero,  //celular
                    "wiestadoprovincia": iEstadoProvincia, //ciudad
                    "wiciudad": iDistritoCiudad,
                    "wspiso": ""
                },
                success: function (data) {
                    $('#hddRegVenta').val(data.iResultadoReg);
                    localStorage.clear();
                },
                error: function (data) {
                    console.log(data);
                }
            });

            setTimeout(function () {
                $('#spanTexto').html("");
                $('#spanTexto').html("Enviando su pedido al comerciante...");
                setTimeout(function () {
                    $('#spanTexto').html("");
                    $('#spanTexto').html("Revisando su lista para calcular tiempo...");
                    setTimeout(function () {
                        $('#spanTexto').html("");
                        $('#spanTexto').html("¡Listo! Puedes revisar el estado de tu pedido en el siguiente enlace debajo");
                        $('#spinnerLoading').css("display", "none");
                        $('#btnMiPedido').css("display", "block");
                    }, 1500);
                }, 1500);
            }, 2000);
        }

    }

}
