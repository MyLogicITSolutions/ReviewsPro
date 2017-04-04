using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SChat.Models;
using SChat.DataAccess;

namespace SChat.Business
{
    public interface IService
    {
        int GetInsertMessageList(int SenderID, int RecevierID, string message);
        int GetUserList(Registration registration);
        ConversationResponse GetConversationList(int SenderID, int ReciverID);
    }
}
