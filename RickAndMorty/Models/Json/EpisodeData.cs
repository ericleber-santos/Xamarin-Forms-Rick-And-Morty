using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace RickAndMorty.Models.Json
{
    public class EpisodeData
    {       
        public int id { get; set; }
        
        public string name { get; set; }
       
        public string air_date { get; set; }
        
        public string episode { get; set; }
       
        public List<string> characters { get; set; }
      
        public string url { get; set; }
        
        public DateTime created { get; set; }
    }
}
