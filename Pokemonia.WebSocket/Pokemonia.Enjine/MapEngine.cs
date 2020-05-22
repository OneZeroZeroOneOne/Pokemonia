using System;
using System.Collections.Generic;
using System.Text;
using Pokemonia.Dal;
using Pokemonia.Dal.Models;
using Pokemonia.Dal.LogicModels;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;



namespace Pokemonia.MapEnjine
{
    public class MapEngine
    {
        //configs
        private double _maxMoveDistance = 200;
        //map
        private DBWorker _dbWorker;
        private Map _map;
        private BlockingCollection<InfoCurrentStateMap> _outInfoCurrentStateMapBlockingCollection;
        private Coordinates<User> spawnCoordinates;

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
            _outInfoCurrentStateMapBlockingCollection = outInfoBlockingCollection;
            _dbWorker = new DBWorker();
            User user1 = new User() { Id = 1, Name = "Vova" };
            _users.Add(1, user1);
            User user2 = new User() { Id = 2, Name = "Dima" };
            _usersCoordinates.Add(1, new Coordinates<User>() { Model = user1, Id = user1.Id, x});
            _users.Add(2, user2);
            _monsters.Add;
        }

        async private void Run(int mapId)
        {
            _map = await _dbWorker.GetMap(mapId);
            while (true)
            {
                try
                {
                    User user = _usersBlockingCollection.Take();
                    if (user != null)
                    {
                        _users.Add(user.Id, user);
                        Coordinates<User> userDefCoonrdinates = spawnCoordinates;
                        userDefCoonrdinates.Model = user;
                        _usersCoordinates.Add(user.Id, userDefCoonrdinates);
                    }
                    Coordinates<User> moveUserCoord = _usersMoveCoordinatesBlockingCollection.Take();
                    _usersMoveCoordinates.Add(moveUserCoord.Model.Id, moveUserCoord);


                }
                catch (InvalidOperationException) { }

            }
        }

        public void MoveMapObjects()
        {

        }
    }
}
