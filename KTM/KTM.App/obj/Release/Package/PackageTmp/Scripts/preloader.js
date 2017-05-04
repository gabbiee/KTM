$(document).ready(function () {
    var route = window.location.pathname;
    if (route == "/") {
        $('.container').addClass('preloader-hidden');

        setTimeout(function() {
            $('.container').removeClass('preloader-hidden');
            $('.preloader').addClass('preloader-hidden');
        }, 3000);
    } else {
        $('.preloader').addClass('preloader-hidden');
    }

    

});