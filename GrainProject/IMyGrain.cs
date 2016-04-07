using System;
using System.Threading.Tasks;
using Orleans;

namespace GrainProject
{
    public interface IMyGrain : IGrainWithGuidKey
    {
        Task SubscribeTo(Guid guid);

        Task SubscribeEventAndEmitMyObjectViaStream();

        Task EmitMyObjectViaMethodCall(IMyGrain other);

        Task ReceiveMyObject(MyObject myObject);

        Task<bool> EventHasNoSubscribers();
    }
}