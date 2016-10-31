using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BFH.Demo.Contracts
{
    [ServiceContract(Name = "Demo", Namespace = Constants.XMLNamespace)]
    public interface IDemo
    {
        [OperationContract(Name = "GetApplicationDomainName")]
        string GetApplicationDomainName();

        [OperationContract(Name = "SetValue")]
        void SetValue(double value);

        [OperationContract(Name = "GetValue")]
        double GetValue();

        [OperationContract(Name = "Update")]
        IList<DemoData> Update(DemoData data, int amount);

        [OperationContract(Name = "NextValue")]
        DemoEnum NextValue(DemoEnum enumValue);
    }
}
