function fn_ActualizarMonto() {
    $('#modalCart').modal({
        backdrop: 'static',
        keyboard: false,
        show: true
    });

    var sumatotal = 0;

    let productoCarrito = JSON.parse(localStorage.getItem('ss_productosCarrito')) || [];

    if (productoCarrito.length === 0) {
        $('#csubtotal').html("S/. 0.00");
    } else {
        $.each(productoCarrito, function (index, value) {
            sumatotal = sumatotal + value.ctPrecio;
        });
        $('#csubtotal').html("");
        $('#csubtotal').html("S/. " + (sumatotal / 100).toFixed(2));
    }

    setTimeout(function () {
        $('#modalCart').modal("hide");
        $('#cart-upd').toast('show');
    }, 1000);
}

function fn_EliminarCarro(productoId) {
    $('#modalCart').modal({
        backdrop: 'static',
        keyboard: false,
        show: true
    });

    let storageProducts = JSON.parse(localStorage.getItem('ss_productosCarrito'));
    let products = storageProducts.filter(product => product.ctProductoId !== productoId);
    localStorage.setItem('ss_productosCarrito', JSON.stringify(products));
    fn_ListadoCarrito();

    var sumatotal = 0;

    let productoCarrito = JSON.parse(localStorage.getItem('ss_productosCarrito')) || [];

    if (productoCarrito.length === 0) {
        $('#csubtotal').html("S/. 0.00");
    } else {
        $.each(productoCarrito, function (index, value) {
            sumatotal = sumatotal + value.ctPrecio;
        });
        $('#csubtotal').html("");
        $('#csubtotal').html("S/. " + (sumatotal / 100).toFixed(2));
    }


    setTimeout(function () {
        $('#modalCart').modal("hide");
        $('#cart-infdel').toast('show');
    }, 1000);


}

function fn_ListadoCarrito() {
    $('#body-carrito').html("");

    let productoCarrito = JSON.parse(localStorage.getItem('ss_productosCarrito')) || [];

    if (productoCarrito.length === 0) {
        $('#body-carrito').html('<div class="d-sm-flex justify-content-between align-items-center my-4 pb-3 border-bottom">' +
            '<h3 class="h3 text-dark mb-0">No hay productos en el carrito, ¡Agrega algunos!</h3></div>');
    } else {
        $.each(productoCarrito, function (index, value) {
            if (index === 0) {
                $('#body-carrito').html(
                    '<div class="d-sm-flex justify-content-between align-items-center my-4 pb-3 border-bottom">' +
                    '<div class="media media-ie-fix d-block d-sm-flex align-items-center text-center text-sm-left">' +
                    '<a class="d-inline-block mx-auto mr-sm-4" style="width: 10rem;">' +
                    '<img src="' + value.ctImagen.slice(1, value.ctImagen.length) + '" alt="Producto" style="width:180px;height:180px;"></a>' +
                    '<div class="media-body pt-2">' +
                    '<h3 class="product-title font-size-base mb-2">' +
                    '<a>' + value.ctNombre + '</a></h3>' +
                    '<div class="font-size-sm"><span class="text-muted mr-2">Size:</span>8.5</div>' +
                    '<div class="font-size-sm"><span class="text-muted mr-2">Color:</span>White &amp; Blue</div>' +
                    '<div class="font-size-lg text-accent pt-2"> S/. ' + (value.ctPrecio / 100).toFixed(2) + '</div>' +
                    '</div>' +
                    '</div>' +
                    '<div class="pt-2 pt-sm-0 pl-sm-3 mx-auto mx-sm-0 text-center text-sm-left" style="max-width: 9rem;">' +
                    '<div class="form-group mb-0">' +
                    '<label class="font-weight-medium" for="slcCantidad">Cantidad</label>' +
                    '<input class="form-control" type="number" id="slcCantidad' + value.ctProductoId + '" value="' + value.ctCantidad + '">' +
                    '</div>' +
                    '<button class="btn btn-link px-0 text-danger" type="button" onclick="fn_EliminarCarro(' + value.ctProductoId + ')">' +
                    '<i class="czi-close-circle mr-2"></i><span class="font-size-sm">Remover</span></button >' +
                    '<button class="btn btn-outline-accent" type="button" id="btnActualizarCarro" onclick="fn_ActualizarCarrito(' + value.ctProductoId + "," + value.ctCantidad + ')">' +
                    '<i class="czi-loading font-size-base mr-2"></i>Actualizar</button>' +
                    '</div>' +
                    '</div>'
                );
            } else {
                $('#body-carrito').append(
                    '<div class="d-sm-flex justify-content-between align-items-center my-4 pb-3 border-bottom">' +
                    '<div class="media media-ie-fix d-block d-sm-flex align-items-center text-center text-sm-left">' +
                    '<a class="d-inline-block mx-auto mr-sm-4" style="width: 10rem;">' +
                    '<img src="' + value.ctImagen.slice(1, value.ctImagen.length) + '" alt="Producto" style="width:180px;height:180px;"></a>' +
                    '<div class="media-body pt-2">' +
                    '<h3 class="product-title font-size-base mb-2">' +
                    '<a>' + value.ctNombre + '</a></h3>' +
                    '<div class="font-size-sm"><span class="text-muted mr-2">Size:</span>8.5</div>' +
                    '<div class="font-size-sm"><span class="text-muted mr-2">Color:</span>White &amp; Blue</div>' +
                    '<div class="font-size-lg text-accent pt-2"> S/. ' + (value.ctPrecio / 100).toFixed(2) + '</div>' +
                    '</div>' +
                    '</div>' +
                    '<div class="pt-2 pt-sm-0 pl-sm-3 mx-auto mx-sm-0 text-center text-sm-left" style="max-width: 9rem;">' +
                    '<div class="form-group mb-0">' +
                    '<label class="font-weight-medium" for="slcCantidad">Cantidad</label>' +
                    '<input class="form-control" type="number" id="slcCantidad' + value.ctProductoId + '" value="' + value.ctCantidad + '">' +
                    '</div>' +
                    '<button class="btn btn-link px-0 text-danger" type="button" onclick="fn_EliminarCarro(' + value.ctProductoId + ')">' +
                    '<i class="czi-close-circle mr-2"></i><span class="font-size-sm">Remover</span></button >' +
                    '<button class="btn btn-outline-accent" type="button" id="btnActualizarCarro" onclick="fn_ActualizarCarrito(' + value.ctProductoId + "," + value.ctCantidad + ')">' +
                    '<i class="czi-loading font-size-base mr-2"></i>Actualizar</button>' +
                    '</div>' +
                    '</div>'
                );
            }

        });
    }

}

