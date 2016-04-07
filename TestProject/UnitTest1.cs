using System;
using System.Threading.Tasks;
using GrainProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orleans;
using Orleans.Runtime;
using Orleans.TestingHost;

namespace TestProject
{
    [TestClass]
    public class UnitTest1 : TestingSiloHost
    {
        public UnitTest1() : base(new TestingSiloOptions() {StartSecondary = false}) { }

        private async Task TestSendViaStream()
        {
            var g1 = GrainClient.GrainFactory.GetGrain<IMyGrain>(Guid.NewGuid());
            var g2 = GrainClient.GrainFactory.GetGrain<IMyGrain>(Guid.NewGuid());

            Assert.IsTrue(await g1.EventHasNoSubscribers());

            await g2.SubscribeTo(g1.GetPrimaryKey());

            await g1.SubscribeEventAndEmitMyObjectViaStream();
            Assert.IsTrue(await g2.EventHasNoSubscribers());
        }

        private async Task TestSendViaMethodCall()
        {
            var g1 = GrainClient.GrainFactory.GetGrain<IMyGrain>(Guid.NewGuid());
            var g2 = GrainClient.GrainFactory.GetGrain<IMyGrain>(Guid.NewGuid());

            Assert.IsTrue(await g1.EventHasNoSubscribers());

            await g2.SubscribeTo(g1.GetPrimaryKey());

            await g1.EmitMyObjectViaMethodCall(g2);
            Assert.IsTrue(await g2.EventHasNoSubscribers());
        }

        [TestMethod]
        public async Task TestMethodCall1()
        {
            await TestSendViaMethodCall();
        }

        [TestMethod]
        public async Task TestMethodCall2()
        {
            await TestSendViaMethodCall();
        }

        [TestMethod]
        public async Task TestMethodCall3()
        {
            await TestSendViaMethodCall();
        }

        [TestMethod]
        public async Task TestMethodCall4()
        {
            await TestSendViaMethodCall();
        }

        [TestMethod]
        public async Task TestMethodCall5()
        {
            await TestSendViaMethodCall();
        }

        [TestMethod]
        public async Task TestMethodCall6()
        {
            await TestSendViaMethodCall();
        }

        [TestMethod]
        public async Task TestMethodCall7()
        {
            await TestSendViaMethodCall();
        }

        [TestMethod]
        public async Task TestMethodCall8()
        {
            await TestSendViaMethodCall();
        }

        [TestMethod]
        public async Task TestMethod1()
        {
            await TestSendViaStream();
        }

        [TestMethod]
        public async Task TestMethod2()
        {
            await TestSendViaStream();
        }

        [TestMethod]
        public async Task TestMethod3()
        {
            await TestSendViaStream();
        }

        [TestMethod]
        public async Task TestMethod4()
        {
            await TestSendViaStream();
        }

        [TestMethod]
        public async Task TestMethod5()
        {
            await TestSendViaStream();
        }

        [TestMethod]
        public async Task TestMethod6()
        {
            await TestSendViaStream();
        }

        [TestMethod]
        public async Task TestMethod7()
        {
            await TestSendViaStream();
        }

        [TestMethod]
        public async Task TestMethod8()
        {
            await TestSendViaStream();
        }
    }
}
