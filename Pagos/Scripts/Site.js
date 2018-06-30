//Método para mostrar alertas notify
function showNotify(title,message, messagetype) {
    var icon;
    if (messagetype === 'danger') {
        icon = "glyphicon glyphicon-remove-sign";
        title = '<b>'+title+'</b><br/>'
    } else {
        icon = "glyphicon glyphicon-ok-sign";
        title = '<b>' + title +'</b><br/>'
    }
    $.notify({
        icon: icon,
        title: title,
        message: message,
    }, {
        animate: {
            enter: 'animated fadeInRight',
            exit: 'animated fadeOutRight'
        },
        type: messagetype
    });
}