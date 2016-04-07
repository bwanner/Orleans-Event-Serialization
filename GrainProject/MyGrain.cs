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
        private MyObject _myObject;

        public override Task OnActivateAsync()
        {
            _myObject = new MyObject();
            return base.OnActivateAsync();
        }

        public async Task SubscribeTo(Guid guid)
        {
            var stream = GetStreamProvider("SMS").GetStream<MyObject>(guid, "Namespace");
            await stream.SubscribeAsync(OnNextAsync);
        }

        public async Task EmitMyObjectViaStream()
        {
            var stream = GetStreamProvider("SMS").GetStream<MyObject>(this.GetPrimaryKey(), "Namespace");
            _myObject.MyString = Guid.NewGuid().ToString();
            await stream.OnNextAsync(_myObject);
        }

        public async Task EmitMyObjectViaMethodCall(IMyGrain other)
        {
            _myObject.MyString = Guid.NewGuid().ToString();
            await other.ReceiveMyObject(_myObject);
        }

        public Task ReceiveMyObject(MyObject myObject)
        {
            _myObject = myObject;
            return TaskDone.Done;
        }

        private Task OnNextAsync(MyObject myObject, StreamSequenceToken streamSequenceToken)
        {
            _myObject = myObject;
            return TaskDone.Done;
        }

        public Task<bool> MyObjectTransferredCorrectly()
        {
            return Task.FromResult(_myObject.StringNull);
        }
    }
}
