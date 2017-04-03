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
    [Activity(Label = "VerificationActivity")]
    public class VerificationActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.OtpReceiverLayout);
            string Sentotp = Intent.GetStringExtra("otp");
            string username = Intent.GetStringExtra("username");
            EditText receivedOtp = FindViewById<EditText>(Resource.Id.txtOtp);
            Button btnVerification = FindViewById<Button>(Resource.Id.btnVerify);
            btnVerification.Click += delegate
            {
                if (Sentotp == receivedOtp.Text)
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Successfully you're registered/loggedin in");
                    alert.SetMessage("Thank You");
                    alert.SetNegativeButton("Ok", delegate { });
                    Dialog dialog = alert.Create();
                    dialog.Show();

                    var intent = new Intent(this, typeof(ChatListActivity));
                    StartActivity(intent);
                }
                else
                {
                    AlertDialog.Builder aler = new AlertDialog.Builder(this);
                    aler.SetTitle("Incorrect Otp");
                    aler.SetMessage("Please Check Again");
                    aler.SetNegativeButton("Ok", delegate { });
                    Dialog dialog = aler.Create();
                    dialog.Show();

                }
            };
            
        }
    }
}