using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SChat.Models;
using SChat.DataAccess;

namespace SChat.Business
{
    public class Service : IService
    {
        public int GetUserList(Registration registration)
        {
            IDBManager RegistrationDB = new DBManager();
            RegistrationDB.GetUserList(registration);
            return 1;
        }
        public int GetInsertMessageList(int SenderID, int RecevierID, string message)
        {
            IDBManager RegistrationDB = new DBManager();
            RegistrationDB.GetInsertMessageList(SenderID, RecevierID, message);
            return 1;
        }
        public ConversationResponse GetConversationList(int SenderID, int ReceiverID)
        {
            ConversationResponse itemListResponse = new ConversationResponse();
            List<RetriveMessages> itemList = new List<RetriveMessages>();

            IDBManager itemDBManager = new DBManager();

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

        public UserDetailsResponse GetUserDetailsList(string MobileNum)
        {
            UserDetailsResponse itemListResponse = new UserDetailsResponse();
            List<UserDetails> itemList = new List<UserDetails>();

            IDBManager itemDBManager = new DBManager();

            IList<GetUserDetailsResult> UserResults = itemDBManager.GetUserDetails(MobileNum).ToList();
            foreach (GetUserDetailsResult result in UserResults)
            {
                itemList.Add(new UserDetails
                {
                    user_id = result.user_id,
                    firstName = result.FirstName,
                    lastName = result.LastName,
                    email = result.email,
                    gender = result.Gender,
                    address = result.Address,
                    dob =Convert.ToDateTime( result.dob),
                    country = result.country,
                    city = result.city,
                    password = result.password

    });
            }
            itemListResponse.UserDetailsList = itemList;
            return itemListResponse;
        }


    }
}
