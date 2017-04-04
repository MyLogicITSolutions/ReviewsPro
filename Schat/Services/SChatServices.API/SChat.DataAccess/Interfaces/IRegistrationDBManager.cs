using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SChat.Models;
using SChat.DataAccess;

namespace SChat.DataAccess
{
   public interface IRegistrationDBManager
    {
        int GetUserList(Registration registration);
    }
}
