using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicServer
{
    class PlaylistCreator
    {

        private List<User> IdentifiedUsers;
        private Dictionary<string,Genre> MusicLibrary;

        public PlaylistCreator(List<User> identifiedUsers, Dictionary<string,Genre> library)
        {
            IdentifiedUsers = identifiedUsers;
            MusicLibrary = library;
        }

        public Playlist CreatePlaylist()
        {
            Dictionary<Genre, Double> GenresWeights = new Dictionary<Genre, Double>();

            foreach (User user in IdentifiedUsers)
            {
                foreach (MusicListenedTo listened in user.UsersListenedMusic)
                {
                    if (GenresWeights.ContainsKey(listened.listenedGenre))
                        GenresWeights[listened.listenedGenre] += (listened.GetWeight() * user.HierarchyWeight);
                    else GenresWeights.Add(listened.listenedGenre, listened.GetWeight() * user.HierarchyWeight);
                }
            }
            Playlist result = new Playlist();
            return new Playlist(MusicLibrary, GenerateWeightedRandomGenreList(GenresWeights,10));
        }

        private List<Genre> GenerateWeightedRandomGenreList(Dictionary<Genre, double> genresWeights,int amountOfSongsInThePlaylist)
        {
            Random random = new Random();
            double itemTotalWeight = genresWeights.Sum(wgt => wgt.Value);
            List<Genre> genreOnlyPlaylistSkeleton = new List<Genre>();

            for (int i=0;i<amountOfSongsInThePlaylist;i++)
            {
                double itemWeightIndex = (random.NextDouble()) * itemTotalWeight;

                double runningTotalBeginning = 0;
                double runningTotalEnd = 0;

                foreach (var item in genresWeights)
                {
                    runningTotalBeginning = runningTotalEnd;
                    runningTotalEnd += item.Value;
                    if (itemWeightIndex >= runningTotalBeginning && itemWeightIndex <= runningTotalEnd)
                            genreOnlyPlaylistSkeleton.Add(item.Key);
                    }
            }

            return genreOnlyPlaylistSkeleton;
        }
    }
}
