// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace DirectLine.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// MediaUrl data
    /// </summary>
    public partial class MediaUrl
    {
        /// <summary>
        /// Initializes a new instance of the MediaUrl class.
        /// </summary>
        public MediaUrl()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the MediaUrl class.
        /// </summary>
        /// <param name="url">Url for the media</param>
        /// <param name="profile">Optional profile hint to the client to
        /// differentiate multiple MediaUrl objects from each other</param>
        public MediaUrl(string url = default(string), string profile = default(string))
        {
            Url = url;
            Profile = profile;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets url for the media
        /// </summary>
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets optional profile hint to the client to differentiate
        /// multiple MediaUrl objects from each other
        /// </summary>
        [JsonProperty(PropertyName = "profile")]
        public string Profile { get; set; }

    }
}