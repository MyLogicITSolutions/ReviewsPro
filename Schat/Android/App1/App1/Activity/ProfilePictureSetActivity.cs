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

namespace App1
{
    [Activity(Label = "Choose profile image here",MainLauncher =false)]
    public class ProfilePictureSetActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProfilePictureSetLayout);
            ImageButton BtnUploadProPic = FindViewById<ImageButton>(Resource.Id.btnuploadpropic);

            BtnUploadProPic.Click += delegate
            {
                Intent intent = new Intent(this, typeof(ProfilePicturePickDialog));
                StartActivity(intent);
            };

            Button btnNext = FindViewById<Button>(Resource.Id.btnUpload);
            btnNext.Click += delegate
            {
                Intent intent = new Intent(this, typeof(ChatListActivity));
                StartActivity(intent);
            };
            // Create your application here
        }
    }
}