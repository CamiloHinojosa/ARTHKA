using SQLStandardLibrary;
using System.Collections.Generic;

namespace ARTHKADataServer.SQLData
{
    internal static class PredefinedTables
    {
        public static List<Table> PredefindedTablesList = new List<Table>
        {
            new Table("00S","Stations",new Dictionary<string, string>() {
                { "Code","varchar(6) PRIMARY KEY" },
                { "Name","varchar(100) NOT NULL" },
                { "Description","varchar(100) NOT NULL" },
                { "IP Address","varchar(100) NOT NULL" }
            }),
            new Table("00C","Controllers",new Dictionary<string, string>() {
                { "Code","varchar(6) PRIMARY KEY" },
                { "Name","varchar(100) NOT NULL" },
                { "Description","varchar(100)" },
                { "UID","varchar(100) NOT NULL" },
                { "Baudrate","varchar(100)" }
            }),
            new Table("00V","Devices",new Dictionary<string, string>(){
                { "Code","varchar(6) PRIMARY KEY" },
                { "Name","varchar(100) NOT NULL" },
                { "Description","varchar(100) NOT NULL" },
                { "Type","varchar(100) NOT NULL" },
                { "Family","varchar(100) NOT NULL" }
            }),
            new Table("00M","Modules",new Dictionary<string, string>() {
                { "Code","varchar(6) PRIMARY KEY" },
                { "Name","varchar(100) NOT NULL" },
                { "Description","varchar(100) NOT NULL" },
                { "Type","varchar(100) NOT NULL" }
            }),
            new Table("00A","Area",new Dictionary<string, string>() {
                { "Code","varchar(6) PRIMARY KEY" },
                { "Name","varchar(100) NOT NULL" },
                { "Description","varchar(100) NOT NULL" },
                { "Type","varchar(100) NOT NULL" }
            }),
            new Table("00E","Events",new Dictionary<string, string>() {
                { "Code","varchar(6) PRIMARY KEY" },
                { "Name","varchar(100) NOT NULL" },
                { "Description","varchar(100) NOT NULL" },
                { "Type","varchar(100) NOT NULL" }
            })
        };
    }
}