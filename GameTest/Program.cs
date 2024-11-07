using Mandatory2DGameFramework.Config;
using Mandatory2DGameFramework.Logger;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.model.strategies;
using Mandatory2DGameFramework.worlds;
using System.Diagnostics;

MyLogger logger = MyLogger.Instance;
logger.AddListener(new ConsoleTraceListener());
logger.AddListener(new TextWriterTraceListener());

logger.LogInfo("Game starting...");

var config = ConfigLoader.LoadConfig("Config.xml");
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
    ReduceHitPoints = 5,
    Lootable = true,
    Removeable = true
};

Creature warrior = new Creature("Warrior", 100, 2, 3);
Creature monster = new Creature("Monster", 100, 5, 10);
Creature archer = new Creature("Archer", 80, 2, 3);

warrior.SetAttackStrategy(new MeleeAttackStrategy());
monster.SetAttackStrategy(new MeleeAttackStrategy());
archer.SetAttackStrategy(new RangedAttackStrategy());

world.AddCreature(warrior);
world.AddCreature(monster);
world.AddCreature(archer);
world.AddWorldObject(sword);
world.AddWorldObject(shield);

warrior.Loot(sword);
monster.Loot(shield);

warrior.Hit(monster);

logger.LogInfo($"{monster.Name}'s remaining HP: {monster.HitPoints}");

logger.LogInfo("Game ending...");