using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Widget;
using Java.IO;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;
using Android.Views;

using System.IO;

namespace App1
{
 

    public static class App {
        public static Java.IO.File _file;
        public static Java.IO.File _dir;     
        public static Bitmap bitmap;
       
    }

    [Activity(Label = "@string/ApplicationName", MainLauncher = false, Theme = "@android:style/Theme.Dialog")]
    public class ProfilePicturePickDialog : Activity
    {

        //private ImageView _imageView;
        public string path;
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Make it available in the gallery

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Uri contentUri = Uri.FromFile(App._file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);
            Toast.MakeText(this, "Thank you,We will update your profile picture as soon as possible", ToastLength.Short).Show();
            Toast.MakeText(this, "Please touch anywhere to exit this dialog.", ToastLength.Short).Show();

            //Bitmap propic = BitmapFactory.DecodeFile(path);
            //ProfileActivity pa = new ProfileActivity();
            //Bitmap resized = pa.resizeAndRotate(propic, 450, 450);
            //try
            //{
            //    var filePath = System.IO.Path.Combine(path + "/" + Convert.ToInt32(CurrentUser.getUserId()) + ".jpg");
            //    var stream = new FileStream(filePath, FileMode.Create);
            //    resized.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
            //    stream.Close();
            //}
            //catch(Exception ex)
            //{

            //}
        
            GC.Collect();
        }
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Window.RequestFeature(WindowFeatures.NoTitle);
           SetContentView(Resource.Layout.ProfilePickLayout);

            //if (IsThereAnAppToTakePictures())
            //{
            //    CreateDirectoryForPictures();
            //    ImageButton BtnCamera = FindViewById<ImageButton>(Resource.Id.btnCamera);
            //    BtnCamera.Click += TakeAPicture;


            //    // _imageView = FindViewById<ImageView>(Resource.Id.imageView1);
            //    // BtnCamera.Click += TakeAPicture;
            //}
            ImageButton btnGallery = FindViewById<ImageButton>(Resource.Id.imgbtnGallery);

            btnGallery.Click += delegate
            {
                Intent intent = new Intent(this, typeof(ProfilePictureGallery));
                StartActivity(intent);
            };
        }
        public string CreateDirectoryForPictures()
        {
            App._dir = new Java.IO.File(Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures), "Schat/ProfilePictures");

            if (!App._dir.Exists())
            {
                App._dir.Mkdirs();
            }
            path = App._dir.ToString();
            return path;
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        
        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            
            App._file = new Java.IO.File(App._dir, String.Format(Convert.ToInt32(CurrentUser.getUserId())+".jpg", Guid.NewGuid()));
           path += "/"+CurrentUser.getUserId()+".jpg";
            


            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(App._file));
            
            StartActivityForResult(intent, 0);
        }

    }
}


