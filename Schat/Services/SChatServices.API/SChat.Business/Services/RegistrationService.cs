using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SChat.Models;
using SChat.DataAccess;

namespace SChat.Business
{
   public class RegistrationService : IRegistrationService
    {
        public int GetUserList(Registration registration)
        {
            IRegistrationDBManager RegistrationDB = new RegistrationDBManager();
            RegistrationDB.GetUserList(registration);
            return 1;
        }
    }
}
