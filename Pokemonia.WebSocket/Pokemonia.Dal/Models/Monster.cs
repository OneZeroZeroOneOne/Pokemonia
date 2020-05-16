using System;
using System.Collections.Generic;
using System.Text;
using Pokemonia.Dal.Habit.Spells;
using Pokemonia.Dal.Habit;

namespace Pokemonia.Dal.Models
{
    public class Monster
    {
        public double Hp;
        public Attack Atk;
        public Deffence Def;
        public List<Spell> Spells;
        public double SecontTypeElement;
        public double FirstTypeElement;

    }
}
