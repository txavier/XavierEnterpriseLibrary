using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XavierEnterpriseLibrary.Core.Objects
{
    public class EmailAttachment
    {
        public string Filename { get; set; }
        public byte[] Data { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
