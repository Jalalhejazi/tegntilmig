/// <reference path="jquery.signaturepad.js" />

$(document).ready(function () {
    $('.sigPad').signaturePad({
        defaultAction: 'drawIt',
        drawOnly: true,
        displayOnly: true
    }).regenerate(sig);
});
