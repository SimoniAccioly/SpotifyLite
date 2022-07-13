using Microsoft.EntityFrameworkCore;
using SpotifyLite.Domain.Account;
using SpotifyLite.Domain.Account.Repository;
using SpotifyLite.Domain.Album;
using SpotifyLite.Domain.Album.Repository;
using SpotifyLite.Repository.Context;
using SpotifyLite.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLite.Repository.Repository
{
    public class PlaylistRepository : Repository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(SpotifyContext context) : base(context)
        {

        }


        public async Task<IEnumerable<Playlist>> ObterTodasPlaylists()
        {
            return await this.Query.Include(x => x.Musicas).ToListAsync();
        }

    }
}
