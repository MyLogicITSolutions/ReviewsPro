using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SChat.DataAccess;
using System.Data.Linq;
using SChat.Models;

namespace SChat.DataAccess
{
   public  class DBManager : IDBManager
    {

            public SChatDataContext DBContext;

            public DBManager()
            {
                string connection = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                DBContext = new DataAccess.SChatDataContext(connection);
            }


            public IList<MyMessagesResult> GetMessageList(int SenderID, int RecevierID)
            {
                try
                {
                    ISingleResult<MyMessagesResult> result = DBContext.MyMessages(SenderID, RecevierID);
                    return result.ToList();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        public int GetUserList(Registration registration)
        {
            try
            {
                int result =
                DBContext.RegisterUsers(registration.firstName,
                                                          registration.lastName,
                                                          registration.email,
                                                          registration.mobile,
                                                          registration.gender,
                                                          registration.address,
                                                          registration.dob,
                                                          registration.country,
                                                          registration.city,
                                                          registration.password);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetInsertMessageList(int SenderID, int RecevierID, string message)
        {
            try
            {
                int result = DBContext.InsertMessage(SenderID, RecevierID, message);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public IList<GetUserDetailsResult> GetUserDetails(string mobileNum)
        {
            try
            {
                ISingleResult<GetUserDetailsResult> result = DBContext.GetUserDetails(mobileNum);
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
