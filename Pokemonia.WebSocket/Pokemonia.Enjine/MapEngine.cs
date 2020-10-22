using System;
using System.Collections.Generic;
using System.Text;
using Pokemonia.Dal;
using Pokemonia.Dal.Models;
using Pokemonia.Dal.LogicModels;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Pokemonia.MapEngine;

namespace Pokemonia.MapEnjine
{
    public class MapEngine
    {
        //configs
        private double _maxMoveDistance = 50;
        //map
        private DBWorker _dbWorker;
        private Map _map;
        private BlockingCollection<InfoCurrentStateMap> _outInfoCurrentStateMap;
        private Coordinates<Map> spawnCoordinates = new Coordinates<Map>() {x = 500, y = 500 };

        //user
        private Dictionary<long, User> _users = new Dictionary<long, User>();
        private Dictionary<long, Coordinates<User>> _usersCoordinates = new Dictionary<long, Coordinates<User>>();
        private Dictionary<long, Coordinates<User>> _usersMoveCoordinates = new Dictionary<long, Coordinates<User>>();
        private BlockingCollection<User> _usersBlockingCollection;
        private BlockingCollection<Coordinates<User>> _usersMoveCoordinatesBlockingCollection;

        //monsters
        private Dictionary<Guid, TemporaryObjectPokemon> _monsters = new Dictionary<Guid, TemporaryObjectPokemon>();
        private Dictionary<Guid, Coordinates<TemporaryObjectPokemon>> _monstersCoordinates = new Dictionary<Guid, Coordinates<TemporaryObjectPokemon>>();
        private Dictionary<Guid, Coordinates<TemporaryObjectPokemon>> _monstersMoveCoordinates = new Dictionary<Guid, Coordinates<TemporaryObjectPokemon>>();
        public MapEngine(BlockingCollection<User> usersBlockingCollection
                                                        , BlockingCollection<Coordinates<User>> usersMoveCoordinatesBlockingCollection
                                                        , BlockingCollection<InfoCurrentStateMap> outInfoBlockingCollection)
        {
            _usersBlockingCollection = usersBlockingCollection;
            _usersMoveCoordinatesBlockingCollection = usersMoveCoordinatesBlockingCollection;
            _outInfoCurrentStateMap = outInfoBlockingCollection;
            _dbWorker = new DBWorker();
            User user1 = new User() { Id = 1, Name = "Vova" };
            _users.Add(user1.Id, user1);
            _usersCoordinates.Add(user1.Id, new Coordinates<User>() { Model = user1, x = spawnCoordinates.x, y = spawnCoordinates.y});
            User user2 = new User() { Id = 2, Name = "Dima" };
            _users.Add(user2.Id, user2);
            _usersCoordinates.Add(user2.Id, new Coordinates<User>() { Model = user2, x = spawnCoordinates.x, y = spawnCoordinates.y});
            TemporaryObjectPokemon monsters1 = new TemporaryObjectPokemon() { Id = Guid.NewGuid(), Name = "Pig" };
            _monsters.Add(monsters1.Id, monsters1);
            _monstersCoordinates.Add(monsters1.Id, new Coordinates<TemporaryObjectPokemon>() { Model = monsters1, x = spawnCoordinates.x, y = spawnCoordinates.y });
            TemporaryObjectPokemon monsters2 = new TemporaryObjectPokemon() { Id = Guid.NewGuid(), Name = "Pig" };
            _monsters.Add(monsters2.Id, monsters2);
            _monstersCoordinates.Add(monsters2.Id, new Coordinates<TemporaryObjectPokemon>() { Model = monsters2, x = spawnCoordinates.x, y = spawnCoordinates.y });
        }

        async private void Run(int mapId)
        {
            _map = await _dbWorker.GetMap(mapId);
            while (true)
            {
                SpawnUsers();
                GetMoves();


            }
        }

        public void GetMoves()
        {
            try
            {
                Coordinates<User>[] moveCurrentUserCoords = _usersMoveCoordinatesBlockingCollection.ToArray();
                foreach (Coordinates<User> moveCurrentUserCoord in moveCurrentUserCoords)
                {
                    if (moveCurrentUserCoord != null)
                    {
                        _usersCoordinates.TryGetValue(moveCurrentUserCoord.Model.Id, out var currentUserCoor);
                        CalculateCoordinates.CalculateCoef(moveCurrentUserCoord, currentUserCoor);
                        _usersMoveCoordinates.Add(moveCurrentUserCoord.Model.Id, moveCurrentUserCoord);

                    }
                }
            }
            catch (InvalidOperationException) { }

        }

        public void SpawnUsers()
        {
            try
            {
                User[] users = _usersBlockingCollection.ToArray();
                foreach (User user in users)
                {
                    if (user != null)
                    {
                        _users.Add(user.Id, user);
                        _usersCoordinates.Add(user.Id, new Coordinates<User>() { Model = user, x = spawnCoordinates.x, y = spawnCoordinates.y });
                    }
                }
            }
            catch (InvalidOperationException) { }
        }

        public void MoveMapObjects()
        {
            foreach(KeyValuePair<long, Coordinates<User>> moveCoord in  _usersMoveCoordinates)
            {
                if(_users.TryGetValue(moveCoord.Value.Model.Id, out User user) & _usersCoordinates.TryGetValue(moveCoord.Value.Model.Id, out Coordinates<User> userCoord))
                {
                    if(userCoord.x + _maxMoveDistance * moveCoord.Value.)
                }
            }
        }
    }
}
