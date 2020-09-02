function fn_ListarCategoria() {

    //INI listar categoria
    $('#slcCategoriaA').find('option').remove();
    $.ajax({
        type: "POST",
        url: gRoute + "categoria/ListarCategoria",
        data: {
            "iNumeroPagina": 1,
            "iTotalPagina": 100
        },
        success: function (data) {
            if (data.aaData === "") {
                alert("¡No hay categorias, intenta agregar una!");
            }
            $('#slcCategoriaA').append($("<option></option>")
                .attr("value", "")
                .text("seleccione una opción"));
            $.each(data.aaData, function (index, value) {
                $('#slcCategoriaA').append($("<option></option>")
                    .attr("value", value.categoriaid)
                    .text(value.sNombre));

            });
        },
        error: function (data) {
            console.log(data);
        }
    });
    //FIN listar categoria

    $('#slcCategoriaE').find('option').remove();
    $.ajax({
        type: "POST",
        url: gRoute + "categoria/ListarCategoria",
        data: {
            "iNumeroPagina": 1,
            "iTotalPagina": 100
        },
        success: function (data) {
            if (data.aaData === "") {
                alert("¡No hay categorias, intenta agregar una!");
            }
            $('#slcCategoriaE').append($("<option></option>")
                .attr("value", "")
                .text("seleccione una opción"));
            $.each(data.aaData, function (index, value) {
                $('#slcCategoriaE').append($("<option></option>")
                    .attr("value", value.categoriaid)
                    .text(value.sNombre));

            });
        },
        error: function (data) {
            console.log(data);
        }
    });

}

$(document).ready(function () {

    $('#btnGuardar').css("display", "none");
    $('#btnActualizar').css("display", "none");
    $('#btnValidar').submit(false);

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

    $('#tblProducto').dataTable({
        "responsive": {
            "details": true,
            "columnDefs": [
                { "responsivePriority": 1 },
                { "responsivePriority": 2 }
            ]
        },
        "bServerSide": true,
        "sAjaxSource": gRoute + 'producto/ListarProductoVendedor',
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
            { "sName": "scategoria", "mDataProp": "scategoria" },
            {},
            {},
            {},
            {}
        ],
        "fnServerData": function (sSource, aoData, fnCallback, oSettings) {
            var sEcho = aoData[0].value;
            var iNroPagina = parseFloat(fn_util_obtieneNroPagina(aoData[3].value, aoData[4].value)).toFixed();
            var iCantMostrar = aoData[4].value;

            var sParams = {
                "wnombre": "",
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
                        var strHtml = "";
                        if (row.ipromociontipo === 1 && moment(row.sfecha_fin_promocion).format("YYYY-MM-DD") < moment().format("YYYY-MM-DD")) {
                            strHtml = "S/. " + row.dprecio;
                        } else if (row.ipromociontipo === 1 && moment(row.sfecha_fin_promocion).format("YYYY-MM-DD") > moment().format("YYYY-MM-DD")) {
                            strHtml = "S/. " + row.dpreciopromocion;
                        } else {
                            strHtml = "S/. " + row.dprecio;
                        }

                        return strHtml;
                    },
                    "sWidth": "5px",
                    "sClass": "css-center",
                    "bSort": false,
                    "aTargets": [2]
                },
                {
                    "mRender": function (data, type, row) {
                        var strHtml = "<a class='btn btn-info btn-sm' onclick='fn_Editar()' id='AccessEditar' rel='noopener' data-pro=\"" + row.productoid + "|" + "\" ><i class='czi-edit mr-1 d-none d-sm-inline-block'></i>Editar</a>";
                        return strHtml;
                    },
                    "sWidth": "5px",
                    "sClass": "css-center",
                    "bSort": false,
                    "aTargets": [3]
                },
                {
                    "mRender": function (data, type, row) {
                        var strHtml = "<a class='btn btn-warning btn-sm' onclick='fn_Eliminar()' id='AccessEliminar' rel='noopener' data-pro=\"" + row.productoid + "|" + "\" ><i class='czi-trash mr-1 d-none d-sm-inline-block'></i>Eliminar</a>";
                        return strHtml;
                    },
                    "sWidth": "5px",
                    "sClass": "css-center",
                    "bSort": false,
                    "aTargets": [4]
                },
                {
                    "mRender": function (data, type, row) {
                        var strHtml = "";
                        // si esta activado pero ya vencio
                        if (row.ipromociontipo === 1 && moment(row.sfecha_fin_promocion).format("YYYY-MM-DD") < moment().format("YYYY-MM-DD")) {
                            strHtml = "<a class='btn btn-info btn-sm' onclick='fn_Promocion()' id='AccessPromocion' rel='noopener' data-pro=\"" + row.productoid + "|" + 1 + "|" + row.dprecio + "|" + row.dpreciopromocion + "|" + row.sfecha_ini_promocion.toString() + "|" + row.sfecha_fin_promocion.toString() + "|" + "\" ><i class='czi-discount mr-1 d-none d-sm-inline-block'></i>renovar promoción</a>";
                            // si solo esta activado y sigue vigente
                        } else if (row.ipromociontipo === 1 && moment(row.sfecha_fin_promocion).format("YYYY-MM-DD") > moment().format("YYYY-MM-DD")) {
                            strHtml = "<a class='btn btn-info btn-sm' onclick='fn_Promocion()' id='AccessPromocion' rel='noopener' data-pro=\"" + row.productoid + "|" + 1 + "|" + row.dprecio + "|" + row.dpreciopromocion + "|" + row.sfecha_ini_promocion.toString() + "|" + row.sfecha_fin_promocion.toString() + "|" + "\" ><i class='czi-discount mr-1 d-none d-sm-inline-block'></i>Cambiar promoción</a>";
                        } else {
                            strHtml = "<a class='btn btn-success btn-sm pr-4' onclick='fn_Promocion()' id='AccessPromocion' rel='noopener' data-pro=\"" + row.productoid + "|" + 0 + "|" + row.dprecio + "|" + 0 + "|" + "null" + "|" + "null" + "\"" + "><i class='czi-discount mr-1 d-none d-sm-inline-block'></i>Activar promoción</a>";
                        }

                        return strHtml;
                    },
                    "sWidth": "5px",
                    "sClass": "css-center",
                    "bSort": false,
                    "aTargets": [5]
                }
            ]
    });

    fn_ListarCategoria();

    var valueDate = moment().format('YYYY-MM-DD hh:mm:ss');
    var valueDateFormat = moment().format('YYYY-MM-DD');
    $('#wfechareg').val(valueDate);
    $('#wfechaupdE').val(valueDate);

    $('#txFechaFin').val(valueDateFormat);
    $('#txFechaIni').val(valueDateFormat);

    $('#slcPromocionP').on('change', function () {
        if (this.value === "1") {
            //activado promocion
            $('#txPrecioP').prop("disabled", false);
            $('#txFechaIni').prop("disabled", false);
            $('#txFechaFin').prop("disabled", false);
        } else {
            //desactivado promocion
            $('#txPrecioP').prop("disabled", true);
            $('#txFechaIni').prop("disabled", true);
            $('#txFechaFin').prop("disabled", true);
            $('#txPrecioP').val("");
            $('#txFechaIni').val("");
            $('#txFechaFin').val("");
        }
    });

});

