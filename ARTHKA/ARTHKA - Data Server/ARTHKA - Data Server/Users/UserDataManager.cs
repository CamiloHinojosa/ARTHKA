using SerializationStandardLibrary;
using System.Collections.Generic;

namespace ARTHKADataServer
{
    internal class UserDataManager : Serializer
    {
        private string directory = "App Data";
        private string filename = "usrdta.dat";
        private Dictionary<string,UserData> users;

        public Dictionary<string,UserData> Users { get { return users; } private set { } }

        public UserDataManager()
        {
        }

        public void LoadUsersData()
        {
            users = Load<Dictionary<string,UserData>>(GetCompletePath(directory,filename));
        }

        public void SaveUsersData(Dictionary<string,UserData> users)
        {
            Save(users,filename);
        }

        public void AddUser(UserData user)
        {
            users.Add(user.UserID,user);
        }

        public void DeleteUser(UserData user)
        {
            users.Remove(user.ID);
        }
    }
}