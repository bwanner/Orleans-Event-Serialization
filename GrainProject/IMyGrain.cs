using System;
using System.Threading.Tasks;
using Orleans;

namespace GrainProject
{
    public interface IMyGrain : IGrainWithGuidKey
    {
        Task SubscribeTo(Guid guid);

        Task SubscribeEventAndEmitMyObject();

        Task<bool> EventHasNoSubscribers();
    }
}