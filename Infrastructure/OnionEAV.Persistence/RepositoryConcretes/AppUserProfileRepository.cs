using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
using OnionEAV.Persistence.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionEAV.Persistence.RepositoryConcretes
{
    public class AppUserProfileRepository(MyContext context) : BaseRepository<AppUserProfile>(context),IAppUserProfileRepository
    {
    }
}
