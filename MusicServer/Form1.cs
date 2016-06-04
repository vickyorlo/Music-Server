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
        }

        Dictionary<string, Genre> myMusicLibrary = new Dictionary<string, Genre>()
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
        private List<User> usersContainer = new List<User>()
        {
            { new User("vic",new List<MusicListenedTo>()
            {
                {new MusicListenedTo(Genre.Doujin,40,"Shibayan Records") },
                {new MusicListenedTo(Genre.Rock,80,"One OK Rock") }
            }
            ,1) },
            { new User("rose",new List<MusicListenedTo>()
            {
                {new MusicListenedTo(Genre.Metal,100,"whatever") }
            }
            ,1.5) },
            { new User("treo",new List<MusicListenedTo>()
            {
                {new MusicListenedTo(Genre.Classical,120,"mozarts farts") }
            }
            ,0.7) }
        };


        private void button1_Click(object sender, EventArgs e)
        {
            PlaylistCreator playlistCreator = new PlaylistCreator(usersContainer, myMusicLibrary);
            Playlist generatedPlaylist = playlistCreator.CreatePlaylist();
            MessageBox.Show(generatedPlaylist.ToString());
        }
    }
}
