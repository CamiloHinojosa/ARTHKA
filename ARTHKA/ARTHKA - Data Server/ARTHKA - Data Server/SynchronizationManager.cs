using SQLStandardLibrary;
using System.Collections.Generic;
using ThreadingStandardLibrary;

namespace ARTHKADataServer
{
    internal class SynchronizationManager
    {
        private UserDataManager usdm;
        private SQLConnectionManager sqlcm;
        private ThreadManager tm;

        public SynchronizationManager(string servername)
        {
            usdm = new UserDataManager();
            sqlcm = new SQLConnectionManager(servername);
            tm = new ThreadManager();
        }

        private void RetrieveUserData()//Retrieve Data from .dat file
        {
            usdm.LoadUsersData();
        }

        private void StartSQLConnections()//Implement encryption and decryption for each UsedData property
        {
            foreach(UserData ud in usdm.Users.Values)
                sqlcm.Connect(ud.DBName,ud.UserID,ud.Pasword);
        }

        private void StartSQLUsersProcesses()
        {
            foreach(KeyValuePair<string,Connection> con in sqlcm.Connections)
            {
                tm.StartThread(con.Key,)
            }
        }
    }
}