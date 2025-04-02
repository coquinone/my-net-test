using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreWCF;
using System.ServiceModel;


namespace WcfServiceLibrary.SampleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            System.ServiceModel.BasicHttpBinding wSHttpBinding = new System.ServiceModel.BasicHttpBinding();
            System.ServiceModel.EndpointAddress endpointAddress = new System.ServiceModel.EndpointAddress(@"http://localhost:8743/testservice/WcfServiceLibrary");
            System.ServiceModel.ChannelFactory<IService1> channelFactory = new System.ServiceModel.ChannelFactory<IService1>(wSHttpBinding, endpointAddress);
            IService1 proxyObject = channelFactory.CreateChannel();

            string returnValue = proxyObject.GetData(50);
            string returnValue3 = proxyObject.GetData(555);

            Console.WriteLine();
        }
    }
}