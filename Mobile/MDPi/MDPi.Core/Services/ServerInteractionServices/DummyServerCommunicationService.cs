﻿using MDPi.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPi.Core.Services.ServerInteractionServices
{
    class DummyServerCommunicationService : IServerCommunicationService
    {
        public DummyServerCommunicationService()
        {
        }

        public async Task<ServerQuery> FetchServerInformation()
        {
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<ServerQuery>(MDPi.Core.Properties.Resources.ServerQueryTestResult));
        }
    }
}