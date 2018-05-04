using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFrameworkTestClient.Models
{
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
}
