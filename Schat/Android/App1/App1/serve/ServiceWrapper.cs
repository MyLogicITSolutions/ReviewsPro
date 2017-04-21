using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using SChat.Models;

namespace App1
{
    public class ServiceWrapper
    {
        HttpClient client;
        public ServiceWrapper()
        {
            client = new HttpClient();
            //client.MaxResponseContentBufferSize = 256000;
        }

        public string ServiceURL
        {
            get
            {
                //string host = "http://localhost:56049/";
                string host = "http://chatservices.azurewebsites.net/";
                return host + "api/SCHAT/";
            }

        }



        //public async Task<string> GetDataAsync()
        //{
        //    var uri = new Uri(ServiceURL + "TestService/1");
        //    var response = await client.GetAsync(uri);
        //    string output = "";
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        output = JsonConvert.DeserializeObject<string>(content);
        //    }
        //    return output;
        //}
        public async Task<ConversationResponse> GetConversationList(int senderID, int receiverID)
        {
            var uri = new Uri(ServiceURL + "ConversationList/" + senderID + "/user/" + receiverID);
            var response = await client.GetStringAsync(uri).ConfigureAwait(false);
            var output = JsonConvert.DeserializeObject<ConversationResponse>(response);
            return output;
        }

        public async Task<UserDetailsResponse> userdetailsList(string mobileno)
        {
            var uri = new Uri(ServiceURL + "userdetailsList/" + mobileno);
            var response = await client.GetStringAsync(uri).ConfigureAwait(false);
            var output = JsonConvert.DeserializeObject<UserDetailsResponse>(response);
            return output;
        }

        //public async Task<ItemDetailsResponse> GetItemDetails(int wineid)
        //{
        //    var uri = new Uri(ServiceURL + "GetItemDetails/" + wineid);
        //    var response = await client.GetStringAsync(uri).ConfigureAwait(false);
        //    var output = JsonConvert.DeserializeObject<ItemDetailsResponse>(response);
        //    return output;
        //}
        public async Task<int> InsertUpdateUsers(Registration reg)
        {
            try
            {

                var uri = new Uri(ServiceURL + "GetUserList/");
                var content = JsonConvert.SerializeObject(reg);
                var cont = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, cont); // In debug mode it do not work, Else it works
                //var result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 1;
        }


        //public async Task<CustomerResponse> AuthencateUser(string UserName)
        //{
        //    var uri = new Uri(ServiceURL + "AuthenticateUser/" + UserName);
        //    var response = await client.GetStringAsync(uri).ConfigureAwait(false);
        //    var output = JsonConvert.DeserializeObject<CustomerResponse>(response);
        //    return output;
        //}

        ////public async Task<ItemReviewResponse> GetItemReviewSKU(int sku)
        ////{
        ////    var uri = new Uri(ServiceURL + "/GetItemReviewsSKU/" + sku);
        ////    var response = await client.GetStringAsync(uri).ConfigureAwait(false);
        ////    var output = JsonConvert.DeserializeObject<ItemReviewResponse>(response);
        ////    return output;
        ////}

        //public async Task<ItemReviewResponse> GetItemReviewsByWineID(int WineID)
        //{
        //    var uri = new Uri(ServiceURL + "/GetItemReviewsWineID/" + WineID);
        //    var response = await client.GetStringAsync(uri).ConfigureAwait(false);
        //    var output = JsonConvert.DeserializeObject<ItemReviewResponse>(response);
        //    return output;
        //}

        //public async Task<ItemReviewResponse> GetItemReviewUID(int userId)
        //{
        //    var uri = new Uri(ServiceURL + "GetItemReviewsUID/" + userId);
        //    var response = await client.GetStringAsync(uri).ConfigureAwait(false);
        //    var output = JsonConvert.DeserializeObject<ItemReviewResponse>(response);
        //    return output;
        //}

        public async Task<int> InsertMessage(InsertMessages ins)
        {
            try
            {

                var uri = new Uri(ServiceURL + "GetInsertMessageList/" + ins.sender_id + "/user/" + ins.receiver_id + "/message/" + ins.InsertMessage);
                var content = JsonConvert.SerializeObject(ins);
                var cont = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, cont); // In debug mode it do not work, Else it works
                //var result = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 1;
        }
        //public async Task<int> DeleteReview(Review review)
        //{
        //    try
        //    {
        //        var uri = new Uri(ServiceURL + "DeleteReview/");
        //        var content = JsonConvert.SerializeObject(review);
        //        var cont = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
        //        var response = await client.PostAsync(uri, cont); // In debug mode it do not work, Else it works
        //        //var result = response.Content.ReadAsStringAsync().Result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return 1;
        //}
        //public async Task<int> UpdateCustomer(Customer customer)
        //{
        //    try
        //    {
        //        var uri = new Uri(ServiceURL + "UpdateCustomer/");
        //        var content = JsonConvert.SerializeObject(customer);
        //        var cont = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
        //        var response = await client.PostAsync(uri, cont); // In debug mode it do not work, Else it works
        //        //var result = response.Content.ReadAsStringAsync().Result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return 1;
        //}
        public async Task<ChatListResponse> GetChatList(string userId)
        {
            var uri = new Uri(ServiceURL + "ChatList/" + userId);
            var response = await client.GetStringAsync(uri).ConfigureAwait(false);
            var output = JsonConvert.DeserializeObject<ChatListResponse>(response);
            return output;
        }
        //public async Task<CustomerResponse> GetCustomerDetails(int userID)
        //{
        //    var uri = new Uri(ServiceURL + "GetCustomerDetails/" + userID);
        //    var response = await client.GetStringAsync(uri).ConfigureAwait(false);
        //    var output = JsonConvert.DeserializeObject<CustomerResponse>(response);
        //    return output;
        //}
        //public async Task<TastingListResponse> GetMyTastingsList(int customerid)
        //{
        //    //customerid = 38691;
        //    var uri = new Uri(ServiceURL + "GetMyTastingsList/" + customerid);
        //    var response = await client.GetStringAsync(uri).ConfigureAwait(false);
        //    var output = JsonConvert.DeserializeObject<TastingListResponse>(response);
        //    return output;
        //}
    }
}