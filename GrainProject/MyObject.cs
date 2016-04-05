using System;

namespace GrainProject
{
    [Serializable]
    public class MyObject
    {
        [field: NonSerialized]
        public event EventHandler MyEvent;

        public bool HasNoSubscribers()
        {
            return MyEvent == null;
        }
    }
}