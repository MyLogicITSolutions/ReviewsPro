using System;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.App;
using Android.Provider;
using System.Collections.Generic;

namespace App1
{
    public class ContactsAdapter : BaseAdapter
    {
        List<Contact> _contactList;
        Activity _activity;
        
        public ContactsAdapter (Activity activity)
        {
            _activity = activity;
            
            FillContacts ();
        }
        
        public override int Count {
            get { return _contactList.Count; }
        }

        public override Java.Lang.Object GetItem (int position)
        {
            return null; // could wrap a Contact in a Java.Lang.Object to return it here if needed
        }

        public override long GetItemId (int position)
        {
            return _contactList [position].Id;
        }
        
        public override View GetView (int position, View convertView, ViewGroup parent)
        {          
            var view = convertView ?? _activity.LayoutInflater.Inflate (Resource.Layout.ContactListItem, parent, false);
            var contactName = view.FindViewById<TextView> (Resource.Id.ContactName);
            var contactImage = view.FindViewById<ImageView> (Resource.Id.ContactImage);
            var contactNumber = view.FindViewById<TextView>(Resource.Id.Cnumber);
            contactName.Text = _contactList [position].DisplayName;
            contactNumber.Text = _contactList[position].number;
            
            if (_contactList [position].PhotoId == null) {
                
                contactImage = view.FindViewById<ImageView> (Resource.Id.ContactImage);
                contactImage.SetImageResource (Resource.Drawable.user);
                
            } else {
                
                var contactUri = ContentUris.WithAppendedId (ContactsContract.Contacts.ContentUri, _contactList [position].Id);
                var contactPhotoUri = Android.Net.Uri.WithAppendedPath (contactUri, Contacts.Photos.ContentDirectory);
                var uri = ContactsContract.CommonDataKinds.Phone.ContentUri;
                contactImage.SetImageURI (contactPhotoUri);
            }
            return view;
        }
        
        void FillContacts ()
        {
            //var uri = ContactsContract.Contacts.ContentUri;
            var uri1 = ContactsContract.CommonDataKinds.Phone.ContentUri;


            string[] projection = {
                ContactsContract.Contacts.InterfaceConsts.Id,
                ContactsContract.Contacts.InterfaceConsts.DisplayName,
                ContactsContract.Contacts.InterfaceConsts.PhotoId,
                ContactsContract.CommonDataKinds.Phone.Number
            };
          
            var cursor = _activity.ManagedQuery (uri1, projection, null, null, null);
            
            _contactList = new List<Contact> ();   
            
            if (cursor.MoveToFirst ()) {
                do {
                    _contactList.Add (new Contact{
                        Id = cursor.GetLong (cursor.GetColumnIndex (projection [0])),
                        DisplayName = cursor.GetString (cursor.GetColumnIndex (projection [1])),
                        PhotoId = cursor.GetString (cursor.GetColumnIndex (projection [2])),
                        number= cursor.GetString(cursor.GetColumnIndex(projection[3]))
                    });
                } while (cursor.MoveToNext());
            }
        }
        
        class Contact
        {
            public long Id { get; set; }

            public string DisplayName{ get; set; }
            
            public string PhotoId { get; set; }

            public string number { get; set; }
        }
    }
}

