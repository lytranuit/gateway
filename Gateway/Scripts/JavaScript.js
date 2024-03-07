
$(document).on('contextmenu', function (evt) {
    if (!$(evt.target).is('.context')) {
        evt.preventDefault();
    }
});
$(document).keydown(function (event) {
    if (event.keyCode == 123) { // Prevent F12
        return false;
    } else if (event.ctrlKey && event.shiftKey && event.keyCode == 73) { // Prevent Ctrl+Shift+I        
        return false;
    }
});
$(document).ready(function ($) {
    $(document).keydown(function (event) {
        var pressedKey = String.fromCharCode(event.keyCode).toLowerCase();

        if (event.ctrlKey && (pressedKey == "c" || pressedKey == "u")) {

            //disable key press porcessing
            return false;
        }
    });
});