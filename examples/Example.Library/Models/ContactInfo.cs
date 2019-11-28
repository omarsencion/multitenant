using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using ProtoBuf;
using XPike.Contracts;

namespace Example.Library.Models
{
    [Serializable]
    [DataContract]
    [ProtoContract]
    public class ContactInfo
        : IModel
    {
        [DataMember]
        [ProtoMember(1)]
        public string EmailAddress { get; set; }

        [DataMember]
        [ProtoMember(2)]
        public string PhoneNumber { get;set; }

        [DataMember]
        [ProtoMember(3)]
        public int UserId { get; set; }

        [DataMember]
        [ProtoMember(4)]
        [Key]
        public int ContactId { get; set; }

        [DataMember]
        [ProtoMember(5)]
        public User User { get; set; }
    }
}