$(document).ready(function () {

    function fn_util_obtieneNroPagina(iDisplayStart, iDisplayLength) {
        var start = (iDisplayStart === 0 ? 1 : iDisplayStart);
        return (start / iDisplayLength) + 1;
    }

    function fn_util_AjaxWM_Obj(pstrMetodo, pParam, successFn, errorFn) {
        var oParametros = JSON.stringify(pParam);

        //Arma Parametros
        var parametro = '';
        if (oParametros === '') {
            parametro = "{}";
        } else {
            parametro = oParametros;
        }
        //Ejecuta Ajax
        $.ajax({
            type: "POST",
            url: pstrMetodo,
            contentType: "application/json; charset=utf-8",
            data: parametro,
            dataType: "json",
            async: true,
            success: function (data) {
                successFn(data);
            },
            error: errorFn
        });

    }

    $('#tblAdicional').dataTable({
        "responsive": {
            "details": true,
            "columnDefs": [
                { "responsivePriority": 1 },
                { "responsivePriority": 2 }
            ]
        },
        "bServerSide": true,
        "sAjaxSource": gRoute + 'adicional/ListarAdicional',
        "bProcessing": true,
        "sPaginationType": "full_numbers",
        "bFilter": false,
        "bSort": false,
        "language": {
            "info": "",
            "infoEmpty": "",
            "infoFiltered": "",
            "emptyTable": "No se encontraron registros",
            "sZeroRecords": "No se encontraron registros.",
            "processing": "Cargando. Por favor espere...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "sSearch": "Buscar:"
        },
        "bLengthChange": false,
        "fnDrawCallback": function (oSettings) {
            //si esta cargando la data
        },
        "aoColumns": [
            { "sName": "snombre", "mDataProp": "snombre" },
            { "sName": "sdescripcion", "mDataProp": "sdescripcion" },
            {
                "mData": "iadicionaltipo",
                "sClass": "center",
                "mRender": function (data, type, value) {
                    var sresult = "Gratuito";
                    if (value.iadicionaltipo === 1) {
                        sresult = "Con costo";
                    }
                    return sresult;
                }
            },
            {
                "mData": "dprecio",
                "sClass": "center",
                "mRender": function (data, type, value) {
                    var sresult = "S/. " + value.dprecio;
                    if (value.dprecio === 0) {
                        sresult = "Sin costo";
                    }
                    return sresult;
                }
            },
            {},
            {}
        ],
        "fnServerData": function (sSource, aoData, fnCallback, oSettings) {
            var sEcho = aoData[0].value;
            var iNroPagina = 1;
            var iCantMostrar = 1;

            var sParams = {
                "iNumeroPagina": iNroPagina,
                "iTotalPagina": iCantMostrar
            };

            oSettings.jqXHR = fn_util_AjaxWM_Obj(
                sSource,
                sParams,
                function (result) {
                    fnCallback(result);
                }, function (error) {
                    // mostrar si hay un error
                    console.log(error);
                });
        }, "aoColumnDefs":
            [
                {
                    "mRender": function (data, type, row) {
                        var strHtml = "<button class='btn btn-info' onclick='fn_Editar()' data-adi=\"" + row.adicionalid + "|" + row.snombre.toString() + "|" + row.sdescripcion.toString() + "|" + row.iadicionaltipo + "|" + row.dprecio.toString() + "\" id='AccessEditar' >Editar</button>";
                        return strHtml;
                    },
                    "sWidth": "5px",
                    "sClass": "css-center",
                    "bSort": false,
                    "aTargets": [4]
                },
                {
                    "mRender": function (data, type, row) {
                        var strHtml = "<button class='btn btn-warning' onclick='fn_Eliminar()' data-adi=\"" + row.adicionalid + "\" id='AcessEliminar' >Eliminar</button>";
                        return strHtml;
                    },
                    "sWidth": "5px",
                    "sClass": "css-center",
                    "bSort": false,
                    "aTargets": [5]
                }
            ]
    });

    $('#slcTipoAdicional').on('change', function () {
        if (this.value === "0") {
            //activado gratuito
            $('#txPrecio').prop("disabled", true);
            $('#txPrecio').val("0");
        } else {
            //activado precio
            $('#txPrecio').prop("disabled", false);
        }
    });

    $('#slcTipoAdicionalEd').on('change', function () {
        if (this.value === "0") {
            //activado promocion
            $('#txPrecioEd').prop("disabled", true);
            $('#txPrecioEd').val("0");
        } else {
            //activado precio
            $('#txPrecioEd').prop("disabled", false);
        }
    });

});

