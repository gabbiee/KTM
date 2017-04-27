namespace KTM.Services.Interfaces
{
    using Models.EntityModels;
    using Models.ViewModels;

    public  interface IChatService
    {
        ChatViewModel GetChatPage();
    }
}
