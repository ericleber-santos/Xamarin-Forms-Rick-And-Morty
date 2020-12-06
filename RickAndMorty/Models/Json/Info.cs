using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RickAndMorty.Models.Json
{
    public class Info
    {      
        public int count { get; set; }
      
        public int pages { get; set; }
       
        public string next { get; set; }
       
        public object prev { get; set; }
    }
}
