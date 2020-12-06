using System;
using System.Collections.Generic;
using System.Text;

namespace RickAndMorty.Models.Json
{
    public class CharacterRoot
    {
        public Info info { get; set; }
        public List<CharacterResult> results { get; set; }
    }
}
