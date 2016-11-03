using BFH.Demo.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BFH.Demo.Implementation
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Demo : IDemo
    {
        private double _internalValue;

        public Demo()
        {
        }
        public string GetApplicationDomainName()
        {
            return AppDomain.CurrentDomain.FriendlyName;
        }

        public double GetValue()
        {
            return _internalValue;
        }

        public void SetValue(double value)
        {
            _internalValue = value;
        }

        public DemoEnum NextValue(DemoEnum enumValue)
        {
            IList values = Enum.GetValues(typeof(DemoEnum));
            var index = values.IndexOf(enumValue);
            return (DemoEnum)values[index + 1];
        }
         


        public IList<DemoData> Update(DemoData data, int amount)
        {
            var demoData = new List<DemoData>(amount);
            data.Name += "Roundtrip";
            demoData.Add(data);

            

            for (int index = 0; index < amount; index++)
            {
                demoData.Add(GenerateDemoDataObject());
            }
           
            return demoData;
        }

        private DemoData GenerateDemoDataObject()
        {
            var random = new Random();
            var demoData = new DemoData
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                EnumValue = DemoEnum.Medium,
                Data = new byte[] { 0xAA },
                Value = random.NextDouble(),
                Name = $"Name is: {Guid.NewGuid()}"
            };

            return demoData;
         
        }
    }
}
