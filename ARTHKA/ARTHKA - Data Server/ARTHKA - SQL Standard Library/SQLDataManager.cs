using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SQLStandardLibrary
{
    public class SQLDataManager
    {
        private SqlConnection connection;

        public SQLDataManager(SqlConnection connection)
        {
            this.connection = connection;
        }

        public int VerifyTables(List<Table> tables)
        {
            do
            {
                if(connection.State == System.Data.ConnectionState.Open)
                {
                    try
                    {
                        foreach(Table table in tables)
                        {
                            SqlCommand cmd = new SqlCommand("select case when exists((select * from information_schema.tables where table_name = '" + table.Name + "')) then 1 else 0 end",connection);
                            if(Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                            {
                                CreateTable(table);
                            }
                        }
                        return 0;
                    }
                    catch(System.Data.SqlClient.SqlException sqle)
                    {
                        Console.WriteLine(sqle.Message);
                        return 1;
                    }
                }
            } while(connection.State == System.Data.ConnectionState.Connecting);
            Console.WriteLine(connection.State.ToString());
            return 2;
        }

        public void CreateTable(Table table)
        {
            try
            {
                SqlCommand command;
                string cmd = "CREATE TABLE " + table.Name + "(";
                foreach(KeyValuePair<string,string> col in table.Columns)
                {
                    if(cmd != "CREATE TABLE " + table.Name + "(")
                        cmd += ", ";
                    cmd += col.Key + " " + col.Value;
                }
                cmd += ");";
                Console.WriteLine(cmd);
                command = new SqlCommand(cmd,connection);
                command.ExecuteNonQuery();
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteTable()
        {
        }

        public void SendData()
        {
        }
    }
}