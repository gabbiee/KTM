$(function() {
    var chat = $.connection.chatHub;
 //   $('#username').val("@HttpContext.Current.User.Identity.Name");
    $.connection.hub.start().done(function() {
        $('#sendMessage').click(function() {
            chat.server.sendMessage($('#username').html, $('#chat-container input.input-text').val());
            $('#chat-container input.input-text').val('');
        });
    });

})