function fn_Validar() {
    var slcCategoria = $('#slcCategoriaA option:selected').attr('value');
    var txNombreA = $('#txNombreA').val();
    var txDescripcionA = $('#txDescripcionA').val();
    var txPrecioA = $('#txPrecioA').val();


    if (slcCategoria === "" || txNombreA === "" || txPrecioA === "" || txDescripcionA === ""
        || document.getElementById("flImagen1").files.length === 0
        || document.getElementById("flImagen2").files.length === 0
        || document.getElementById("flImagen3").files.length === 0) {

        alert("Falta llenar campos");
    } else {

        var valid = /^\d{0,4}(\.\d{0,2})?$/.test(txPrecioA);
        if (!valid) {
            alert("El campo precio debe ser válido ( Por ejemplo: 15.90, 9.5, 0.70 )");
        } else {
            $('#btnValidar').css("display", "none");
            $('#btnGuardar').css("display", "block");
        }


    }

}

function fn_Editar() {

    $('body').on("click", "#AccessEditar", function () {
        var id_producto = $(this).attr("data-pro");
        var ArrayProducto = id_producto.split("|");

        //id del producto
        $('#wproductoid').val(ArrayProducto[0]);

        $.ajax({
            type: "POST",
            url: gRoute + "producto/EditarProductoVendedor",
            data: {
                "wcategoriaid": ArrayProducto[0]
            },
            success: function (data) {
                var img1 = data.raData.simagen1;
                var img2 = data.raData.simagen2;
                var img3 = data.raData.simagen3;

                $('#slcCategoriaE option[value="' + data.raData.categoriaid + '"]').attr('selected', 'selected');
                $('#txNombreE').val(data.raData.snombre);
                $('#txDescripcionE').val(data.raData.sdescripcion);
                $('#txPrecioE').val(data.raData.dprecio);

                $('#flImagen1E').attr("src", img1.slice(1, img1.length));
                $('#flImagen2E').attr("src", img2.slice(1, img2.length));
                $('#flImagen3E').attr("src", img3.slice(1, img3.length));

                $('#modalEditar').modal("show");
            },
            error: function (data) {
                console.log(data);
            }
        });

        $.ajax({
            type: "POST",
            url: gRoute + "producto/EditarEspecificacion",
            data: {
                "wproductoid": ArrayProducto[0]
            },
            success: function (data) {
                var sList = "";
                $('input[name="svalorchkeditar"]').each(function () {
                    var datoinput = this;
                    $.each(data.objData, function (index, valor) {
                        if (parseInt(datoinput.value) === parseInt(valor.configuracionid)) {
                            $("#" + datoinput.id).prop('checked', true);
                        }
                    });
                });

            },

            error: function (data) {
                console.log(data);
            }
        });

        //$('#slcIconoEditar option[value="' + ArrayCategoria[2] + '"]').attr('selected', 'selected');

    });

}

