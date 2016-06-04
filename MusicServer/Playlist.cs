using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicServer
{
    class Playlist
    {
        public List<string> Songs = new List<string>();

        public Playlist()
        {

        }

        public Playlist(Dictionary<string,Genre> musicLibrary, List<Genre> genrePlaylistSkeleton)
        {
            Random random = new Random();
            foreach(Genre potentialSong in genrePlaylistSkeleton)
            {
                var matchingGenreSongs = from songWithMetadata in musicLibrary
                           where songWithMetadata.Value == potentialSong
                           select songWithMetadata.Key;
                Songs.Add(matchingGenreSongs.ElementAt(random.Next(0, matchingGenreSongs.Count())));
            }
        }

        public override string ToString()
        {
            string result = "";
            foreach (string song in Songs)
            {
                result += (song + "\n");
            }
            return result;
        }
    }
}
