using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TechTaskWG.DTO
{
    public class Product : Base
    {
        [DataMember]
        public List<Component> Components { get; set; }
        [DataMember]
        public string Ip { get; set; }
    }
}
