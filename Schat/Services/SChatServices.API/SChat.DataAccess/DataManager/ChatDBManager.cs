using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SChat.DataAccess;
using System.Data.Linq;


namespace SChat.DataAccess
{
  public  class ChatDBManager:IChatDBManager
    {
        public SChatDataContext DBContext;

        public ChatDBManager()
        {
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            DBContext = new DataAccess.SChatDataContext(connection);
        }


        public IList<MyMessagesResult> GetMessageList(int SenderID,int RecevierID)
        {
            try
            {
                ISingleResult<MyMessagesResult> result = DBContext.MyMessages(SenderID,RecevierID);
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
