using System.Collections.Generic;

namespace SQLStandardLibrary
{
    public class Table
    {
        private string name;
        private string key;
        private Dictionary<string,string> columns;

        public string Key { get { return key; } set { key = value; } }
        public string Name { get { return name; } set { name = value; } }
        public Dictionary<string,string> Columns { get { return columns; } set { columns = value; } }

        public Table(string key,string name,Dictionary<string,string> columns)
        {
            this.key = key;
            this.name = name;
            this.columns = columns;
        }
    }
}