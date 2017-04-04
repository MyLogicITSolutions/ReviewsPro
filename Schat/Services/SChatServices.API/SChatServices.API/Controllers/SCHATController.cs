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
            IService itemService = new Service();
            resp = itemService.GetConversationList(objectId,userid);
            return resp;
        }
        [HttpPost]
        public int GetUserList(Registration registration)
        {
            IService itemService = new Service();
            return (itemService.GetUserList(registration));
        }
        [HttpPost]
        public int GetInsertMessageList(int objectId, int userid,string message)
        {
            IService itemService = new Service();
            return (itemService.GetInsertMessageList(objectId,userid,message));
        }
    }
}