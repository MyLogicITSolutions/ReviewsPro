using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SChat.Models;

namespace App1
{
    [Activity(Label = "ReceiverListAdapter")]
    public class ReceiverListAdapter : BaseAdapter<RetriveMessages>
    {
        private List<RetriveMessages> myItems;
        private Context myContext;
        //int userId = Convert.ToInt32(CurrentUser.getUserId());
        public override RetriveMessages this[int position]
        {
            get
            {
                return myItems[position];
            }
        }

        public ReceiverListAdapter(Context con, List<RetriveMessages> strArr)
        {
            myContext = con;
            myItems = strArr;
        }
        public override int Count
        {
            get
            {
                return myItems.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
                row = LayoutInflater.From(myContext).Inflate(Resource.Layout.ReceiverCell, null, false);

            TextView TxtMessage = row.FindViewById<TextView>(Resource.Id.ReceiverTxt);
            TxtMessage.Text = myItems[position].Conversation;
            return row;
        }
    }
}