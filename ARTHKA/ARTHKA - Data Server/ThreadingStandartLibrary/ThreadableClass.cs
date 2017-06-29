using System.Collections.Generic;
using System.Threading;

namespace ThreadingStandardLibrary
{
    public abstract class ThreadableClass<T> : IThreadable<T>
    {
        protected List<T> commands;
        protected bool close;
        protected ManualResetEvent work;

        public string ID { get; private set; }

        public ThreadableClass(string id)
        {
            commands = new List<T>();
            close = false;
            ID = id;
            work = new ManualResetEvent(true);
        }

        public void AddCommand(T command)
        {
            commands.Add(command);
        }

        public virtual void Start()
        {
        }

        public virtual void Stop()
        {
            close = true;
        }
    }
}