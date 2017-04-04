using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SChat.Models;
using SChat.DataAccess;

namespace SChat.DataAccess
{ 
    public interface IDBManager
    {
        int GetUserList(Registration registration);
        IList<MyMessagesResult> GetMessageList(int SenderID, int ReciverID);
        int GetInsertMessageList(int SenderID, int ReciverID, string message);
    }
}
