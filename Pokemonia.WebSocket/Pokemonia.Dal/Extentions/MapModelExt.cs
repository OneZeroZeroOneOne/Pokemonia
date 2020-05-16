using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
//using Pokemonia.Dal.Maps;
//using Pokemonia.Dal.Maps.MapsObjects;
using Pokemonia.Dal.Queryes;
using Npgsql;
using Dapper;
using System.Threading.Tasks;

namespace Pokemonia.Dal.Extentions
{
    public static class MapModelExt
    {
        /*async public static Task<Map> GetMap(this IDbConnection dbConnection, int mapId)
        {
            await dbConnection
                .QueryAsync<Map, MapDefaultObject, Map>(QueryMap.GetMap, (map, obj) => { map.Objects = obj; return map; });
        }*/
    }
}
