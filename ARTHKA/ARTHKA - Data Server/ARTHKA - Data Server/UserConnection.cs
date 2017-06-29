using SQLStandardLibrary;
using System.IO.Pipes;
using ThreadingStandardLibrary;

namespace ARTHKADataServer
{
    internal class UserConnection : ThreadableClass<string>
    {
        private NamedPipeClientStream npcs;
        private Connection connection;
        private SQLDataManager sqldm;

        public UserConnection(string id,string pipename,Connection connection) : base(id)
        {
            npcs = new NamedPipeClientStream(pipename);
            this.connection = connection;
            sqldm = new SQLDataManager(this.connection.ActiveConnection);
        }

        public override void Start()
        {
            while(!close)
            {
                while(commands.Count > 0)
                {
                    sqldm.
                }
                work.WaitOne();
            }
        }
    }
}