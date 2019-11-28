using System;
using System.Runtime.Serialization;
using ProtoBuf;

namespace Example.Library.Models
{
    [Serializable]
    [DataContract]
    [ProtoContract]
    public enum UserType
    {
        [EnumMember]
        [ProtoEnum]
        Unknown = 0,

        [EnumMember]
        [ProtoEnum]
        User = 1,
        
        [EnumMember]
        [ProtoEnum]
        Member = 2,
        
        [EnumMember]
        [ProtoEnum]
        Admin = 3
    }
}