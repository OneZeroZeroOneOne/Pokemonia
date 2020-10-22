using Pokemonia.Dal.LogicModels;
using System;
using System.Collections.Generic;
using System.Text;
using Pokemonia.Dal.Models;

namespace Pokemonia.MapEngine
{
    static public class CalculateCoordinates
    {
        public static void CalculateCoef(Coordinates<User> moveCoordinatesUserModel, Coordinates<User> coordinatesUserModel)
        {
            double lengthX = moveCoordinatesUserModel.x - coordinatesUserModel.x;
            double lengthY = moveCoordinatesUserModel.y - coordinatesUserModel.y;
            moveCoordinatesUserModel.Gip = Math.Sqrt(lengthX * lengthX + lengthY * lengthY);
            moveCoordinatesUserModel.CoefX = Math.Abs(lengthX) / moveCoordinatesUserModel.Gip;
            moveCoordinatesUserModel.CoefY = Math.Abs(lengthY) / moveCoordinatesUserModel.Gip;
            moveCoordinatesUserModel.SignX = Math.Sign(lengthX);
            moveCoordinatesUserModel.SignY = Math.Sign(lengthY);
        }
    }
}
