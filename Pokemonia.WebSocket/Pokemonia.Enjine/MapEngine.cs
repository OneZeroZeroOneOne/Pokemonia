using System;
using System.Collections.Generic;
using System.Text;
using Pokemonia.Bll;
using Pokemonia.Dal;
using Pokemonia.Dal.Models;
using Pokemonia.Dal.Maps;
using Pokemonia.Dal.LogicModels;



namespace Pokemonia.MapEnjine
{
    public class MapEngine
    {
        private DBWorker _dbWorker;
        private Map _map;
        private Dictionary<int, User> _users;
        private Dictionary<int, Coordinates> _usersCoordinates;
        private List<Monster> _monsters;
        public MapEngine(int mapId)
        {
            _dbWorker = new DBWorker();
        }
    }
}
