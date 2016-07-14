using System;
using System.Runtime.Serialization;

namespace Sample.CrossCutting.DTO.Modules.Receiver
{
    [DataContract]
    public class SearchDTO
    {
        [DataMember]
        public int Range { get; set; }
        [DataMember]
        public string Keyword { get; set; }
        [DataMember]
        public string Domain { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Language { get; set; }
    }
}
