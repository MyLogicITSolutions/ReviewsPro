using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SChat.DataAccess
{
   public interface IChatDBManager
    {
        IList<MyMessagesResult> GetMessageList(int SenderID,int ReciverID);
      
        
    }
}
