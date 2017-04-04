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
    [Activity(Label = "Schat Profile")]
    public class profileActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProfileImageLayout);
            ImageView ProPic = FindViewById<ImageView>(Resource.Id.propicview);
            ImageButton ChangePropic = FindViewById<ImageButton>(Resource.Id.btnChangePropic);
            ChangePropic.Click += delegate
            {
                Intent intent = new Intent(this, typeof(ProfilePicturePickDialog));
                StartActivity(intent);
            };
            // Create your application here
        }
    }
}