using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Pokemonia.Dal.LogicModels
{
    public class Coordinates<T>
    {
        public int Id { get; set; }
        public T Model { get; set; }
        public double x { get; set; }
        public double y { get; set; }
    }
}
