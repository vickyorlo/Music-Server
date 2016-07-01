using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MusicServer
{
    public class MusicPlayer
    {
        public readonly string PlayerIP;
        private List<User> UsersIdentified = new List<User>();
        private List<User> UserBase;
        List<Tuple<string, string, Genre>> MusicLibrary;
        private Dictionary<string, User> userLookup = new Dictionary<string, User>();

        public MusicPlayer()
        {
            PlayerIP = "0";
            UserBase = new List<User>();
            MusicLibrary = new List<Tuple<string, string, Genre>>();
        }
        public MusicPlayer(string playerIP, List<User> userBase, List<Tuple<string, string, Genre>> musicLibrary)
        {
            PlayerIP = playerIP;
            UserBase = userBase;
            MusicLibrary = musicLibrary;
            foreach (User user in userBase)
            {
                userLookup.Add(user.UsersMacAddress, user);
            }
        }

        public void loadUnloadUser(string macAddress)
        {
            if (UserBase.Contains(new User(macAddress)))
            {
                if (!UsersIdentified.Contains(userLookup[macAddress]))
                    UsersIdentified.Add(userLookup[macAddress]);
                else
                    UsersIdentified.Remove(userLookup[macAddress]);
            }

        }

        public string playMusicForCurrentUsers()
        {
            PlaylistCreator playlistCreator = new PlaylistCreator(UsersIdentified, MusicLibrary);
            Playlist generatedPlaylist = playlistCreator.CreatePlaylist();
            sendDataToPlayer(generatedPlaylist);
            return generatedPlaylist.ToString();
        }

        private void sendDataToPlayer(Playlist playlist)
        {

            Form1.clearPlaylist();
            
            foreach (Tuple<string, string> song in playlist.Songs)
            {
                Form1.addToPlaylist(song.Item2, song.Item1);
            }

            Form1.playMusic();

        }


    }
}
