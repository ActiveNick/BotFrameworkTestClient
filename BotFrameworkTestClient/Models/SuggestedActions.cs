using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFrameworkTestClient.Models
{
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
}