function fn_Eliminar() {
    $('body').on("click", "#AccessEliminar", function () {
        var id_producto = $(this).attr("data-pro");
        var ArrayProducto = id_producto.split("|");

        $('#hddproductoEliminar').attr("data-idproductoEliminar", ArrayProducto[0]);
        $('#modalEliminarProducto').modal("show");
    });
}

function fn_ConfimarEliminar() {
    var idproducto = $('#hddproductoEliminar').attr("data-idproductoEliminar");
    $.ajax({
        type: "POST",
        url: gRoute + "producto/EliminarProducto",
        //contentType: "application/json; charset=utf-8",
        data: {
            "wproductoid": idproducto
        },
        //dataType: "json",
        //async: true,
        success: function (data) {
            $('#modalEliminarProducto').modal("hide");
            var table = $('#tblProducto').DataTable();
            table.clear().draw();
        },
        error: function (data) {
            console.log(data);
        }
    });
}

function fn_ValidarActualizar() {
    var slcProductoidE = $('#slcCategoriaE option:selected').attr('value');
    var txNombreE = $('#txNombreE').val();
    var txDescripcionE = $('#txDescripcionE').val();
    var txPrecioE = $('#txPrecioE').val();

    var valid = /^\d{0,4}(\.\d{0,2})?$/.test(txPrecioE);
    if (slcProductoidE === "" || txNombreE === "" || txPrecioE === "" || txDescripcionE === "") {
        alert("Falta llenar campos");
    } else if (!valid) {
        alert("El campo precio debe ser válido ( Por ejemplo: 15.90, 9.5, 0.70 )");
    } else {
        $('#btnValidarEditar').css("display", "none");
        $('#btnActualizar').css("display", "block");
    }
    
}

function fn_Actualizar() {

    var iIdproducto = $('#wproductoid').val();
    var slcCategoria = $('#slcCategoriaE option:selected').attr('value');

    var sNombreE = $('#txNombreE').val();
    var sDescripcionE = $('#txDescripcionE').val();
    var sPrecioE = $('#txPrecioE').val();
    var sfechaActual = $('#wfechaupdE').val();

    $.ajax({
        type: "POST",
        url: gRoute + "producto/ActualizarProducto",
        data: {
            "wproducto_id": iIdproducto,
            "wmarca": "",
            "wcategoria": slcCategoria,
            "wnombre": sNombreE,
            "wdescripcion": sDescripcionE,
            "wmaterial": "",
            "wprecio": sPrecioE,
            "wmodelo": "",
            "wmedida": "",
            "wimagen1": "",
            "wimagen2": "",
            "wimagen3": "",
            "wimagen4": "",
            "wimagen5": "",
            "wpeso": 0,
            "wfechamod": sfechaActual,
            "wmodificado": 1
        },
        success: function (data) {
            
            var table = $('#tblProducto').DataTable();
            table.clear().draw();
        },
        error: function (data) {
            console.log(data);
        }
    });

    $('input[name="svalorchkeditar"]').each(function () {
        if (this.checked === false) {
            console.log(this.value);
        }
    });

    $('#modalEditar').modal("hide");

}

