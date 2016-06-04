using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicServer
{
    class User
    {
        private string UsersMacAdress;
        public List<MusicListenedTo> UsersListenedMusic;
        private double hierarchyWeight;

        public double HierarchyWeight { get { return hierarchyWeight; } }

        public User(string macAdress, List<MusicListenedTo> listenedMusic, double weight)
        {
            UsersMacAdress = macAdress;
            UsersListenedMusic = listenedMusic;
            hierarchyWeight = weight;
        }


    }
}
