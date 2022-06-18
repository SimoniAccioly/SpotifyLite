using SpotifyLite.Repository.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyLite.Domain.Account;
using SpotifyLite.Domain.Account.Repository;
using SpotifyLite.Repository.Context;

namespace SpotifyLite.Repository.Repository
{
    public class AccountRepository : Repository<Usuario>, IUsuarioRepository
    {
        public AccountRepository(SpotifyContext context) : base(context)
        {
        }
    }
}
