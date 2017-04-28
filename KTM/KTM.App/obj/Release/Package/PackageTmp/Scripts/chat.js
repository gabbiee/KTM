    $(document).ready(function () {
        $('#txtMessage').keypress(function (e) {
            if (e.keyCode == 13)
                $('#sendMessage').click();
        });
    });
