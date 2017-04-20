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
using static App1.CurrentUser;

namespace App1
{
    [Activity(Label = "Conversation", MainLauncher = false)]
    public class ConversationActivity : Activity
    {
        List<RetriveMessages> myArr;
        List<RetriveMessages> myArr1;
        ListView ReceiverList;
        ListView SenderList;

        public void RefreshParent()
        {
            try
            {
                ServiceWrapper svc = new ServiceWrapper();
                ConversationResponse cvr = new ConversationResponse();
                cvr = svc.GetConversationList(Convert.ToInt32(CurrentUser.getUserId()), 2).Result;
                myArr = cvr.ConversationList.ToList<RetriveMessages>();
                SenderListAdapter adapter = new SenderListAdapter(this, myArr);
                SenderList.Adapter = adapter;
                adapter.NotifyDataSetChanged();
                ConversationResponse cvr1 = new ConversationResponse();
                cvr1 = svc.GetConversationList(2, Convert.ToInt32(CurrentUser.getUserId())).Result;
                myArr1 = cvr1.ConversationList.ToList<RetriveMessages>();
                ReceiverListAdapter adapter1 = new ReceiverListAdapter(this, myArr1);
                ReceiverList.Adapter = adapter1;
                adapter1.NotifyDataSetChanged();
            }
            catch(Exception e)
            {

            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                Window.RequestFeature(WindowFeatures.NoTitle);
                SetContentView(Resource.Layout.ConversationLayout);
                ServiceWrapper svc = new ServiceWrapper();
                InsertMessages ins = new InsertMessages();
                SenderList = FindViewById<ListView>(Resource.Id.senderList);
                ReceiverList = FindViewById<ListView>(Resource.Id.receiverList);

                ConversationResponse cvr = new ConversationResponse();
                cvr = svc.GetConversationList(Convert.ToInt32(CurrentUser.getUserId()), 2).Result;
                myArr = cvr.ConversationList.ToList<RetriveMessages>();
                SenderListAdapter adapter = new SenderListAdapter(this, myArr);
                SenderList.Adapter = adapter;
                ConversationResponse cvr1 = new ConversationResponse();
                cvr1 = svc.GetConversationList(2, Convert.ToInt32(CurrentUser.getUserId())).Result;
                myArr1 = cvr1.ConversationList.ToList<RetriveMessages>();
                ReceiverListAdapter adapter1 = new ReceiverListAdapter(this, myArr1);
                ReceiverList.Adapter = adapter1;

                EditText ed = FindViewById<EditText>(Resource.Id.txtmsg);
                ImageButton ib = FindViewById<ImageButton>(Resource.Id.btnSend);
                ib.Click += async delegate
                {
                    ins.InsertMessage = ed.Text;
                    ins.sender_id = Convert.ToInt32(CurrentUser.getUserId());
                    ins.receiver_id = 2;
                    int i = await svc.InsertMessage(ins);
                    try
                    {
                        RefreshParent();
                    }
                    catch(Exception e)
                    {

                    }
                    ed.Dispose();
                };
            }
            catch (Exception e)
            {
            }


        }
       
    }

    
}