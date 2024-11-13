using Mandatory2DGameFramework.Config;
using Mandatory2DGameFramework.Logger;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.model.observers;
using Mandatory2DGameFramework.model.strategies;
using Mandatory2DGameFramework.model.Templates;
using Mandatory2DGameFramework.Model.Creatures;
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
AttackItem bow = new AttackItem
{
    Name = "Bow",
    Hit = 10,
    Range = 3,
    Lootable = true,
    Removeable = true
};

Creature warrior = new Creature("Warrior", 100, 2, 3);
Creature monster = new Creature("Monster", 100, 2, 4);
Creature monster2 = new Creature("Monster2", 100, 2, 4);
Creature archer = new Creature("Archer", 80, 2, 3);
ArcherTemplate archerTemplate = new();
Creature archer1 = archerTemplate.CreateCreature();

warrior.SetAttackStrategy(new MeleeAttackStrategy());
monster.SetAttackStrategy(new MeleeAttackStrategy());
archer.SetAttackStrategy(new RangedAttackStrategy());

world.AddCreature(warrior);
world.AddCreature(monster);
world.AddCreature(archer);
world.AddCreature(archer1);
world.AddWorldObject(sword);
world.AddWorldObject(shield);

warrior.Loot(sword);
monster.Loot(shield);
Console.WriteLine("Template Archer");
archer1.Hit(warrior);

CreatureObserver observer = new CreatureObserver();
Console.WriteLine("Observer - Start");
monster.Attach(observer);
monster.ReceiveHit(20);
monster.ReceiveHit(30);
monster.ReceiveHit(40);
monster.Detach(observer);
Console.WriteLine("Observer - End");
monster.ReceiveHit(25);
monster.ReceiveHit(10);
Console.WriteLine("Monster - Defeat");

warrior.Hit(monster2);
archer.Loot(bow);
archer.Hit(monster2);

logger.LogInfo($"{monster2.Name}'s remaining HP: {monster2.HitPoints}");

logger.LogInfo("Game ending...");