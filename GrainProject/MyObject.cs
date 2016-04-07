using System;

namespace GrainProject
{
    [Serializable]
    public class MyObject
    {
        [NonSerialized]
        public string MyString;

        public bool StringNull => MyString == null;
    }
}