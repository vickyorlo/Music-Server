using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicServer
{
    public class User
    {
        private string usersMacAddress;
        public List<MusicListenedTo> UsersListenedMusic;
        private double hierarchyWeight;

        public double HierarchyWeight { get { return hierarchyWeight; } }
        public string UsersMacAddress { get { return usersMacAddress; } }


        public User(string macAddress, List<MusicListenedTo> listenedMusic, double weight)
        {
            usersMacAddress = macAddress;
            UsersListenedMusic = listenedMusic;
            hierarchyWeight = weight;
        }

        public User(string macAddress)
        {
            usersMacAddress = macAddress;
            UsersListenedMusic = new List<MusicListenedTo>();
            hierarchyWeight = 1;
        }

        public override bool Equals(Object obj)
        {
            User userObj = obj as User;
            if (userObj == null)
                return false;
            else
                return usersMacAddress.Equals(userObj.usersMacAddress);
        }

        public override int GetHashCode()
        {
            return usersMacAddress.GetHashCode();
        }

    }
}
