using System;

namespace GrainProject
{
    public class MySuperObject
    {
        public MySuperObject(Guid guid)
        {
            MyObject = new MyObject(guid.ToString()); 
        }

        public MyObject MyObject { get; set; }

        public void Subscribe()
        {
            MyObject.MyEvent += SuperMethod;
        }

        private void SuperMethod(object sender, EventArgs e)
        {
            Console.WriteLine("Event called");
        }
    }
}