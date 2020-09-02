function fn_ListarEnvio() {
    $('#divPedido').html("");

    $.ajax({
        type: "POST",
        url: gRoute + "envio/ListarEnvioVendedor",
        success: function (data) {
            $('#spCantidad').text(data.iDatoCount);

            if (data.iDatoCount === 0) {
                $('#divPedido').html(
                    '<div class="media d-block d-sm-flex align-items-center py-4 ml-4 border-bottom">'
                    + '<h3 class="h6 product-title mb-2">'
                    + '<i class="czi-truck"></i>'
                    + '<a>&nbsp;&nbsp;' + 'No hay envíos pendientes de envío' + '</a>'
                    + '</h3>'
                    + '</div>'
                );
            } else {
                $.each(data.rDato, function (index, value) {
                    if (index === 0) {
                        var paramfecha1 = fn_CargarFecha(value.sfecha_entrega_date);
                        var paramhora1 = fn_CargarHora(value.hora_entrega);
                        $('#divPedido').html(
                            '<div class="media d-block d-sm-flex align-items-center py-4 ml-4 border-bottom">'
                            + '<div class="media-body text-center text-sm-left">'
                            + '<h6 class="h6 product-title mb-2"> Número pedido: ' + value.envioid + '</h6>'
                            + '<h3 class="h6 product-title mb-2">'
                            + '<i class="czi-truck"></i>'
                            + '<a>&nbsp;&nbsp;' + fn_CargarDistrito(value.iciudad_num) + " - " + value.sdireccion_desc + '</a>'
                            + '</h3>'
                            + '<div class="d-inline-block text-accent">Fecha programada: ' + paramfecha1 + ' &nbsp;&nbsp;</div>'
                            + '<div class="d-inline-block text-accent"> ' + paramhora1 + ' </div>'
                            + '<br />'
                            + '<div class="d-inline-block text-muted font-size-ms">'
                            + '<span class="font-weight-medium" style="font-size:16px"> Estado: ' + value.sestado_envio_type + '</span>'
                            + '</div>'
                            + '<div class="d-flex justify-content-center justify-content-sm-start pt-3">'
                            + "<button class='btn bg-success btn-icon mr-2 text-light' type='button' onclick='fn_ProgramarEnvio(" + value.envioid + ", \"" + value.sestado_envio_type + "\"" + ");'><i class='czi-time'></i>&nbsp;Programar envio</button>"
                            + "<button class='btn btn-info' type='button' onclick='fn_VerDetalle(" + value.ventaid + ")' >Ver Detalle</button>"
                            + '</div>'
                            + '</div>'
                            + '</div>'
                        );
                    } else {
                        var paramfecha = fn_CargarFecha(value.sfecha_entrega_date);
                        var paramhora = fn_CargarHora(value.hora_entrega);
                        $('#divPedido').append(
                            '<div class="media d-block d-sm-flex align-items-center py-4 ml-4 border-bottom">'
                            + '<div class="media-body text-center text-sm-left">'
                            + '<h6 class="h6 product-title mb-2"> Número pedido: ' + value.envioid + '</h6>'
                            + '<h3 class="h6 product-title mb-2">'
                            + '<i class="czi-truck"></i>'
                            + '<a>&nbsp;&nbsp;' + fn_CargarDistrito(value.iciudad_num) + " - " + value.sdireccion_desc + '</a>'
                            + '</h3>'
                            + '<div class="d-inline-block text-accent">Fecha programada: ' + paramfecha + ' &nbsp;&nbsp;</div>'
                            + '<div class="d-inline-block text-accent"> ' + paramhora + ' </div>'
                            + '<br />'
                            + '<div class="d-inline-block text-muted font-size-ms">'
                            + '<span class="font-weight-medium" style="font-size:16px"> Estado: ' + value.sestado_envio_type + '</span>'
                            + '</div>'
                            + '<div class="d-flex justify-content-center justify-content-sm-start pt-3">'
                            + "<button class='btn bg-success btn-icon mr-2 text-light' type='button' onclick='fn_ProgramarEnvio(" + value.envioid + ", \"" + value.sestado_envio_type + "\"" + ");'><i class='czi-time'></i>&nbsp;Programar envio</button>"
                            + "<button class='btn btn-info' type='button' onclick='fn_VerDetalle(" + value.ventaid + ")' >Ver Detalle</button>"
                            + '</div>'
                            + '</div>'
                            + '</div>'
                        );
                    }

                });

            }

        },
        error: function (data) {
            console.log(data);
        }
    });

}

