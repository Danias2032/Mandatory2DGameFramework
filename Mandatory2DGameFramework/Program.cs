using Mandatory2DGameFramework.Config;
using Mandatory2DGameFramework.Logger;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Cretures;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework
{
    public class Program
    {
        public static void Main()
        {
            MyLogger logger = MyLogger.Instance;
            logger.AddListener(new ConsoleTraceListener());
            logger.AddListener(new TextWriterTraceListener());

            logger.LogInfo("Game starting...");

            var config = ConfigLoader.LoadConfig("config.xml");
            World world = new World(config.WorldMaxX, config.WorldMaxY);

            AttackItem sword = new AttackItem
            {
                Name = "Sword",
                Hit = 15,
                Range = 1,
                Lootable = true,
                Removeable = true
            };
            DefenceItem shield = new DefenceItem
            {
                Name = "Shield",
                ReduceHitPoint = 5,
                Lootable = true,
                Removeable = true
            };

            Creature warrior = new Creature("Warrior", 2, 3, 100);
            Creature monster = new Creature("Warrior", 2, 3, 100);
            Creature monk = new Creature("Warrior", 2, 3, 100);

            world.AddCreature(warrior);
            world.AddCreature(monster);
            world.AddCreature(monk);
            world.AddWorldObject(sword);
            world.AddWorldObject(shield);

            warrior.Loot(sword);
            monster.Loot(shield);

            warrior.Hit(monster);

            Console.WriteLine($"{monster.Name}'s remaining HP: {monster.HitPoints}");
           
            logger.LogInfo("Game ending...");
        }
    }
}
