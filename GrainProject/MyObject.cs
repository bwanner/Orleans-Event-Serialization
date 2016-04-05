using System;

namespace GrainProject
{
    [Serializable]
    public class MyObject
    {
        public string Name { get; private set; }

        [field: NonSerialized]
        public event EventHandler MyEvent;

        public MyObject(string name)
        {
            Name = name;
        }

        public bool HasNoSubscribers()
        {
            return MyEvent == null;
        }
    }
}