function fn_VerDetalle(envioid) {
    $('#txOrdenCodigo').html("Detalles del pedido - Número " + envioid);

    $.ajax({
        type: "POST",
        url: gRoute + "envio/ListarVentaUsuario",
        async: false,
        data: {
            "widventaid": envioid
        },
        success: function (data) {
            $('#ModalDetalleVenta').modal("show");

            $.each(data.rDatoV, function (index, value) {
                if (index === 0) {
                    $('#spanTotal').html("");
                    $('#spanEnvio').html("");

                    $('#spanUsuario').html(value.susuarioNombre);
                    $('#spanRecepciona').html(value.spagodescripcion);
                    $('#spanObservacion').html(value.sobservacion);

                    $('#spanTotal').html("S/. " + value.dtotal.toFixed(2));
                    $('#spanEnvio').html("S/. " + value.dcomision.toFixed(2));
                    $('#spanTipoEnvio').html(value.stipoventa);
                    $('#spanMetodoPago').html(value.stipopago);
                }

            });

        },
        error: function (data) {
            fnRouteMain();
        }
    });

    $.ajax({
        type: "POST",
        url: gRoute + "envio/ListarSubVentaUsuario",
        data: {
            "wiventaid": envioid
        },
        success: function (data) {

            $.each(data.rDato, function (index, value) {
                if (index === 0) {
                    var img = value.sproductoimagen1;
                    $('#divModalBody').html(
                        '<div class="d-sm-flex justify-content-between mb-4 pb-3 pb-sm-2 border-bottom">'
                        + '<div class="media d-block d-sm-flex text-center text-sm-left">'
                        + '<a class="d-inline-block mx-auto mr-sm-4" style="width: 10rem;">'
                        + '<img src="' + img.slice(1, img.length) + '" alt="Producto" style="height:140px;width:150px;">'
                        + '</a>'
                        + '<div class="media-body pt-2">'
                        + '<h3 class="product-title font-size-base mb-2"><a>' + value.sproductonombre + '</a></h3>'
                        + '</div>'
                        + '</div>'
                        + '<div class="pt-2 pl-sm-3 mx-auto mx-sm-0 text-center">'
                        + '<div class="text-muted mb-2">Cantidad:</div>' + value.icantidad
                        + '</div>'
                        + '<div class="pt-2 pl-sm-3 mx-auto mx-sm-0 text-center">'
                        + '<div class="text-muted mb-2">Subtotal</div> S/. ' + value.dsubtotal.toFixed(2)
                        + '</div>'
                        + '</div>'
                    );

                } else {
                    var img1 = value.sproductoimagen1;
                    $('#divModalBody').append(
                        '<div class="d-sm-flex justify-content-between mb-4 pb-3 pb-sm-2 border-bottom">'
                        + '<div class="media d-block d-sm-flex text-center text-sm-left">'
                        + '<a class="d-inline-block mx-auto mr-sm-4" style="width: 10rem;">'
                        + '<img src="' + img1.slice(1, img1.length) + '" alt="Producto" style="height:140px;width:150px;">'
                        + '</a>'
                        + '<div class="media-body pt-2">'
                        + '<h3 class="product-title font-size-base mb-2"><a>' + value.sproductonombre + '</a></h3>'
                        + '</div>'
                        + '</div>'
                        + '<div class="pt-2 pl-sm-3 mx-auto mx-sm-0 text-center">'
                        + '<div class="text-muted mb-2">Cantidad:</div>' + value.icantidad
                        + '</div>'
                        + '<div class="pt-2 pl-sm-3 mx-auto mx-sm-0 text-center">'
                        + '<div class="text-muted mb-2">Subtotal</div> S/. ' + value.dsubtotal.toFixed(2)
                        + '</div>'
                        + '</div>'
                    );

                }

            });

        },
        error: function (data) {
            fnRouteMain();
        }
    });

}

function fn_ProgramarEnvio(idenvio, iestado) {
    $('#ModalActualizarPedido').modal("show");

    $('#txModalEstado').html("Estado actual: " + iestado);
    $('#hddEnvio').val(idenvio);
}

function fn_ConfirmarProgramacion() {
    var slcEstadoEnvio = parseInt($('#slcEstadoEnvio option:selected').attr('value'));
    var txFechaEntrega = $('#txFechaEntrega').val();
    var txHoraEntrega = $('#txHoraEntrega').val();
    var ientregadoTipo = 0;
    var FechaActualizacion = moment().format('YYYY-MM-DD HH:mm:ss');

    if (slcEstadoEnvio === 0) {
        return alert("Completar los campos");
    }

    var valueDateHour = "";
    if (txHoraEntrega === "") {
        alert("Ingresar la hora estimada de envio");
    } else {
        if (moment("10-10-2020 " + txHoraEntrega).format('HH:mm') < moment().format('HH:mm') && moment(txFechaEntrega).format('YYYY-MM-DD') < valueDateFormat) {
            alert("La hora no puede ser menor a la actual");
        } else {
            valueDateHour = moment("10-10-2020 " + txHoraEntrega).format('HH:mm');
        }
    }

    var valueDateFormat = moment().format('YYYY-MM-DD');

    if (moment(txFechaEntrega).format('YYYY-MM-DD') < valueDateFormat) {
        alert("La fecha no puede ser menor a la actual");
    } else {

        if (slcEstadoEnvio === 3) {
            ientregadoTipo = 1;
        } else {
            ientregadoTipo = 0;
        }
        var sParamFecha = moment(txFechaEntrega).format('YYYY-MM-DD');
        var ienvioID = $('#hddEnvio').val();
        $.ajax({
            type: "POST",
            url: gRoute + "envio/ActualizarEnvio",
            async: false,
            data: {
                "wenvioid": ienvioID,
                "wentregadoTipo": slcEstadoEnvio,
                "westadoEnvio": slcEstadoEnvio,
                "wfechaEntrega": sParamFecha,
                "whoraEntrega": valueDateHour,
                "wfechaModificacion": FechaActualizacion
            },
            success: function (data) {
                fnRouteMain();
            },
            error: function (data) {
                fnRouteMain();
            }
        });

    }

}


