using System;

namespace GrainProject
{
    public class MySuperObject
    {
        public MySuperObject(Guid guid)
        {
            MyObject = new MyObject(); 
        }

        public MyObject MyObject { get; set; }
    }
}