function fn_Registrar() {
    var valueDate = moment().format('YYYY-MM-DD hh:mm:ss');

    var sNombre = $('#txNombre').val();
    var sDescripcion = $('#txDescripcion').val();
    var slcTipoAdicional = $('#slcTipoAdicional option:selected').attr('value');
    var sPrecio = $('#txPrecio').val();

    if (sNombre === "" || sDescripcion === "" || slcTipoAdicional === "") {
        alert("completar los campos");
        return;
    }

    if (slcTipoAdicional === "1" && sPrecio === "" || slcTipoAdicional === "1" && sPrecio === "0") {
        alert("completar el campo precio");
        return;
    }

    var valid = /^\d{0,4}(\.\d{0,2})?$/.test(sPrecio);
    if (!valid) {
        alert("El campo precio debe ser válido ( Por ejemplo: 15.90, 9.5, 0.70 )");
        return;
    }

    if (slcTipoAdicional === "0") {
        sPrecio = 0;
    }

    $.ajax({
        type: "POST",
        url: gRoute + "adicional/RegistrarAdicional",
        data: {
            "wnombre": sNombre,
            "wdescripcion": sDescripcion,
            "wprecio": sPrecio,
            "itipoadicional": slcTipoAdicional,
            "wfecharegistro": valueDate
        },
        success: function (data) {

            var table = $('#tblAdicional').DataTable();
            table.clear().draw();
            $('#modalAdicional').modal('hide');
            $('#txNombre').val("");
            $('#modalAdicional').modal('hide');
            $('#txDescripcion').val("");
            $('#txDescripcion').removeAttr('required');
            $('#slcTipoAdicional option:eq(0)').prop('selected', true);
            $('#slcTipoAdicional').removeAttr('required');
        },
        error: function (data) {
            console.log(data);
        }
    });

}

function fn_Limpiar() {
    $('#txNombre').val("");
    $('#txNombre').removeAttr('required');
    $('#txDescripcion').val("");
    $('#txDescripcion').removeAttr('required');
    $('#slcTipoAdicional option:eq(0)').prop('selected', true);
    $('#slcTipoAdicional').removeAttr('required');
    $('#txPrecio').prop("disabled", false);
    $('#txPrecio').val("");
}

function fn_LimpiarEditar() {
    $('#txNombreEd').val("");
    $('#txNombreEd').removeAttr('required');
    $('#txDescripcionEd').val("");
    $('#txDescripcionEd').removeAttr('required');
    $('#slcTipoAdicionalEd option:eq(0)').prop('selected', true);
    $('#slcTipoAdicionalEd').removeAttr('required');
    $('#txPrecioEd').prop("disabled", false);
    $('#txPrecioEd').val("");
}

function fn_Editar() {
    $('body').on("click", "#AccessEditar", function () {
        var id_adicional = $(this).attr("data-adi");
        var ArrayAdicional = id_adicional.split("|");
        $('#hddadicional').attr("data-idadicional", ArrayAdicional[0]);
        $('#txNombreEd').val(ArrayAdicional[1]);
        $('#txDescripcionEd').val(ArrayAdicional[2]);
        if (ArrayAdicional[3] === "0") {
            $('#txPrecioEd').prop("disabled", true);
        } else {
            $('#txPrecioEd').prop("disabled", false);
        }
        $('#slcTipoAdicionalEd option[value="' + ArrayAdicional[3] + '"]').attr('selected', 'selected');
        $('#txPrecioEd').val(ArrayAdicional[4]);

        $('#modalEditarAdicional').modal("show");
    });
}

function fn_Actualizar() {
    var iIdAdicional = $('#hddadicional').attr("data-idadicional");
    var sNombreEd = $('#txNombreEd').val();
    var sDescripcionEd = $('#txDescripcionEd').val();
    var iTipoAdicionalEd = $('#slcTipoAdicionalEd option:selected').attr('value');
    var sPrecioEd = $('#txPrecioEd').val();

    var valueDate = moment().format('YYYY-MM-DD hh:mm:ss');

    if (sNombreEd === "" || sDescripcionEd === "" || iTipoAdicionalEd === "") {
        alert("completar los campos");
        return;
    }

    if (iTipoAdicionalEd === "1" && sPrecioEd === "" || iTipoAdicionalEd === "1" && sPrecioEd === "0") {
        alert("completar el campo precio");
        return;
    }

    var valid = /^\d{0,4}(\.\d{0,2})?$/.test(sPrecioEd);
    if (!valid) {
        alert("El campo precio debe ser válido ( Por ejemplo: 15.90, 9.5, 0.70 )");
        return;
    }

    if (iTipoAdicionalEd === "0") {
        sPrecioEd = 0;
    }

    $.ajax({
        type: "POST",
        url: gRoute + "adicional/ActualizarAdicional",
        data: {
            "wadicionalid": iIdAdicional,
            "wnombre": sNombreEd,
            "wdescripcion": sDescripcionEd,
            "wprecio": sPrecioEd,
            "itipoadicional": iTipoAdicionalEd,
            "wfechamodificacion": valueDate
        },
        success: function (data) {
            $('#modalEditarAdicional').modal("hide");
            var table = $('#tblAdicional').DataTable();
            table.clear().draw();

        },
        error: function (data) {
            console.log(data);
        }
    });
}

function fn_Eliminar() {
    $('body').on("click", "#AcessEliminar", function () {
        var id_adicional = $(this).attr("data-adi");
        var ArrayAdicional = id_adicional.split("|");

        $('#hddAdicionalEliminar').attr("data-idadicionalEliminar", ArrayAdicional[0]);
        $('#modalEliminarAdicional').modal("show");
    });
}

function fn_ConfimarEliminar() {
    var idadicional = $('#hddAdicionalEliminar').attr("data-idadicionalEliminar");
    $.ajax({
        type: "POST",
        url: gRoute + "adicional/EliminarAdicional",
        data: {
            "wadicionalid": idadicional
        },
        success: function (data) {
            $('#modalEliminarAdicional').modal("hide");
            var table = $('#tblAdicional').DataTable();
            table.clear().draw();
        },
        error: function (data) {
            console.log(data);
        }
    });
}