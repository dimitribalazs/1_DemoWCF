using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BFH.Demo.Contracts
{
    [DataContract(Name = "DemoData", Namespace = Constants.XMLNamespace)]
    public class DemoData
    {
        [DataMember(Name = "Id", Order = 1)]
        public Guid Id { get; set; }

        [DataMember(Name = "Name", Order = 1)]
        public string Name { get; set; }

        [DataMember(Name = "Date", Order = 1)]
        public DateTime Date { get; set; }

        [DataMember(Name = "Data", Order = 1)]
        public byte[] Data { get; set; }

        [DataMember(Name = "Value", Order = 1)]
        public double Value { get; set; }
         
        public DemoEnum EnumValue { get; set; }
    }
}
