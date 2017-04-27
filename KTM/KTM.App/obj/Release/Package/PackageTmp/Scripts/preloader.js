$(document).ready(function () {

    $('.container').addClass('preloader-hidden');

    setTimeout(function () {
        $('.container').removeClass('preloader-hidden');
        $('.preloader').addClass('preloader-hidden');
    }, 3000);

});