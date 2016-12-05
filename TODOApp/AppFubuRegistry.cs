using FubuMVC.Core;
using StructureMap.Graph;

namespace TODOApp
{
    public class AppFubuRegistry : FubuRegistry
    {
        public AppFubuRegistry()
        {
            //grab all classes that are suffixed with Endpoint and turn the public methods into actions
            //This will occur by default, only placed in here for understanding
            Actions.IncludeClassesSuffixedWithEndpoint();


            //Setup for the IOC (Inverson of Control) container using StructureMap (Fubu3 only supports StructureMap)
            Services.IncludeRegistry<CoreRegistry>();


            //Enables the Fubu3 Diagnostics - Very useful for troubleshooting your application (access via "localhost:port#/_fubu")
            Features.Diagnostics.Enable(TraceLevel.Verbose);
        }
    }
}