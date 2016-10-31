using BFH.Demo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BFH.Demo.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost serviceHost = null;
            try
            {

                Console.WriteLine("Starting Host");
                

                try
                {
                    //konkreter type. muss instanzierbar sein
                    serviceHost = new ServiceHost(typeof(Demo.Implementation.Demo));
                    serviceHost.AddServiceEndpoint(typeof(IDemo), new BasicHttpBinding(), "http://localhost:4711/DemoService");
                    serviceHost.Open();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("ServiceHost: " + ex.Message);
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.ReadKey();
            }
            finally
            {
                serviceHost?.Close();
            }
        }
    }
}
