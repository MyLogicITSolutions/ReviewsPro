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
using System.Threading;
using System.Threading.Tasks;
namespace App1

{
    [Activity(Label = "Login here", MainLauncher =false)]
    public class LoginActivity : Activity

    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.login);
           
            Button login = FindViewById<Button>(Resource.Id.btnLoginLL);
            
            //EditText username = FindViewById<EditText>(Resource.Id.txtUsername);
            EditText userid = FindViewById<EditText>(Resource.Id.txtPhoneNumber);
            
            //ServiceWrapper svc = new ServiceWrapper();
            //new Thread(new ThreadStart(delegate
            //{
            //    RunOnUiThread(() => bvb.DownloadImages(Convert.ToInt32(CurrentUser.getUserId())));
            //})).Start();

            //bvb.DownloadImages(Convert.ToInt32(CurrentUser.getUserId()));
            //var TaskA = new Task(() => {
            //    BlobWrapper.DownloadImages(Convert.ToInt32(CurrentUser.getUserId()));
            //});
            //TaskA.Start();


            //if (CurrentUser.getUserId() == null)
            //{
            //    // Do nothing
            //}
            //else
            //{
            //    Intent intent = new Intent(this, typeof(ChatListActivity));
            //    StartActivity(intent);

            //}



            login.Click += delegate
            {
                //1. Call Auth service and check for this user, it returns one.
                //2. If it returns 1 save Username and go to Tab Activity.
                //3. Else Show message, incorrect username.
                //
                if (userid.Text == "")
                {
                    AlertDialog.Builder aler = new AlertDialog.Builder(this);
                    aler.SetTitle("Sorry");
                    aler.SetMessage("Please enter mobile number to login");
                    aler.SetNegativeButton("Ok", delegate { });
                    Dialog dialog = aler.Create();
                    dialog.Show();
                    return;

                }
                //ForTesting
                //else if (userid.Text == "7207589007")
                //{
                //    Intent intent = new Intent(this, typeof(ChatListActivity));
                //    StartActivity(intent);
                //}
                else
                {
                    CurrentUser.SaveUserId(userid.Text);
                    Intent intent = new Intent(this, typeof(ChatListActivity));
                    StartActivity(intent);
                }
                //CustomerResponse authen = new CustomerResponse();
                //try
                //{
                //   authen = svc.AuthencateUser(username.Text).Result;
                //    if (authen.customer != null && authen.customer.CustomerID != 0)
                //    {
                //        CurrentUser.SaveUserName(username.Text, authen.customer.CustomerID.ToString());
                //        Intent intent = new Intent(this, typeof(TabActivity));
                //        StartActivity(intent);

                //    }
                //    else
                //    {
                //        AlertDialog.Builder aler = new AlertDialog.Builder(this);
                //        aler.SetTitle("Sorry");
                //        aler.SetMessage("Incorrect Details");
                //        aler.SetNegativeButton("Ok", delegate { });
                //        Dialog dialog = aler.Create();
                //        dialog.Show();
                //    };
                //}
                //else
                //try
                //{
                //    Intent intent = new Intent(this, typeof(MainActivity));
                //    StartActivity(intent);
                //}
                //catch (Exception exception)
                //{
                //    if (exception.Message.ToString() == "One or more errors occurred.")
                //    {
                //        AlertDialog.Builder aler = new AlertDialog.Builder(this);
                //        aler.SetTitle("Sorry");
                //        aler.SetMessage("Please check your internet connection");
                //        aler.SetNegativeButton("Ok", delegate { });
                //        Dialog dialog = aler.Create();
                //        dialog.Show();
                //    }
                //    else
                //    {
                //        AlertDialog.Builder aler = new AlertDialog.Builder(this);
                //        aler.SetTitle("Sorry");
                //        aler.SetMessage("We're under maintanence");
                //        aler.SetNegativeButton("Ok", delegate { });
                //        Dialog dialog = aler.Create();
                //        dialog.Show();

                //    }

                //}
             

            };                 

            
        }
    }
}