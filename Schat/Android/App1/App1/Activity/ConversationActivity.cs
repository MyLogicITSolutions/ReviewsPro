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
    [Activity(Label = "Conversation")]
    public class ConversationActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.RequestFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.ConversationLayout);
            TextView Receivertxt = FindViewById<TextView>(Resource.Id.txtLeft);
            TextView Sendedtxt = FindViewById<TextView>(Resource.Id.txtRight);
            Receivertxt.Text = "Hi";
            Sendedtxt.Text = "Lokesh";
            EditText Txtmsg = FindViewById<EditText>(Resource.Id.txtmsg);
            ServiceWrapper svc = new ServiceWrapper();
            InsertMessages ins = new InsertMessages();
            
            ImageButton BtnSend = FindViewById<ImageButton>(Resource.Id.btnSend);
            BtnSend.Click += async delegate
            {
                ins.InsertMessage = Txtmsg.Text;
                ins.sender_id = Convert.ToInt32(CurrentUser.getUserId());
                ins.receiver_id = 2;
                int i = await svc.InsertMessage(ins);
                Txtmsg.Dispose();
            };


            // Create your application here
        }

        
    }
}