// Unset this to run external local silo
// http://dotnet.github.io/orleans/Step-by-step-Tutorials/Running-in-a-Stand-alone-Silo
#define USE_INPROC_SILO

using System;
using System.Threading.Tasks;
using GrainProject;
using Orleans;

namespace OrleansApp
{
    /// <summary>
    /// Orleans test silo host
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
#if USE_INPROC_SILO
            // The Orleans silo environment is initialized in its own app domain in order to more
            // closely emulate the distributed situation, when the client and the server cannot
            // pass data via shared memory.
            AppDomain hostDomain = AppDomain.CreateDomain("OrleansHost", null, new AppDomainSetup
            {
                AppDomainInitializer = InitSilo,
                AppDomainInitializerArguments = args,
            });
#endif

            Task.Run(async () =>
            {
                GrainClient.Initialize("ClientConfiguration.xml");

                var g1 = GrainClient.GrainFactory.GetGrain<IMyGrain>(Guid.NewGuid());
                var g2 = GrainClient.GrainFactory.GetGrain<IMyGrain>(Guid.NewGuid());



                await g2.SubscribeTo(g1.GetPrimaryKey());

                await g1.EmitMyObjectViaStream();
                bool hasNoSubscribers = await g2.MyObjectTransferredCorrectly();

                Console.WriteLine("Event has no subscribers: {0}", hasNoSubscribers);

            }).Wait();

            Console.WriteLine("Orleans Silo is running.\nPress Enter to terminate...");
            Console.ReadLine();

#if USE_INPROC_SILO
            hostDomain.DoCallBack(ShutdownSilo);
#endif
        }

#if USE_INPROC_SILO
        static void InitSilo(string[] args)
        {
            hostWrapper = new OrleansHostWrapper(args);

            if (!hostWrapper.Run())
            {
                Console.Error.WriteLine("Failed to initialize Orleans silo");
            }
        }

        static void ShutdownSilo()
        {
            if (hostWrapper != null)
            {
                hostWrapper.Dispose();
                GC.SuppressFinalize(hostWrapper);
            }
        }

        private static OrleansHostWrapper hostWrapper;
#endif
    }
}