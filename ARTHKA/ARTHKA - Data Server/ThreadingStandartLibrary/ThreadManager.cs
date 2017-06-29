using System.Collections.Generic;
using System.Threading;

namespace ThreadingStandardLibrary
{
    public class ThreadManager
    {
        public Dictionary<string,Thread> Threads { get; private set; }
        public Dictionary<string,ThreadableClass<string>> Objects { get; private set; }

        public ThreadManager()
        {
            Threads = new Dictionary<string,Thread>();
            Objects = new Dictionary<string,ThreadableClass<string>>();
        }

        public void StartThread(string name,ThreadableClass<string> threadableobject)
        {
            Threads.Add(threadableobject.ID,new Thread(threadableobject.Start));
            Objects.Add(threadableobject.ID,threadableobject);
            Threads[threadableobject.ID].Start();
            Threads[threadableobject.ID].Name = name;
            Threads[threadableobject.ID].IsBackground = true;
        }
    }
}