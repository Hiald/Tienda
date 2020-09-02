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

    $('#tblCategoria').dataTable({
        "responsive": {
            "details": true,
            "columnDefs": [
                { "responsivePriority": 1 },
                { "responsivePriority": 2 }
            ]
        },
        "bServerSide": true,
        "sAjaxSource": gRoute + 'categoria/ListarCategoria',
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
            { "sName": "sNombre", "mDataProp": "sNombre" },
            {
                "mData": "sIconoCodigo",
                "sClass": "center",
                "mRender": function (data, type, value) {
                    return "<i class='" + value.sIconoCodigo + "' style='font-size:22px;' ></i>";
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
                        var strHtml = "<button class='btn btn-info' onclick='fn_Editar()' data-cat=\"" + row.categoriaid + "|" + row.sNombre + "|" + row.sIconoCodigo + "|" + "\" id='AccessEditar' >Editar</button>";
                        return strHtml;
                    },
                    "sWidth": "5px",
                    "sClass": "css-center",
                    "bSort": false,
                    "aTargets": [2]
                },
                {
                    "mRender": function (data, type, row) {
                        var strHtml = "<button class='btn btn-warning' onclick='fn_Eliminar()' data-cat=\"" + row.categoriaid + "|" + "\" id='AcessEliminar' >Eliminar</button>";
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
    var sNombre = $('#txNombre').val();
    var slcIcono = $('#slcIcono option:selected').attr('value');

    $.ajax({
        type: "POST",
        url: gRoute + "categoria/registrarCategoria",
        //contentType: "application/json; charset=utf-8",
        data: {
            "wnombre": sNombre,
            "wicono": slcIcono
        },
        //dataType: "json",
        //async: true,
        success: function (data) {

            var table = $('#tblCategoria').DataTable();
            table.clear().draw();
            $('#modalCategoria').modal('hide');
            $('#txNombre').val("");
            $('#txNombre').removeAttr('required');
            $('#slcIcono option:eq(0)').prop('selected', true);
            $('#slcIcono').removeAttr('required');
        },
        error: function (data) {
            console.log(data);
        }
    });

}

function fn_Limpiar() {
    $('#txNombre').val("");
}

function fn_LimpiarEditar() {
    $('#txNombre').val("");
}

function fn_Editar() {
    $('body').on("click", "#AccessEditar", function () {
        var id_categoria = $(this).attr("data-cat");
        var ArrayCategoria = id_categoria.split("|");

        $('#txNombreEditar').val(ArrayCategoria[1]);
        $('#hddcategoria').attr("data-idcategoria", ArrayCategoria[0]);
        $('#slcIconoEditar option[value="' + ArrayCategoria[2] + '"]').attr('selected', 'selected');
        var valorslc = $('#slcIconoEditar option:selected').attr('value');
        $('#iIconoEditar').removeClass();
        $('#iIconoEditar').addClass(valorslc);

        $('#modalEditarCategoria').modal("show");

    });
}

function fn_Actualizar() {
    var iIdCategoria = $('#hddcategoria').attr("data-idcategoria");
    var sNombre = $('#txNombreEditar').val();
    var slcIcono = $('#slcIconoEditar option:selected').attr('value');

    $.ajax({
        type: "POST",
        url: gRoute + "categoria/ActualizarCategoria",
        data: {
            "wcategoriaid": iIdCategoria,
            "wnombre": sNombre,
            "wcodigo": slcIcono
        },
        success: function (data) {
            $('#modalEditarCategoria').modal("hide");
            var table = $('#tblCategoria').DataTable();
            table.clear().draw();
        },
        error: function (data) {
            console.log(data);
        }
    });
}

function fn_Eliminar() {
    $('body').on("click", "#AcessEliminar", function () {
        var id_categoria = $(this).attr("data-cat");
        var ArrayCategoria = id_categoria.split("|");

        $('#hddcategoriaEliminar').attr("data-idcategoriaEliminar", ArrayCategoria[0]);
        $('#modalEliminarCategoria').modal("show");
    });
}

function fn_ConfimarEliminar() {
    var idcategoria = $('#hddcategoriaEliminar').attr("data-idcategoriaEliminar");
    $.ajax({
        type: "POST",
        url: gRoute + "categoria/EliminarCategoria",
        //contentType: "application/json; charset=utf-8",
        data: {
            "wcategoriaid": idcategoria
        },
        //dataType: "json",
        //async: true,
        success: function (data) {
            $('#modalEliminarCategoria').modal("hide");
            var table = $('#tblCategoria').DataTable();
            table.clear().draw();
        },
        error: function (data) {
            console.log(data);
        }
    });
}