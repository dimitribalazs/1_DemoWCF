using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BFH.Demo.Contracts
{
    [DataContract(Name = "DemoEnum", Namespace = Constants.XMLNamespace)]
    public enum DemoEnum
    {
        [EnumMember]
        Unknown,

        [EnumMember]
        Large,

        [EnumMember]
        Medium,

        [EnumMember]
        Small
    }
}
