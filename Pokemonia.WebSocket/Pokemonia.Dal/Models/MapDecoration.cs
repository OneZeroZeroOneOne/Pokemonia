using System;
using System.Collections.Generic;

namespace Pokemonia.Dal.Models
{
    public partial class MapDecoration
    {
        public long DecorationId { get; set; }
        public long MapId { get; set; }
        public long PositionX { get; set; }
        public long PositionY { get; set; }

        public virtual Decoration Decoration { get; set; }
        public virtual Map Map { get; set; }
    }
}
