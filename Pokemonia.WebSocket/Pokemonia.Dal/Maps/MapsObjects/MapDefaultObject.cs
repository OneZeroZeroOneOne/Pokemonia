using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemonia.Dal.Maps.MapsObjects
{
    public class MapDefaultObject
    {
        public int ObjectId { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public string PicUrl { get; set; }
    }
}
