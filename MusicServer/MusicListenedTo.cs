using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicServer
{

    enum Genre
    {
        Pop,
        Rock,
        Metal,
        Doujin,
        Indie,
        EasyListening,
        BossaNova,
        EuroBeat,
        Classical,
        Rap,
        Soundtrack
    }

    class MusicListenedTo
    {
        private Genre ListenedGenre;
        private int ListenedTimeInMinutes;
        private string ListenedArtist;

        public Genre listenedGenre { get { return ListenedGenre; } }
        public int listenedTimeInMinutes { get { return ListenedTimeInMinutes; } }
        public string listenedArtist { get { return ListenedArtist;  } }

        public MusicListenedTo(Genre listenedGenre, int listenedTimeInMinutes, string listenedArtist)
        {
            ListenedGenre = listenedGenre;
            ListenedTimeInMinutes = listenedTimeInMinutes;
            ListenedArtist = listenedArtist;
        }

        public int GetWeight()
        {
            return listenedTimeInMinutes;
        }

    }
}
