var hourInMiliseconds = (60 * 60) * 1000;
var minuteInMiliseconds = 60000;
var sessionTimeOut = hourInMiliseconds;

var alertText = "Su sesion ha expirado debido a que la misma se mantuvo inactiva por mas de ";

if ($("#sessionTimeOutInMinutes").get(0)) {
    sessionTimeOut = (parseInt($("#sessionTimeOutInMinutes").val()) * 60) * 1000;
};

if (sessionTimeOut === hourInMiliseconds) {
    alertText = alertText + "1 Hora!";
}else if (sessionTimeOut > hourInMiliseconds) {
    var hours = ((sessionTimeOut / minuteInMiliseconds) / 1) / 60;
    alertText = alertText + hours + " Horas!";
} else {
    alertText = "Su sesion ha expirado debido a que la misma se mantuvo inactiva por un tiempo prolongado";
};

$(document).idle({
    onIdle: function () {
        $.post("/Security/LogOut",
            null,
            function () {
                swal({
                    title: "Sesion Expirada",
                    text: alertText,
                    type: "warning",
                    showCancelButton: false,
                    confirmButtonColor: "#1c84c6",
                    confirmButtonText: "Aceptar",
                    onClose: function () {
                        window.location.reload();
                    }
                });
            });
    },
    idle: sessionTimeOut
});

