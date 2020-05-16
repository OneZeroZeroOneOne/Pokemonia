using System;
using System.Collections.Generic;
using System.Text;
using Pokemonia.Dal.Maps.MapsObjects;

namespace Pokemonia.Dal.Maps
{
    public class Map
    {
        public string MapId { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public string PicUrl { get; set; }
        public List<MapDefaultObject> Objects { get; set; }


    }
}
