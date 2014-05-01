using Cirrious.MvvmCross.ViewModels;
using MDPi.Core.Models;
using MDPi.Core.Services.ServerInteractionServices;
using System.Collections.Generic;

namespace MDPi.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        private IServerCommunicationService communicationService;

        public FirstViewModel(IServerCommunicationService service)
        {
            this.communicationService = service;
            UpdateData();
        }

        private bool isUpdating = true;
        public bool IsUpdating
        {
            get { return isUpdating; }
            set { isUpdating = value; RaisePropertyChanged(() => IsUpdating); }
        }

        private IList<Anime> torrents;
        public IList<Anime> Torrents
        {
            get { return torrents; }
            set { torrents = value; RaisePropertyChanged(() => Torrents); }
        }

        private async void UpdateData()
        {
            IsUpdating = true;
            var result = await communicationService.FetchServerInformation();
            Torrents = result.Torrents;
            IsUpdating = false;
        }
    }
}
