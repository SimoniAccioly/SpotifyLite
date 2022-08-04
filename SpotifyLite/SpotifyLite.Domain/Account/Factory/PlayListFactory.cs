using SpotifyLite.Domain.Album;

namespace SpotifyLite.Domain.Account.Factory
{
    public static class PlaylistFactory
    {
        public static Playlist Create(string nome, Musica musica)
        {
            if (musica == null)
                throw new ArgumentNullException("Para criar uma playlist, o album deve ter no mínimo uma música");
            return new Playlist()
            {
                Musicas = new List<Musica>() { musica } 
            };
        }

        public static Playlist Create (string nome, IEnumerable<Musica> musicas)
        {
            if (!musicas.Any())
                throw new ArgumentException("Para criar uma playlist, o album deve ter no mínimo uma música");

            return new Playlist()
            {
                Musicas = musicas.ToList()
            };
        }
    }
}
