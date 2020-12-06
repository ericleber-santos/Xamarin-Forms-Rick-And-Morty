using System;
using System.Collections.Generic;

namespace RickAndMorty.Models.Json
{
    public class CharacterResult
    {
        public int id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public CharacterOrigin origin { get; set; }
        public CharacterLocation location { get; set; }
        public string image { get; set; }
        public List<string> episode { get; set; }
        public string url { get; set; }
        public DateTime created { get; set; }
    }
}
