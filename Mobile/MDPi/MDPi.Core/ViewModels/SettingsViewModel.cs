using Cirrious.MvvmCross.ViewModels;
using MDPi.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPi.Core.ViewModels
{
    public class SettingsViewModel : MvxViewModel
    {
        public SettingsViewModel()
        {
        }

        public string ServerIPAddress
        {
            get { return Settings.ServerIPAddress; }
            set { Settings.ServerIPAddress = value; RaisePropertyChanged(() => ServerIPAddress); }
        }

        public void Init(string objectId)
        {
        }
    }
}
