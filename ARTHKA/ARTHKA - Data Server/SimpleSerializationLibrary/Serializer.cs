using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializationStandardLibrary
{
    public class Serializer
    {
        private BinaryFormatter bf;

        public Serializer()
        {
        }

        protected string GetCompletePath(string directory,string filename)
        {
            return directory + @"\" + filename;
        }

        protected T Load<T>(string filename) where T : class
        {
            try
            {
                using(FileStream fs = new FileStream(filename,FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.ReadWrite))
                {
                    fs.Seek(0,SeekOrigin.Begin);
                    Stream sw = fs;
                    return (T)bf.Deserialize(sw);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        protected void Save<T>(T data,string filename)
        {
            try
            {
                using(FileStream fs = new FileStream(filename,FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.ReadWrite))
                {
                    fs.Seek(0,SeekOrigin.Begin);
                    Stream sw = fs;
                    bf.Serialize(sw,data);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}