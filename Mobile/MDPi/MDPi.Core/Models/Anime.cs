using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDPi.Core.Models
{
    public class Anime
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private string HitRegex { get; set; }
        private string DownloadRegex { get; set; }
        private int Count { get; set; }
    }
}