function fn_ActualizarCarrito(productoId, icantidadInicial) {

    var icantidadNueva = parseInt($('#slcCantidad' + productoId).val());
    var icantidadAntigua = parseInt(icantidadInicial);
    if (parseInt(icantidadNueva) <= 0 || icantidadAntigua === icantidadNueva) {
        $('#cart-inf').toast('show');
    } else {
        let productoCarrito = JSON.parse(localStorage.getItem('ss_productosCarrito')) || [];

        const existeProductoId = productoCarrito.find(({ ctProductoId }) => ctProductoId === productoId);
        if (existeProductoId) {
            Object.assign(existeProductoId, {
                'ctCantidad': icantidadNueva,
                'ctPrecio': existeProductoId.ctPrecioInicial * icantidadNueva
            });
        }
        localStorage.setItem('ss_productosCarrito', JSON.stringify(productoCarrito));
        fn_ListadoCarrito();
        fn_ActualizarMonto();
        //$('#cart-upd').toast('show');
    }

}

$(document).ready(function () {
    fn_GenerarMonto();
    fn_GenerarCarritoHTML();
    fn_ListadoCarrito();

    var sumatotal = 0;

    let productoCarrito = JSON.parse(localStorage.getItem('ss_productosCarrito')) || [];

    if (productoCarrito.length === 0) {
        $('#csubtotal').html("S/. 0.00");
    } else {
        $.each(productoCarrito, function (index, value) {
            sumatotal = sumatotal + value.ctPrecio;
        });
        $('#csubtotal').html("");
        $('#csubtotal').html("S/. " + (sumatotal / 100).toFixed(2));
    }

    $('#btnPago').click(function () {
        var hddValorCuenta = $('#hddvalorCuenta2').val();
        let productoCarrito = JSON.parse(localStorage.getItem('ss_productosCarrito')) || [];
        if (productoCarrito.length === 0) {
            $('#cart-infempty2').toast("show");
        } else {
            if (hddValorCuenta === "1") {

                $('#signin-modal').modal({
                    backdrop: 'static',
                    keyboard: false,
                    show: true
                });
            } else {
                fn_PayProduct();
            }
        }

    });

});