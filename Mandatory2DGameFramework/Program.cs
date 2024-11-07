using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework
{
    public class Program
    {
        public static void Main()
        {
            World world = new World(10, 10);

            AttackItem sword = new AttackItem { Name = "Sword", Hit = 15, Range = 1};
            DefenceItem shield = new DefenceItem { Name = "Shield", ReduceHitPoint = 5 };

            Creature creature1 = new Creature("Warrior", 2, 3, 100, sword, null);
            Creature creature2 = new Creature("Warrior", 2, 3, 100, null, shield);
            Creature creature3 = new Creature("Warrior", 2, 3, 100, sword, shield);

            world.AddCreature(creature1);
            world.AddCreature(creature2);
            world.AddCreature(creature3);

            creature1.Hit(creature2);
            creature2.Hit(creature3);
            creature3.Hit(creature1);

            Console.WriteLine($"{creature2.Name}'s remaining HP: {creature2.HitPoints}");
        }
    }
}
