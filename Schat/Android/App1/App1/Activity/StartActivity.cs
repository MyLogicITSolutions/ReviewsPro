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
    [Activity(Label = "@string/ApplicationName", MainLauncher =false,Icon ="@drawable/conversation")]
    public class StartActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.StartLayout);
            if (CurrentUser.getUserId() != null)
            {
                Intent intent = new Intent(this, typeof(ChatListActivity));
                StartActivity(intent);
                               
            }
            else
            {
                Button lgnBtn = FindViewById<Button>(Resource.Id.btnLogin);
                lgnBtn.Click += delegate
                {
                    Intent intent = new Intent(this, typeof(LoginActivity));
                    StartActivity(intent);
                };

                Button regBtn = FindViewById<Button>(Resource.Id.btnRegister);
                regBtn.Click += delegate
                {
                    Intent intent = new Intent(this, typeof(Registration));
                    StartActivity(intent);
                };

            }

            // Create your application here
        }
    }
}