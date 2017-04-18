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
    [Activity(Label = "@string/ApplicationName", MainLauncher =true,Icon ="@drawable/conversation")]
    public class StartActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.StartLayout);
            if (CurrentUser.getUserId() != null)
            {
                Intent intent = new Intent(this, typeof(ChatListActivity));
                StartActivity(intent);
            }
            else
            {
                Button regBtn = FindViewById<Button>(Resource.Id.btnRegister);
                regBtn.Click += delegate
                {
                    Intent intent = new Intent(this, typeof(RegistrationActivity));
                    StartActivity(intent);
                };
            }
        }
    }
}