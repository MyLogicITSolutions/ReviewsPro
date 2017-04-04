using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SChat.Models;
using SChat.DataAccess;

namespace SChat.Business
{
  public   class SChatService:ISChatService
    {
        public ConversationResponse GetConversationList(int SenderID, int ReceiverID)
        {
            ConversationResponse itemListResponse = new ConversationResponse();
            List<RetriveMessages> itemList = new List<RetriveMessages>();

            IChatDBManager itemDBManager = new ChatDBManager();

            IList<MyMessagesResult> wineResults = itemDBManager.GetMessageList(SenderID, ReceiverID).ToList();
            foreach (MyMessagesResult result in wineResults)
            {
                itemList.Add(new RetriveMessages
                {
                    Conversation = result.message
                });
            }
            itemListResponse.ConversationList = itemList;
            return itemListResponse;
        }
    }
}
