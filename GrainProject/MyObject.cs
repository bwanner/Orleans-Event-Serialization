using System;

namespace GrainProject
{
    [Serializable]
    public class MyObject
    {
        [field: NonSerialized]
        public event EventHandler MyEvent;

        [field: NonSerialized]
        public string MyString;

        public bool HasNoSubscribersProperty => MyEvent == null;

        public bool HasNoSubscribers()
        {
            return MyEvent == null;
        }

    }
}