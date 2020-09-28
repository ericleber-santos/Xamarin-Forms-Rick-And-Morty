using System;
using System.Collections.Generic;
using System.Text;

namespace RickAndMorty.Models.Json
{
    public class EpisodeInfo
    {
        public int count { get; set; }
        public int pages { get; set; }
        public string next { get; set; }
        public object prev { get; set; }
    }
}
