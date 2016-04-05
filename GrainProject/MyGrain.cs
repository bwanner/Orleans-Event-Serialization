using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;
using Orleans.Streams;

namespace GrainProject
{
    public class MyGrain : Grain, IMyGrain
    {
        private MySuperObject _holder;

        public override Task OnActivateAsync()
        {
            _holder = new MySuperObject(this.GetPrimaryKey());
            return base.OnActivateAsync();
        }


        public async Task SubscribeTo(Guid guid)
        {
            var stream = GetStreamProvider("SMS").GetStream<MyObject>(guid, "Namespace");
            await stream.SubscribeAsync(OnNextAsync);
        }

        public async Task SubscribeEventAndEmitMyObject()
        {
            var stream = GetStreamProvider("SMS").GetStream<MyObject>(this.GetPrimaryKey(), "Namespace");
            _holder.MyObject.MyEvent += XOnMyEvent;
            await stream.OnNextAsync(_holder.MyObject);
        }

        private void XOnMyEvent(object sender, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }

        private Task OnNextAsync(MyObject myObject, StreamSequenceToken streamSequenceToken)
        {
            _holder.MyObject = myObject;
            return TaskDone.Done;
        }

        public Task<bool> EventHasNoSubscribers()
        {
            return Task.FromResult(_holder.MyObject.HasNoSubscribers());
        }

        public Task SubscribeToEvent()
        {
            //_holder.Subscribe();
            return TaskDone.Done;
        }
    }
}
