using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTM.Services
{
    using Data.UnitOfWork;
    using Interfaces;
    using Models.EntityModels;
    using Models.ViewModels;

    public class ChatService : Service, IChatService
    {
        protected IKTMData data;

        public ChatService()
        {
            this.data = new KTMData();
        }

        public ChatViewModel GetChatPage()
        {
          
            var chat = new ChatViewModel()
            {
             
            };
         

            return chat;
        }


       
    }
}
