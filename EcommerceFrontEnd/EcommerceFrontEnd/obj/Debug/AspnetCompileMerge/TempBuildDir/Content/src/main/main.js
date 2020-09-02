$(document).ready(function () {

    $('#btnNuevo').click(function () {

        var txNombre = $('#su-name').val();
        var txApellido = $('#su-lastname').val();
        var txCorreo = $('#su-email').val();
        var txClave = $('#su-password').val();
        var txClaveConfirmar = $('#su-password-confirm').val();

        var testEmail = /^[A-Z0-9._%+-]+@([A-Z0-9-]+\.)+[A-Z]{2,4}$/i;
        if (txClave.length < 7) {
            alert("La clave debe tener al menos 7 caracteres");
        }

        if (txClave === txClaveConfirmar) {

            if (testEmail.test(txCorreo)) {
                $.ajax({
                    type: "POST",
                    url: gRoute + "usuario/registrarusuario",
                    //contentType: "application/json; charset=utf-8",
                    data: {
                        "wnombre": txNombre,
                        "wapellido": txApellido,
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
        }

    });

    $('#btnInicio').click(function () {
        var txCorreo = $('#si-email').val();
        var txClave = $('#si-password').val();

        var testEmail = /^[A-Z0-9._%+-]+@([A-Z0-9-]+\.)+[A-Z]{2,4}$/i;
        if (testEmail.test(txCorreo)) {
            $.ajax({
                type: "POST",
                url: gRoute + "usuario/loginusuario",
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

    $('#btnCerrar').click(function () {
        $.ajax({
            type: "POST",
            url: gRoute + "usuario/cerrarSesion",
            success: function (data) {
                if (data.iResultado === 1) {
                    fnRouteMain();
                } else {
                    fnRouteMain();
                }
            },
            error: function (data) {
                console.log(data);
            }
        });

    });



});