function fn_CargarDistrito(idDistrito) {
    var sreturn = "";
    switch (idDistrito) {
        case 1: sreturn = "ATE"; break;
        case 2: sreturn = "BARRANCO"; break;
        case 3: sreturn = "CERCADO DE LIMA"; break;
        case 4: sreturn = "CHORRILLOS"; break;
        case 5: sreturn = "CIENEGUILLA"; break;
        case 6: sreturn = "COMAS"; break;
        case 7: sreturn = "EL AGUSTINO"; break;
        case 8: sreturn = "INDEPENDENCIA"; break;
        case 9: sreturn = "JESUS MARIA"; break;
        case 10: sreturn = "LA MOLINA"; break;
        case 11: sreturn = "LA VICTORIA"; break;
        case 12: sreturn = "LINCE"; break;
        case 13: sreturn = "LOS OLIVOS"; break;
        case 14: sreturn = "LURIN"; break;
        case 15: sreturn = "MAGDALENA DEL MAR"; break;
        case 16: sreturn = "PUEBLO LIBRE"; break;
        case 17: sreturn = "MIRAFLORES"; break;
        case 18: sreturn = "RIMAC"; break;
        case 19: sreturn = "SAN BORJA"; break;
        case 20: sreturn = "SAN ISIDRO"; break;
        case 21: sreturn = "SAN JUAN DE LURIGANCHO"; break;
        case 22: sreturn = "SAN JUAN DE MIRAFLORES"; break;
        case 23: sreturn = "SAN LUIS"; break;
        case 24: sreturn = "SAN MARTIN DE PORRES"; break;
        case 25: sreturn = "SAN MIGUEL"; break;
        case 26: sreturn = "SANTA ANITA"; break;
        case 27: sreturn = "SANTIAGO DE SURCO"; break;
        case 28: sreturn = "SURQUILLO"; break;
        case 29: sreturn = "VILLA EL SALVADOR"; break;
        case 30: sreturn = "VILLA MARIA DEL TRIUNFO"; break;
        case 31: sreturn = "ANCON"; break;
        case 32: sreturn = "CARABAYLLO"; break;
        case 33: sreturn = "CHACLACAYO"; break;
        case 34: sreturn = "PACHACAMAC"; break;
        case 35: sreturn = "PUCUSANA"; break;
        case 36: sreturn = "PUENTE PIEDRA"; break;
        case 37: sreturn = "PUNTA HERMOSA"; break;
        case 38: sreturn = "PUNTA NEGRA"; break;
        case 39: sreturn = "SAN BARTOLO"; break;
        case 40: sreturn = "SANTA MARIA DEL MAR"; break;
        case 41: sreturn = "SANTA ROSA"; break;
        case 42: sreturn = "CHOSICA (LURIGANCHO)"; break;
        case 43: sreturn = "BREÑA"; break;
    }

    return sreturn;

}

function fn_CargarEstado(iestado) {
    var sreturn = "";
    switch (iestado) {
        case 1: sreturn = "Esperando tiempo de envío"; break;
        case 2: sreturn = "Procesando orden en camino"; break;
        case 3: sreturn = "Entregando en domicilio"; break;
        case 4: sreturn = "Orden finalizada"; break;
        case 5: sreturn = "Reprogramando el tiempo de llegada"; break;
        case 6: sreturn = "Enviando el reembolso"; break;
        case 7: sreturn = "Reembolsado"; break;
        default: sreturn = "Aún no definido"; break;
    }

    return sreturn;
}

function fn_CargarFecha(sfecha) {
    var sreturn = "";
    switch (sfecha) {
        case "-": sreturn = "Falta definir una fecha y hora de envío"; break;
        default: sreturn = sfecha.slice(0,10); break;
    }

    return sreturn;
}

function fn_CargarHora(shora) {
    var sreturn = "";
    switch (shora) {
        case "-": sreturn = ""; break;
        default: sreturn = shora; break;
    }

    return sreturn;
}

$(document).ready(function () {
    fn_ListarEnvio();

    $('#txFechaEntrega').val(moment().format("YYYY-MM-DD"));

});
