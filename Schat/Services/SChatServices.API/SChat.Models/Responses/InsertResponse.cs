using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SChat.Models;

namespace SChat.Models.Responses
{
    public class InsertResponse
    {
        public IList<InsertMessages> InsertMessageList { get; set; }
    }
}
