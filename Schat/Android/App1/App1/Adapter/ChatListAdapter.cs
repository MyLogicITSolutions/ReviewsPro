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
using Android.Graphics;
using System.Net;
using SChat.Models;

namespace App1
{
    [Activity(Label = "Review Adapter")]
    public class ChatListAdapter : BaseAdapter<chatList>
    {
        private List<chatList> myItems;
        private Context myContext;
        //int userId = Convert.ToInt32(CurrentUser.getUserId());
        public override chatList this[int position]
        {
            get
            {
                return myItems[position];
            }
        }

        public ChatListAdapter(Context con, List<chatList> strArr)
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
                row = LayoutInflater.From(myContext).Inflate(Resource.Layout.ChatListCell, null, false);

            TextView TxtUserName = row.FindViewById<TextView>(Resource.Id.txtContactName);
            TextView TxtLastMessage = row.FindViewById<TextView>(Resource.Id.txtLastMessage);
            ImageButton BtnProfilePicture = row.FindViewById<ImageButton>(Resource.Id.imgBtnProfile);

            //Bitmap imageBitmap = BlobWrapper.ProfileImages(myItems[position].ReviewUserId);
            //if (imageBitmap == null)
            //{
            BtnProfilePicture.SetImageResource(Resource.Drawable.user);
            BtnProfilePicture.SetScaleType(ImageView.ScaleType.CenterCrop);
            BtnProfilePicture.Focusable = false;
            BtnProfilePicture.Clickable = true;
            BtnProfilePicture.FocusableInTouchMode = false;
            //}
            //ProfilePicturePickDialog pppd = new ProfilePicturePickDialog();
            //string path = pppd.CreateDirectoryForPictures();
            ////string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            ////It's taking lot of time to load user images so giving wine id, after completing compressing image we will give reviewuserid
            //var filePath = System.IO.Path.Combine(path + "/" + myItems[position].ReviewUserId + ".jpg");
            //if (System.IO.File.Exists(filePath))
            //{
            //    imageBitmap = BitmapFactory.DecodeFile(filePath);
            //    Image.SetImageBitmap(imageBitmap);
            //}
            //else
            //{
            //    //It's taking lot of time to load user images so giving wine id, after completing compressing image we will give reviewuserid
            //    imageBitmap = BlobWrapper.ProfileImages(myItems[position].ReviewUserId);
            //    if(imageBitmap==null)
            //    {
            //        Image.SetImageResource(Resource.Drawable.user);
            //    }
            //    else
            //    { 
            //    Image.SetImageBitmap(imageBitmap);
            //    }
            //}
            TxtUserName.Text = "+91 "+myItems[position].mobile.ToString();
            TxtLastMessage.Text = "Hi";
            TxtLastMessage.Focusable = false;
            TxtUserName.Focusable = false;
            //date.Text = myItems[position].Date.ToString("dd/MM/yyyy");
            //rb.Rating = myItems[position].RatingStars;
            //Image.SetImageBitmap(imageBitmap);
            //Image.SetScaleType(ImageView.ScaleType.CenterCrop);
            return row;
        }


    }
}