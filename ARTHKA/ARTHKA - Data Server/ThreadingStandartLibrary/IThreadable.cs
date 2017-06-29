namespace ThreadingStandardLibrary
{
    internal interface IThreadable<T>
    {
        void AddCommand(T command);

        void Start();

        void Stop();
    }
}