using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace App1
{
    [Activity (Label = "New Chat", MainLauncher = false)]
    public class PickContactActivity : Activity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            SetContentView (Resource.Layout.ContactPickLayout);

            var contactsAdapter = new ContactsAdapter (this);       
            var contactsListView = FindViewById<ListView> (Resource.Id.ContactsListView);      
            contactsListView.Adapter = contactsAdapter;
        }
    }
}


