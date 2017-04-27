$(function () {
    var chat = $.connection.chatHub;

    chat.client.sendMessage = function (username, message) {

  
            
       
       /////// user = this.Context.User.Identity.Name;
        if (username == sessionStorage.getItem('userName')) {
         //   $('#chat-conversation').append('<li class="chat-line" id="mine">' + username + ': ' + message + '</li>');

            $('#chat-conversation').append('<li class="chat-line" id="mine">'  + message + '</li> <br>');
            } 
        else {
              $('#chat-conversation').append('<li class="chat-line" id="not-mine">' + username + ': ' + message + '</li>');
        }
       

       // $('#chat-conversation').append('<li class="chat-line" id="not-mine"><strong>' + username + ':</strong> ' + message + '</li> <br>');
    }
});

