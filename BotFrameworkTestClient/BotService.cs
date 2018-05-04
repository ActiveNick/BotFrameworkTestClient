﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BotFrameworkTestClient.Models;

namespace BotFrameworkTestClient
{
    public class BotService
    {
        private string APIKEY;
        private string botToken;
        private string activeConversation;
        private string activeWatermark;
        private string newActivityId;
        private string lastResponse;

        public BotService()
        {
            // No specific constructor for now
        }

        public async Task<string> StartConversation(string secret)
        {
            APIKEY = secret;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://directline.botframework.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Authorize
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + APIKEY);

                // Get a new token as dummy call
                var keyreq = new KeyRequest() { Mainkey = "" };
                var stringContent = new StringContent(keyreq.ToString());
                HttpResponseMessage response = await client.PostAsync("v3/directline/conversations", stringContent);
                if (response.IsSuccessStatusCode)
                {
                    var re = response.Content.ReadAsStringAsync().Result;
                    var myConversation = JsonConvert.DeserializeObject<Conversation>(re);
                    activeConversation = myConversation.conversationId;
                    botToken = myConversation.token;
                    return myConversation.conversationId;
                }

            }

            return "Error";
        }

        public async Task<bool> SendMessage(string message)
        {
            using (var client = new HttpClient())
            {
                string conversationId = activeConversation;

                client.BaseAddress = new Uri("https://directline.botframework.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Authorize
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + botToken);

                // Send a message
                string messageId = Guid.NewGuid().ToString();
                DateTime timeStamp = DateTime.Now;
                var attachment = new Attachment();
                var myMessage = new Activity()
                {
                    Type = "message",
                    FromAccount = new ChannelAccount() { Id = "Windows 10 User" },
                    Text = message
                };

                string postBody = JsonConvert.SerializeObject(myMessage);
                String urlString = "v3/directline/conversations/" + conversationId + "/activities";
                HttpContent httpContent = new StringContent(postBody, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(urlString, httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var re = response.Content.ReadAsStringAsync().Result;
                    lastResponse = re;
                    var ar = JsonConvert.DeserializeObject<ActivityReference>(re);
                    newActivityId = ar.id;
                    return true;
                }
                else
                {
                    lastResponse = response.Content.ReadAsStringAsync().Result;
                }
                return false;
            }
        }
        public async Task<string> GetNewestActivity()
        {
            ConversationActitvities cm = await GetNewestActivities();
            if (cm.activities.Length > 0)
            {
                return cm.activities[cm.activities.Length - 1].Text;
            }
            else
            {
                return "";
            }
        }

        public async Task<ConversationActitvities> GetNewestActivities()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(200)).ConfigureAwait(true);
            int inc = 0;
            ConversationActitvities cm = await GetMessages();
            while (++inc < 5)
            {
                Debug.WriteLine(cm.activities.Length + " conversations received");
                for (int i = 0; i < cm.activities.Length; i++)
                {
                    var activity = cm.activities[i];
                    Debug.WriteLine("activity received = " + activity.Text);
                    lastResponse = activity.Id + " / " + activity.ReplyToId + " / " + newActivityId;

                    // wait for reply message from my message
                    if (activity.ReplyToId != null && activity.ReplyToId.Equals(newActivityId))
                    {
                        Debug.WriteLine("activity is response to " + newActivityId);
                        return cm;
                    }
                }
                await Task.Delay(TimeSpan.FromMilliseconds(200)).ConfigureAwait(true);
                cm = await GetMessages();
            }
            return cm;
        }

        public async Task<ConversationActitvities> GetMessages()
        {
            using (var client = new HttpClient())
            {
                string conversationId = activeConversation;

                client.BaseAddress = new Uri("https://directline.botframework.com/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Authorize
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + botToken);

                ConversationActitvities cm = new ConversationActitvities();
                string messageURL = "v3/directline/conversations/" + conversationId + "/activities";
                if (activeWatermark != null)
                    messageURL += "?watermark=" + activeWatermark;
                HttpResponseMessage response = await client.GetAsync(messageURL);
                if (response.IsSuccessStatusCode)
                {
                    var re = response.Content.ReadAsStringAsync().Result;
                    lastResponse = re.ToString();
                    cm = JsonConvert.DeserializeObject<ConversationActitvities>(re);
                    activeWatermark = cm.watermark;
                    return cm;
                }
                return cm;
            }
        }
    }
}

