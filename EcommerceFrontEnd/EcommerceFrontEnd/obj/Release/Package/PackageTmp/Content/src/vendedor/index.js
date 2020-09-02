$(document).ready(function () {

    $('#btnNuevo').click(function () {

        var txNombre = $('#reg-fn').val();
        var txApellido = $('#reg-ln').val();
        var txCorreo = $('#reg-email').val();
        var txCelular = $('#reg-phone').val();
        var txClave = $('#reg-password').val();
        var txClaveConfirmar = $('#reg-password-confirm').val();

        var testEmail = /^[A-Z0-9._%+-]+@([A-Z0-9-]+\.)+[A-Z]{2,4}$/i;

        if (txClave.length < 7) {
            alert("La clave debe tener al menos 7 caracteres");
        }

        if (txClave === txClaveConfirmar) {

            if (testEmail.test(txCorreo)) {
                $.ajax({
                    type: "POST",
                    url: gRoute + "vendedor/registrarVendedor",
                    //contentType: "application/json; charset=utf-8",
                    data: {
                        "wnombre": txNombre,
                        "wapellido": txApellido,
                        "wcelular": txCelular,
                        "wcorreo": txCorreo,
                        "wclave": txClave
                    },
                    //dataType: "json",
                    //async: true,
                    success: function (data) {
                        if (data.iResultado === -2) {
                            alert(data.iResultadoIns);
                        } else if (data.iResultado === -1) {
                            alert(data.iResultadoIns);
                        } else if (data.iResultado === 1) {
                            fnRouteMain();
                        }
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            } else {
                alert("por favor, ingrese un correo válido");
            }

        } else {
            alert("Las contraseñas no coinciden");
            $('#reg-password').val("");
            $('#reg-password-confirm').val("");
        }

    });

    $('#btnInicio').click(function () {
        var txCorreo = $('#correois').val();
        var txClave = $('#claveis').val();

        var testEmail = /^[A-Z0-9._%+-]+@([A-Z0-9-]+\.)+[A-Z]{2,4}$/i;
        if (testEmail.test(txCorreo)) {
            $.ajax({
                type: "POST",
                url: gRoute + "vendedor/loginVendedor",
                //contentType: "application/json; charset=utf-8",
                data: {
                    "wcorreo": txCorreo,
                    "wclave": txClave
                },
                //dataType: "json",
                //async: true,
                success: function (data) {
                    if (data.iResultado === -3) {
                        alert(data.iResultadoIns);
                    } else if (data.iResultado === -2) {
                        alert(data.iResultadoIns);
                    } else if (data.iResultado === 1) {
                        fnRouteMain();
                    }
                },
                error: function (data) {
                    console.log(data);
                }
            });
        } else {
            alert("por favor ingrese un correo válido");
        }

    });

});