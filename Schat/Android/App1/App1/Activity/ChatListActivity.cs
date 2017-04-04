using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System;
using Android.Views;
using Android.Content;

namespace App1
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = false, Icon = "@drawable/icon")]
    public class ChatListActivity : Activity
    {
        List<chatList> myArr;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ChatListLayout);
            int senderID = 0;
            ListView ChatList = FindViewById<ListView>(Resource.Id.chatList);
            myArr = SampleData();

            ChatListAdapter adapter = new ChatListAdapter(this, myArr);
            ChatList.Adapter = adapter;

            ChatList.ItemClick += delegate(object sender,AdapterView.ItemClickEventArgs args)
            {
                var intent = new Intent(this, typeof(ConversationActivity));
                intent.PutExtra("senderID", senderID);
                StartActivity(intent);

            };


        }
        public List<chatList> SampleData()
        {
            List<chatList> myArr = new List<chatList>();

            chatList chat1 = new chatList();
            chat1.contacNumber = "9032559007";
            chat1.lastMessage = "Hi";

            chatList chat2 = new chatList();
            chat2.contacNumber = "8019808172";
            chat2.lastMessage = "bye";

            chatList chat3 = new chatList();
            chat3.contacNumber = "7331190304";
            chat3.lastMessage = "hello";

            myArr.Add(chat1);
            myArr.Add(chat2);
            myArr.Add(chat3);

            return myArr;
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            try
            {
                if (item.ItemId == Resource.Id.newChat)
                {
                    StartActivity(typeof(PickContactActivity));
                }
                switch (item.ItemId)
                {
                    case Resource.Id.Profile:
                        var intent = new Intent(this, typeof(Registration));
                        intent.PutExtra("MyData", "Wall Store");
                        StartActivity(intent);
                        break;

                    case Resource.Id.settings:
                        var intent1 = new Intent(this, typeof(Registration));
                        intent1.PutExtra("MyData", "Wall Store");
                        StartActivity(intent1);
                        break;

                    //case Resource.Id.exit:
                    //    Finish();
                    //    return false;

                }

            }
            catch(Exception exception)
            {
                string str = exception.Message;
            }
            return base.OnOptionsItemSelected(item);

        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {


            MenuInflater.Inflate(Resource.Drawable.options_menu, menu);
            return true;
        }



    }
    
}

