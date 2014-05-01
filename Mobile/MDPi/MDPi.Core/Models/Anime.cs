using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPi.Core.Models
{
    public class Anime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("hit_regex")]
        public string HitRegex { get; set; }
        [JsonProperty("dl_regex")]
        public string DownloadRegex { get; set; }
        public int Count { get; set; }
    }
}
