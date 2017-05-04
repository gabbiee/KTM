namespace KTM.App.Hubs
{
    using Microsoft.AspNet.SignalR;

    public class ChatHub : Hub


    {
        public void SendMessage(string username, string message)
        {
            username = this.Context.User.Identity.Name;


            Clients.All.sendMessage(username, message);


        }
    }
}