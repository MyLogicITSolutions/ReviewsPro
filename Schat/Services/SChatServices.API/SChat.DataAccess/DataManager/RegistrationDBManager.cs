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
    public class RegistrationDBManager:IRegistrationDBManager
    {
        public SChatDataContext DBContext;
        public RegistrationDBManager()
        {
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            DBContext = new DataAccess.SChatDataContext(connection);
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



    }
  

}
