using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SChat.Models;
using SChat.Business;
using System.Web.Http;
using System.Net.Http;



namespace SChatServices.API.Controllers
{
    public class SCHATController : ApiController
    {
        // GET: SCHAT
       

        [HttpGet]
        public ConversationResponse ConversationList(int objectId,int userid)
        {
            ConversationResponse resp = new ConversationResponse();
            ISChatService itemService = new SChatService();
            resp = itemService.GetConversationList(objectId,userid);
            return resp;
        }
        [HttpPost]
        public int GetUserList(Registration registration)
        {
            IRegistrationService itemService = new RegistrationService();
            return (itemService.GetUserList(registration));
        }
    }
}