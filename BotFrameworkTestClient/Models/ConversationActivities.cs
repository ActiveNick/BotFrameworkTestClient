using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectLine.Models
{
    public class ConversationActitvities
    {
        public Activity[] activities { get; set; }
        public string watermark { get; set; }
        public string eTag { get; set; }
    }

}
