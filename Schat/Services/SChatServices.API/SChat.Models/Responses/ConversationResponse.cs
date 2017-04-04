using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SChat.Models;

namespace SChat.Models
{
 public   class ConversationResponse
    {
        public IList<RetriveMessages> ConversationList { get; set; }
    }
}
