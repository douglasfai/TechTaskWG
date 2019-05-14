using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TechTaskWG.DTO
{
    [DataContract]
    public abstract class Base
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public double Price { get; set; }
    }
}
