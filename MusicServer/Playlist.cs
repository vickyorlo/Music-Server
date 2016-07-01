using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicServer
{
    class Playlist
    {
        public List<Tuple<string,string>> Songs = new List<Tuple<string,string>>();

        public Playlist()
        {

        }

        public Playlist(List<Tuple<string, string, Genre>> musicLibrary, List<Genre> genrePlaylistSkeleton)
        {
            Random random = new Random();
            foreach(Genre potentialSong in genrePlaylistSkeleton)
            {
                var matchingGenreSongs = from songWithMetadata in musicLibrary
                           where songWithMetadata.Item3 == potentialSong
                           select new Tuple<string,string>(songWithMetadata.Item1,songWithMetadata.Item2);
                Songs.Add(matchingGenreSongs.ElementAt(random.Next(0, matchingGenreSongs.Count())));
            }
        }

        public override string ToString()
        {
            string result = "";
            foreach (Tuple<string,string> song in Songs)
            {
                result += (song.Item1 + " by " + song.Item2 + Environment.NewLine);
            }
            return result;
        }
    }
}
