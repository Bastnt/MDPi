using MDPi.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPi.Core.Services.ServerInteractionServices
{
    public interface IServerCommunicationService
    {
        Task<ServerQueryResult> FetchPersonalServerInformation();
        Task<ServerQueryResult> FetchAllServerInformation();
        Task<ServerQuerySubmit> TrackNewTorrents(IList<NewAnime> animeList);
    }
}
