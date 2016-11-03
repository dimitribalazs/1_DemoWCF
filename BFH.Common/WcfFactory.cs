using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace BFH.Common
{
    public class WcfFactory<T> : IDisposable where T : class
    {
        private static IClientChannel _proxy;
        public T Proxy
        {
            get
            {
                if (_proxy != null && _proxy.State == CommunicationState.Opened)
                {
                    return (T)_proxy;
                }
                else if (_proxy != null && _proxy.State == CommunicationState.Faulted)
                {
                    _proxy.Abort();
                }

                //BasicHttpBinding() doesnt allow Sessions, so one Instance per Call
                _proxy = ChannelFactory<T>.CreateChannel(new WSHttpBinding(),
                    new EndpointAddress("http://localhost:4711/DemoService")) as IClientChannel;
                return (T)_proxy;
            }
            set
            {
                _proxy = value as IClientChannel;
            }
        }

        public void CloseProxy()
        {
            Dispose();
        }
        public void Dispose()
        {
            _proxy.Close();
        }
    }
}