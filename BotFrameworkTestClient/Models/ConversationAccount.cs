using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotFrameworkTestClient.Models
{
    public class ConversationAccount
    {
        public string id { get; set; }
        public bool isGroup { get; set; }
        public string name { get; set; }
    }
}
