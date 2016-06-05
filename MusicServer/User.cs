using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicServer
{
    class User
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


    }
}
