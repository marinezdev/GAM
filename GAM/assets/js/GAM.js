function Mensajes(titulo, mensaje, tipo) {
    var clase = "";
    var icono = "";
    switch (tipo) {
        case 1:
            clase = 'btn btn-info';
            icono = "info";
            break;
        case 2:
            clase = 'btn btn-success';
            icono = "success";
            break;
        case 3:
            clase = 'btn btn-warning';
            icono = "warning";
            break;
        case 4:
            clase = 'btn btn-danger';
            icono = "error";
            break;
    }
    swal({
        title: titulo,
        text: mensaje,
        icon: icono,
        buttons: {
            confirm: {
                className: clase
            }
        }
    });
}