using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SChat.Models;
using SChat.DataAccess;

namespace SChat.Business
{
    public interface ISChatService
    {
       ConversationResponse  GetConversationList(int SenderID, int ReciverID);

    }
}
