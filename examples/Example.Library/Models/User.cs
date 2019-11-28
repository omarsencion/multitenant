using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ProtoBuf;
using XPike.Contracts;

namespace Example.Library.Models
{
    [Serializable]
    [DataContract]
    [ProtoContract]
    public class User
        : IModel
    {
        [DataMember]
        [ProtoMember(1)]
        [Key]
        public int Id { get; set; }

        [DataMember]
        [ProtoMember(2)]
        public string Name { get; set; }
       
        [DataMember]
        [ProtoMember(3)]
        public decimal Credits { get; set; }
        
        [DataMember]
        [ProtoMember(4)]
        public DateTime Created { get; set; }
        
        [DataMember]
        [ProtoMember(5)]
        public bool Enabled { get; set; }
        
        [DataMember]
        [ProtoMember(6)]
        [JsonConverter(typeof(StringEnumConverter))]
        public UserType UserType { get; set; }
        
        [DataMember]
        [ProtoMember(7)]
        public DateTime? Expires { get; set; }

        [DataMember]
        [ProtoMember(8)]
        public int UserLevel { get; set; }

        [DataMember]
        [ProtoMember(9)]
        public ContactInfo ContactInfo { get; set; }
    }
}