function fn_Promocion() {
    $('body').on("click", "#AccessPromocion", function () {
        var id_producto = $(this).attr("data-pro");
        var ArrayProducto = id_producto.split("|");
        if (ArrayProducto[1] === "1") {

            $('#hddpromocionProducto').attr("data-idpromocionProducto", ArrayProducto[0]);
            $('#hddpromocionProducto').attr("data-itipoPromocionProducto", ArrayProducto[1]);
            $('#hddpromocionProducto').attr("data-dprecioProducto", ArrayProducto[2]);
            $('#hddpromocionProducto').attr("data-dpreciopromocionProducto", ArrayProducto[3]);
            $('#hddpromocionProducto').attr("data-sfechainiProducto", ArrayProducto[4]);
            $('#hddpromocionProducto').attr("data-sfechafinProducto", ArrayProducto[5]);

            $('#txPrecioPromocion').html("Precio actual: S/ " + ArrayProducto[2]);
            $('#slcPromocionP option[value="' + "1" + '"]').attr('selected', 'selected');
            $('#txPrecioP').val(ArrayProducto[3]);

            $('#txFechaIni').val(moment(ArrayProducto[4]).format('YYYY-MM-DD'));
            $('#txFechaFin').val(moment(ArrayProducto[5]).format('YYYY-MM-DD'));
        } else {
            $('#hddpromocionProducto').attr("data-idpromocionProducto", ArrayProducto[0]);
            $('#hddpromocionProducto').attr("data-itipoPromocionProducto", ArrayProducto[1]);
            $('#hddpromocionProducto').attr("data-dprecioProducto", ArrayProducto[2]);
            $('#hddpromocionProducto').attr("data-dpreciopromocionProducto", 0);
            $('#hddpromocionProducto').attr("data-sfechainiProducto", "");
            $('#hddpromocionProducto').attr("data-sfechafinProducto", "");

            $('#txPrecioPromocion').html("Precio actual: S/ " + ArrayProducto[2]);
            $('#slcPromocionP option[value="' + "0" + '"]').attr('selected', 'selected');
            $('#txPrecioP').prop("disabled", true);
            $('#txFechaIni').prop("disabled", true);
            $('#txFechaFin').prop("disabled", true);
        }


        $('#modalPromocionProducto').modal("show");
    });
}

function fn_ConfimarPromocion() {
    var idproducto = $('#hddpromocionProducto').attr("data-idpromocionProducto");
    var slcPromocionP = $('#slcPromocionP option:selected').attr('value');
    var txPrecioP = $('#txPrecioP').val();
    var txFechaFinP = $('#txFechaFin').val();
    var txFechaIni = $('#txFechaIni').val();

    var precioAntiguo = $('#hddpromocionProducto').attr("data-dprecioProducto");
    if (parseFloat(txPrecioP) > parseFloat(precioAntiguo)) {
        alert("El precio de promoción no puede ser mayor al precio regular");
        return;
    }

    if (txPrecioP.length === 0 && slcPromocionP === "1") {
        alert("Ingrese un monto");
        return;
    }

    if (moment(txFechaIni).format("YYYY-MM-DD") < moment().format("YYYY-MM-DD") && slcPromocionP === "1") {
        alert("El inicio de la promoción no puede ser antes de hoy");
        return;
    }

    if (moment(txFechaFinP).format("YYYY-MM-DD") < moment().format("YYYY-MM-DD") && slcPromocionP === "1") {
        alert("El fin de la promoción no puede ser antes de hoy");
        return;
    }

    if (slcPromocionP === "1") {
        var valid = /^\d{0,4}(\.\d{0,2})?$/.test(txPrecioP);
        if (!valid) {
            alert('por favor ingrese un monto monetario (ejemplo:  15.5, 4.5)');
        } else {
            var txPrecioPromocion = $('#txPrecioP').val();
            if (txFechaIni.length === 0 || txFechaFinP.length === 0 || txFechaFinP === "" || txFechaIni === "") {
                alert("Por favor ingrese un fecha válida");
            } else {

                $.ajax({
                    type: "POST",
                    url: gRoute + "producto/ActivarPromocionProducto",
                    data: {
                        "wproductoid": idproducto,
                        "wprecio": 0, //este campo no esta habilitado en el SP
                        "wtipopromocion": slcPromocionP,
                        "wpreciopromocion": txPrecioPromocion,
                        "wfechainipromocion": txFechaIni,
                        "wfechafinpromocion": txFechaFinP
                    },
                    success: function (data) {
                        $('#modalPromocionProducto').modal("hide");

                        var table = $('#tblProducto').DataTable();
                        table.clear().draw();
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            }
        }
    } else {
        $.ajax({
            type: "POST",
            url: gRoute + "producto/ActivarPromocionProducto",
            data: {
                "wproductoid": idproducto,
                "wprecio": 0, //este campo no esta habilitado en el SP
                "wtipopromocion": 0,
                "wpreciopromocion": 0,
                "wfechainipromocion": "",
                "wfechafinpromocion": ""
            },
            success: function (data) {
                $('#modalPromocionProducto').modal("hide");

                var table = $('#tblProducto').DataTable();
                table.clear().draw();
            },
            error: function (data) {
                console.log(data);
            }
        });
    }




}