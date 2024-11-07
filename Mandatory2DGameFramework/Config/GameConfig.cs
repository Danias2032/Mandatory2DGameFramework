using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Config
{
    public class GameConfig
    {
        public int WorldMaxX { get; set;}
        public int WorldMaxY { get; set;}
        public List<AttackItemConfig> AttackItems { get; set;}
        public List<DefenceItemConfig> DefenceItems { get; set;}
        public List<CreatureConfig> Creatures { get; set;}
        public GameConfig()
        {
            AttackItems = new List<AttackItemConfig>();
            DefenceItems = new List<DefenceItemConfig>();
            Creatures = new List<CreatureConfig>();
        }
    }
    public class AttackItemConfig
    {
        public string Name { get; set; }
        public int Hit { get; set; }
        public int Range { get; set; }
        public bool Lootable { get; set; }
        public bool Removeable { get; set; }
    }

    public class DefenceItemConfig 
    {
        public string Name { get; set; }
        public int ReduceHitPoints { get; set; }
        public bool Lootable { get; set; }
        public bool Removeable { get; set; }
    }

    public class CreatureConfig
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string? InitialAttackItem { get; set; }
        public string? InitialDefenceItem { get; set; }
    }

}
