using Cirrious.MvvmCross.ViewModels;
using MDPi.Core.Models;
using MDPi.Core.Services.ServerInteractionServices;
using System.Collections.Generic;

namespace MDPi.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private readonly TorrentsViewModel torrentsViewModel;
        private readonly BrowseViewModel browseViewModel;

        public FirstViewModel(IServerCommunicationService service)
        {
            torrentsViewModel = new TorrentsViewModel(service);
            browseViewModel = new BrowseViewModel(service);
        }

        public TorrentsViewModel TorrentsViewModel
        {
            get { return torrentsViewModel; }
        }
        public BrowseViewModel BrowseViewModel
        {
            get { return browseViewModel; }
        }
    }
}
