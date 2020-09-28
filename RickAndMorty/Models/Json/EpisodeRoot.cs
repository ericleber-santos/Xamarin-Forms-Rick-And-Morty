using System;
using System.Collections.Generic;
using System.Text;

namespace RickAndMorty.Models.Json
{
    public class EpisodeRoot
    {
        public EpisodeInfo info { get; set; }
        public List<EpisodeData> results { get; set; }
    }
}
