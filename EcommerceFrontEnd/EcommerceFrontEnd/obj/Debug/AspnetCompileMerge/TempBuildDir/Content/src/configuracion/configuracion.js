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

    $('#tblConfiguracion').dataTable({
        "responsive": {
            "details": true,
            "columnDefs": [
                { "responsivePriority": 1 },
                { "responsivePriority": 2 }
            ]
        },
        "bServerSide": true,
        "sAjaxSource": gRoute + 'configuracion/ListarConfiguracion',
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
            { "sName": "stipoConfiguracion", "mDataProp": "stipoConfiguracion" },
            { "sName": "svalor", "mDataProp": "svalor" },
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
                        var strHtml = "<button class='btn btn-info' onclick='fn_Editar()' data-con=\"" + row.configuracionid + "|" + row.svalor + "|" + row.itipoConfiguracion + "\" id='AccessEditar' >Editar</button>";
                        return strHtml;
                    },
                    "sWidth": "5px",
                    "sClass": "css-center",
                    "bSort": false,
                    "aTargets": [2]
                },
                {
                    "mRender": function (data, type, row) {
                        var strHtml = "<button class='btn btn-warning' onclick='fn_Eliminar()' data-con=\"" + row.configuracionid + "\" id='AcessEliminar' >Eliminar</button>";
                        return strHtml;
                    },
                    "sWidth": "5px",
                    "sClass": "css-center",
                    "bSort": false,
                    "aTargets": [3]
                }
            ]
    });

});

function fn_Registrar() {
    var valueDate = moment().format('YYYY-MM-DD hh:mm:ss');
    var sValor = $('#txValor').val();
    var slcTipoAdicional = $('#slcTipoConfiguracion option:selected').attr('value');

    if (sValor === "" || slcTipoAdicional === "") {
        alert("completar los campos");
        return;
    }

    $.ajax({
        type: "POST",
        url: gRoute + "configuracion/RegistrarConfiguracion",
        data: {
            "wnombre": "",
            "wdescripcion": "",
            "wvalor": sValor,
            "itipoadicional": slcTipoAdicional,
            "wfecharegistro": valueDate
        },
        success: function (data) {

            var table = $('#tblConfiguracion').DataTable();
            table.clear().draw();
            $('#txValor').val("");
            $('#txValor').removeAttr('required');
            $('#slcTipoConfiguracion option:eq(0)').prop('selected', true);
            $('#slcTipoConfiguracion').removeAttr('required');
            $('#modalConfiguracion').modal("hide");
        },
        error: function (data) {
            console.log(data);
        }
    });

}

function fn_Limpiar() {
    var table = $('#tblConfiguracion').DataTable();
    table.clear().draw();
    $('#txValor').val("");
    $('#slcTipoConfiguracion option:eq(0)').prop('selected', true);
    $('#slcTipoConfiguracion').removeAttr('required');
}

function fn_LimpiarEditar() {
    $('#slcTipoConfiguracionEd option:eq(0)').prop('selected', true);
    $('#slcTipoConfiguracionEd').removeAttr('required');
    $('#txValorEd').prop("disabled", false);
    $('#txValorEd').val("");
}

function fn_Editar() {
    $('body').on("click", "#AccessEditar", function () {
        var id_configuracion = $(this).attr("data-con");
        var ArrayConfiguracion = id_configuracion.split("|");
        $('#hddconfiguracion').attr("data-idconfiguracion", ArrayConfiguracion[0]);
        $('#txValorEd').val(ArrayConfiguracion[1]);
        $('#slcTipoConfiguracionEd option[value="' + ArrayConfiguracion[2] + '"]').attr('selected', 'selected');

        $('#modalEditarConfiguracion').modal("show");
    });
}

function fn_Actualizar() {
    var iIdConfiguracion = $('#hddconfiguracion').attr("data-idconfiguracion");
    var iTipoConfiguracionEd = $('#slcTipoConfiguracionEd option:selected').attr('value');
    var sValorEd = $('#txValorEd').val();

    var valueDate = moment().format('YYYY-MM-DD hh:mm:ss');

    if (sValorEd === "" || iTipoConfiguracionEd === "") {
        alert("completar los campos");
        return;
    }

    $.ajax({
        type: "POST",
        url: gRoute + "configuracion/ActualizarConfiguracion",
        data: {
            "wconfiguracionid": iIdConfiguracion,
            "wnombre": "",
            "wdescripcion": "",
            "wvalor": sValorEd,
            "itipoconfiguracion": iTipoConfiguracionEd,
            "wfechamodificacion": valueDate
        },
        success: function (data) {
            $('#modalEditarConfiguracion').modal("hide");
            var table = $('#tblConfiguracion').DataTable();
            table.clear().draw();
        },
        error: function (data) {
            console.log(data);
        }
    });
}

function fn_Eliminar() {
    $('body').on("click", "#AcessEliminar", function () {
        var id_configuracion = $(this).attr("data-con");
        var ArrayConfiguracion = id_configuracion.split("|");

        $('#hddconfiguracionEliminar').attr("data-idconfiguracionEliminar", ArrayConfiguracion[0]);
        $('#modalEliminarConfiguracion').modal("show");
    });
}

function fn_ConfimarEliminar() {
    var idconfiguracion = $('#hddconfiguracionEliminar').attr("data-idconfiguracionEliminar");
    $.ajax({
        type: "POST",
        url: gRoute + "configuracion/EliminarConfiguracion",
        data: {
            "wconfiguracionid": idconfiguracion
        },
        success: function (data) {
            $('#modalEliminarConfiguracion').modal("hide");
            var table = $('#tblConfiguracion').DataTable();
            table.clear().draw();
        },
        error: function (data) {
            console.log(data);
        }
    });
}