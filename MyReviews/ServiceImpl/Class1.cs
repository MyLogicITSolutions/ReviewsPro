using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmo;
using Dto;

namespace ServiceImpl
{
    public class Class1
    {
        public Users Register(Users userObj)
        {
            Reviews revObj = new Reviews();
            return (revObj.Register(userObj));
        }
        
       
    }
}
