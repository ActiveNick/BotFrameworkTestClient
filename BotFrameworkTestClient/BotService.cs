using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BotFrameworkTestClient
{
    class Conversation
    {
        public string conversationId { get; set; }
        public string token { get; set; }
        public string eTag { get; set; }
        public string expires_in { get; set; }
    }

    public class ConversationAccount
    {
        public string id { get; set; }
        public bool isGroup { get; set; }
        public string name { get; set; }
    }

    public class ConversationReference
    {
        public string id { get; set; }
    }

    public class ConversationActitvities
    {
        public Activity[] activities { get; set; }
        public string watermark { get; set; }
        public string eTag { get; set; }
    }

    public class ChannelAccount
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets display friendly name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class ActivityReference
    {
        public string id { get; set; }
    }

    public class Activity
    {
        /// <summary>
        /// Gets or sets the type of the activity
        /// [message|contactRelationUpdate|converationUpdate|typing|endOfConversation|event|invoke]
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets ID of this activity
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets UTC Time when message was sent (set by service)
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public System.DateTime? Timestamp { get; set; }

        /// <summary>
        /// Gets or sets local time when message was sent (set by client, Ex:
        /// 2016-09-23T13:07:49.4714686-07:00)
        /// </summary>
        [JsonProperty(PropertyName = "localTimestamp")]
        public System.DateTime? LocalTimestamp { get; set; }

        /// <summary>
        /// Gets or sets service endpoint where operations concerning the
        /// activity may be performed
        /// </summary>
        [JsonProperty(PropertyName = "serviceUrl")]
        public string ServiceUrl { get; set; }

        /// <summary>
        /// Gets or sets ID of the channel where the activity was sent
        /// </summary>
        [JsonProperty(PropertyName = "channelId")]
        public string ChannelId { get; set; }

        /// <summary>
        /// Gets or sets sender address
        /// </summary>
        [JsonProperty(PropertyName = "from")]
        public ChannelAccount FromAccount { get; set; }

        /// <summary>
        /// Gets or sets conversation
        /// </summary>
        [JsonProperty(PropertyName = "conversation")]
        public ConversationAccount Conversation { get; set; }

        /// <summary>
        /// Gets or sets (Outbound to bot only) Bot's address that received the
        /// message
        /// </summary>
        [JsonProperty(PropertyName = "recipient")]
        public ChannelAccount Recipient { get; set; }

        /// <summary>
        /// Gets or sets format of text fields [plain|markdown]
        /// Default:markdown
        /// </summary>
        [JsonProperty(PropertyName = "textFormat")]
        public string TextFormat { get; set; }

        /// <summary>
        /// Gets or sets hint for how to deal with multiple attachments:
        /// [list|carousel] Default:list
        /// </summary>
        [JsonProperty(PropertyName = "attachmentLayout")]
        public string AttachmentLayout { get; set; }

        /// <summary>
        /// Gets or sets array of address added
        /// </summary>
        [JsonProperty(PropertyName = "membersAdded")]
        public IList<ChannelAccount> MembersAdded { get; set; }

        /// <summary>
        /// Gets or sets array of addresses removed
        /// </summary>
        [JsonProperty(PropertyName = "membersRemoved")]
        public IList<ChannelAccount> MembersRemoved { get; set; }

        /// <summary>
        /// Gets or sets conversations new topic name
        /// </summary>
        [JsonProperty(PropertyName = "topicName")]
        public string TopicName { get; set; }

        /// <summary>
        /// Gets or sets true if the previous history of the channel is
        /// disclosed
        /// </summary>
        [JsonProperty(PropertyName = "historyDisclosed")]
        public bool? HistoryDisclosed { get; set; }

        /// <summary>
        /// Gets or sets the language code of the Text field
        /// </summary>
        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets content for the message
        /// </summary>
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets SSML Speak for TTS audio response
        /// </summary>
        [JsonProperty(PropertyName = "speak")]
        public string Speak { get; set; }

        /// <summary>
        /// Gets or sets indicates whether the bot is accepting, expecting, or
        /// ignoring input
        /// </summary>
        [JsonProperty(PropertyName = "inputHint")]
        public string InputHint { get; set; }

        /// <summary>
        /// Gets or sets text to display if the channel cannot render cards
        /// </summary>
        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets suggestedActions are used to provide
        /// keyboard/quickreply like behavior in many clients
        /// </summary>
        [JsonProperty(PropertyName = "suggestedActions")]
        public SuggestedActions SuggestedActions { get; set; }

        /// <summary>
        /// Gets or sets attachments
        /// </summary>
        [JsonProperty(PropertyName = "attachments")]
        public IList<Attachment> Attachments { get; set; }

        /// <summary>
        /// Gets or sets collection of Entity objects, each of which contains
        /// metadata about this activity. Each Entity object is typed.
        /// </summary>
        [JsonProperty(PropertyName = "entities")]
        public IList<Entity> Entities { get; set; }

        /// <summary>
        /// Gets or sets channel-specific payload
        /// </summary>
        [JsonProperty(PropertyName = "channelData")]
        public object ChannelData { get; set; }

        /// <summary>
        /// Gets or sets contactAdded/Removed action
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        /// <summary>
        /// Gets or sets the original ID this message is a response to
        /// </summary>
        [JsonProperty(PropertyName = "replyToId")]
        public string ReplyToId { get; set; }

        /// <summary>
        /// Gets or sets open-ended value
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets name of the operation to invoke or the name of the
        /// event
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets reference to another conversation or activity
        /// </summary>
        [JsonProperty(PropertyName = "relatesTo")]
        public ConversationReference RelatesTo { get; set; }

        /// <summary>
        /// Gets or sets code indicating why the conversation has ended
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }
    }

    /// <summary>
    /// Object of schema.org types
    /// </summary>
    public partial class Entity
    {
        /// <summary>
        /// Gets or sets entity Type (typically from schema.org types)
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }

    public class Attachment
    {
        public string url { get; set; }
        public string contentType { get; set; }
    }

    class KeyRequest
    {
        public string Mainkey { get; set; }
    }

    /// <summary>
    /// SuggestedActions that can be performed
    /// </summary>
    public class SuggestedActions
    {
        /// <summary>
        /// Gets or sets ids of the recipients that the actions should be shown
        /// to.  These Ids are relative to the channelId and a subset of all
        /// recipients of the activity
        /// </summary>
        [JsonProperty(PropertyName = "to")]
        public IList<string> To { get; set; }

        /// <summary>
        /// Gets or sets actions that can be shown to the user
        /// </summary>
        [JsonProperty(PropertyName = "actions")]
        public IList<CardAction> Actions { get; set; }
    }

    public partial class CardAction
    {
        /// <summary>
        /// Gets or sets defines the type of action implemented by this button.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets text description which appear on the button.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets URL Picture which will appear on the button, next to
        /// text label.
        /// </summary>
        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets supplementary parameter for action. Content of this
        /// property depends on the ActionType
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public object Value { get; set; }
    }

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
            // Constructor
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

