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
using Java.Net;
using Android.Graphics;
using Java.IO;
using Android.Graphics.Drawables;
using Android.Util;
using System.Net;
using System.IO;
using Android.Media;
using System.Threading;
using System.Drawing;
using Android.Telephony;

namespace App1
{
    [Activity(Label = "Register here" , MainLauncher = false, Icon = "@drawable/conversation")]
    public class RegistrationActivity : Activity
    {
        public string otp = "";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Registration);
            //var url = "http://sms.latestsms.in/wp-content/uploads/facebook-profile-pictures14.jpg";

            //Bitmap _bimage = GetImageBitmapFromUrl(url);

            //Bitmap _bfinal = getRoundedShape(_bimage);

            //ImageView propicimage = FindViewById<ImageView>(Resource.Id.propicview);

            //propicimage.SetImageResource(Resource.Drawable.user);

            //ImageButton BtnUploadPropic = FindViewById<ImageButton>(Resource.Id.btnUploadPropic);
            EditText UserName = FindViewById<EditText>(Resource.Id.txtFullName);
            //EditText Lastname = FindViewById<EditText>(Resource.Id.txtLastName);
            EditText Mobilenumber = FindViewById<EditText>(Resource.Id.txtMobileNumber);
            EditText Email = FindViewById<EditText>(Resource.Id.txtEmail);
            EditText Address = FindViewById<EditText>(Resource.Id.txtAddress);
            EditText Password = FindViewById<EditText>(Resource.Id.txtPass);
            EditText Re_Password = FindViewById<EditText>(Resource.Id.txtRePass);
            Button BtnRegister = FindViewById<Button>(Resource.Id.btnRegister);

            BtnRegister.Click += delegate 
            {
                if (Mobilenumber.Text == "")
                {
                    AlertDialog.Builder aler = new AlertDialog.Builder(this);
                    aler.SetTitle("Sorry");
                    aler.SetMessage("Please enter your 10 digit mobile number");
                    aler.SetNegativeButton("Ok", delegate { });
                    Dialog dialog = aler.Create();
                    dialog.Show();
                    return;
                }
                else
                {
                    SendSmsgs(Mobilenumber.Text);
                    var intent = new Intent(this, typeof(VerificationActivity));
                    intent.PutExtra("otp", otp);
                    intent.PutExtra("email", Email.Text);
                    intent.PutExtra("address", Address.Text);
                    intent.PutExtra("password", Password.Text);
                    intent.PutExtra("username", UserName.Text);
                    intent.PutExtra("mobilenumber", Mobilenumber.Text);
                    StartActivity(intent);

                }
            };

            //BtnUploadPropic.Click += delegate
            //{
                    
            //};
        }
        private void SendSmsgs(string userNumber)
        {
            otp = RandomString(4);
            int otpcount = otp.Count();
            SmsManager.Default.SendTextMessage(userNumber.ToString(), null, "Your Otp is:" + otp, null, null);
            //otps.Add(otp);
            //string httpreq="http://bhashsms.com/api/sendmsg.php?user=username&pass=********&sender=sendername&phone=" + userNumber + "&text=" + otp + "&priority=dnd&stype=unicode";
        }
        private System.Random random = new System.Random();
        public string RandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        //public Bitmap GetImageBitmapFromUrl(string url)
        //{
        //    Bitmap imageBitmap = null;
        //    if (!(url == "null"))
        //        using (var webClient = new WebClient())
        //        {
        //            var imageBytes = webClient.DownloadData(url);
        //            if (imageBytes != null && imageBytes.Length > 0)
        //            {
        //                imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
        //            }
        //        }

        //    System.Console.Out.WriteLine("Return fn");
        //    return imageBitmap;
        //}

        //public Bitmap getRoundedShape(Bitmap scaleBitmapImage)
        //{
        //    int targetWidth = 3800;
        //    int targetHeight = 0;
        //    Bitmap targetBitmap = Bitmap.CreateBitmap(targetWidth,
        //        targetHeight, Bitmap.Config.Argb8888);

        //    Canvas canvas = new Canvas(targetBitmap);
        //    Android.Graphics.Path path = new Android.Graphics.Path();
        //    path.AddCircle(((float)targetWidth - 1) / 2,
        //        ((float)targetHeight - 1) / 2,
        //        (Math.Min(((float)targetWidth),
        //            ((float)targetHeight)) / 2),
        //        Android.Graphics.Path.Direction.Ccw);

        //    canvas.ClipPath(path);
        //    Bitmap sourceBitmap = scaleBitmapImage;
        //    canvas.DrawBitmap(sourceBitmap,
        //        new Rect(0, 0, sourceBitmap.Width,
        //            sourceBitmap.Height),
        //        new Rect(0, 0, targetWidth, targetHeight), null);
        //    return targetBitmap;
        //}
    }
}