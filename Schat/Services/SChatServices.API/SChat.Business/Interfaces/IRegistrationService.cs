using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SChat.Models;
using SChat.DataAccess;

namespace SChat.Business

{
   public interface IRegistrationService
    {
        int GetUserList(Registration registration);
    }
}
