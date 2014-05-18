using Cirrious.MvvmCross.ViewModels;
using MDPi.Core.Models;
using MDPi.Core.Services.ServerInteractionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPi.Core.ViewModels
{
    public class AddTorrentViewModel : MvxViewModel
    {
        private IServerCommunicationService communicationService;
        private Anime animeToBeAdded;
        public AddTorrentViewModel(IServerCommunicationService communicationService)
        {
            this.communicationService = communicationService;
            this.animeToBeAdded = new Anime();
        }

        public string Name
        {
            get { return animeToBeAdded.Name; }
            set { animeToBeAdded.Name = value; RaisePropertyChanged(() => Name); }
        }

        public void SaveAndGenerate(IList<NewAnime> newAnimeList)
        {
            communicationService.TrackNewTorrents(newAnimeList);
        }
    }
}
