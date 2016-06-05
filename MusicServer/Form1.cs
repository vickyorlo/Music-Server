using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadUserBase();
            loadMusicLibrary;
        }

        Dictionary<string, Genre> myMusicLibrary = new Dictionary<string, Genre>();
        private List<User> userBase = new List<User>();
        private List<User> usersIdentified = new List<User>();
        private Dictionary<string, User> userLookup = new Dictionary<string, User>();

        public void loadUserBase()
        {
            //todo: load userbase from a file, probably made by just serializing it whatever
            //also make more of it
            userBase.Add(new User("vic", new List<MusicListenedTo>()
            {
                {new MusicListenedTo(Genre.Doujin,40,"Shibayan Records") },
                {new MusicListenedTo(Genre.Rock,80,"One OK Rock") }
            }
            , 1));

            userBase.Add(new User("treo", new List<MusicListenedTo>()
            {
                {new MusicListenedTo(Genre.Metal,40,"whatever") },
                {new MusicListenedTo(Genre.EuroBeat,80,"A-One") }
            }
            , 0.75));

            userBase.Add(new User("rose", new List<MusicListenedTo>()
            {
                {new MusicListenedTo(Genre.Classical,40,"Mozarella") },
                {new MusicListenedTo(Genre.Soundtrack,80,"fuck movies") }
            }
            , 2));

            foreach (User user in userBase)
            {
                userLookup.Add(user.UsersMacAddress, user);
            }
        }

        public void loadMusicLibrary()
        {
            //probably load this from a file or some such
            myMusicLibrary = new Dictionary<string, Genre>()
           {
                {"Fall in the dark", Genre.Doujin },
                {"Into Free", Genre.Rock },
                {"NO SCARED", Genre.Rock },
                {"One-Way Highway", Genre.EuroBeat },
                {"Bad Apple!",Genre.Soundtrack },
                {"Necrofantasia",Genre.Rock },
                {"Plain Asia",Genre.Rock },
                {"Clockup Flowers",Genre.Rock },
                {"One minute and some seconds of silence",Genre.Classical },
                {"IRON ATTACK!",Genre.Metal }
            };
        }

        public void loadUnloadUser(string userMacAddress)
        {
            if (!usersIdentified.Contains(userLookup[userMacAddress]))
                usersIdentified.Add(userLookup[userMacAddress]);
            else
                usersIdentified.Remove(userLookup[userMacAddress]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadUnloadUser("vic");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadUnloadUser("treo");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadUnloadUser("rose");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PlaylistCreator playlistCreator = new PlaylistCreator(usersIdentified, myMusicLibrary);
            Playlist generatedPlaylist = playlistCreator.CreatePlaylist();
            playlistTextBox.Text = generatedPlaylist.ToString();
            Refresh();
        }
    }
}
