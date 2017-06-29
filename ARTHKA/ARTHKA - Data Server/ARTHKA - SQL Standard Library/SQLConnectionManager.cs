using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SQLStandardLibrary
{
    public class SQLConnectionManager
    {
        private Dictionary<string,SqlConnection> connections;
        private string serverName;

        public Dictionary<string,SqlConnection> Connections { get => connections; private set { } }

        public SQLConnectionManager(string servername)
        {
            connections = new Dictionary<string,SqlConnection>();
            serverName = servername;
        }

        private string ConnectionString(string dbname,string id,string password)
        {
            return "Data Source=" + serverName + @"\\" + dbname + ";" +
                "Persist Security Info=True;" +
                "User ID = " + id + ";" +
                "Password=" + password;
        }

        public void Connect(string dbname,string id,string password)
        {
            Console.WriteLine(ConnectionString(dbname,id,password));;
            connections.Add(id,new SqlConnection(ConnectionString(dbname,id,password)));
            Console.WriteLine("Connection Added.\nStarting Connection...");
            StartConnection(id);
        }

        private void StartConnection(string id)
        {
            try
            {
                connections[id].Open();
                Console.WriteLine("Connection Openned.");
            }
            catch(Exception e)
            {
                Console.WriteLine("Connection Failed to open.");
                Console.WriteLine(e.ToString());
            }
        }
    }
}