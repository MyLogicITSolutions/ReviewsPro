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
            // Create your application here
        }
    }
}