using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class Reviews
    {
        private int dbkeyreview;
        private string userName;
        private string comments;
        private DateTime dateofReview;
       
        public int DBKey
        {
            get { return this.dbkeyreview; }
            set { this.dbkeyreview = value; }
        }
        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }
        public string Comment
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
         public DateTime DateofReview
        {
            get { return this.dateofReview; }
            set { this.dateofReview = value; }
        }
        
    }
}
