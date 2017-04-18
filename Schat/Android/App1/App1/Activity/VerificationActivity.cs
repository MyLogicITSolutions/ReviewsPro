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
    [Activity(Label = "VerificationActivity")]
    public class VerificationActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.OtpReceiverLayout);
            string Sentotp = Intent.GetStringExtra("otp");
            string email=Intent.GetStringExtra("email");
            string address = Intent.GetStringExtra("address");
            string password = Intent.GetStringExtra("password");
            string username = Intent.GetStringExtra("username");
            string mobilenumber = Intent.GetStringExtra("mobilenumber");
            EditText receivedOtp = FindViewById<EditText>(Resource.Id.txtOtp);
            Button btnVerification = FindViewById<Button>(Resource.Id.btnVerify);
            btnVerification.Click += async delegate
            {
                if (Sentotp == receivedOtp.Text)
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Successfully you are registered");
                    alert.SetMessage("Thank You");
                    alert.SetNegativeButton("Ok", delegate { });
                    Dialog dialog = alert.Create();
                    dialog.Show();
                    ServiceWrapper svc = new ServiceWrapper();
                    Registration ud = new Registration();
                    try
                    {
                        
                        ud.address = address;
                        ud.city = password;
                        ud.firstName = username;
                        ud.lastName = username;
                        ud.password = password;
                        ud.email = email;
                        ud.dob= DateTime.Now;
                        ud.gender = "M";
                        ud.country = "India";
                        ud.mobile = mobilenumber;
                        
                        
                        await svc.InsertUpdateUsers(ud);
                    }
                    catch(Exception e)
                    {
                        Toast.MakeText(this, e.Message, ToastLength.Short);
                    }
                    UserDetailsResponse udsr = new UserDetailsResponse();
                    udsr = svc.userdetailsList(mobilenumber).Result;
                    string uid = Convert.ToString(udsr.UserDetailsList[0].user_id);
                    CurrentUser.SaveUserId(uid);
                    var intent = new Intent(this, typeof(ProfilePictureSetActivity));
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