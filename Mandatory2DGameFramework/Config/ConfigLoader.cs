using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Mandatory2DGameFramework.Config
{
    public class ConfigLoader
    {
        public static GameConfig LoadConfig(string xmlFilePath)
        {
            XDocument doc = XDocument.Load(xmlFilePath);
            GameConfig config = new GameConfig();

            var worldElement = doc.Root.Element("World");
            config.WorldMaxX = int.Parse(worldElement.Element("MaxX").Value);
            config.WorldMaxY = int.Parse(worldElement.Element("MaxY").Value);

            var attackItems = doc.Root.Element("AttackItems").Elements("AttackItem");
            foreach (var item in attackItems)
            {
                config.AttackItems.Add(new AttackItemConfig
                {
                    Name = item.Element("Name").Value,
                    Hit = int.Parse(item.Element("Hit").Value),
                    Range = int.Parse(item.Element("Range").Value),
                    Lootable = bool.Parse(item.Element("Lootable").Value),
                    Removeable = bool.Parse(item.Element("Removeable").Value)
                });
            }

            var defenceItems = doc.Root.Element("DefenceItems").Elements("DefenceItem");
            foreach (var item in defenceItems)
            {
                config.DefenceItems.Add(new DefenceItemConfig
                {
                    Name = item.Element("Name").Value,
                    ReduceHitPoint = int.Parse(item.Element("ReduceHitPoint").Value),
                    Lootable = bool.Parse(item.Element("Lootable").Value),
                    Removeable = bool.Parse(item.Element("Removeable").Value)
                });
            }

            var creatures = doc.Root.Element("Creatures").Elements("Creature");
            foreach (var creature in creatures)
            {
                config.Creatures.Add(new CreatureConfig
                {
                    Name = creature.Element("Name").Value,
                    HitPoints = int.Parse(creature.Element("HitPoints").Value),
                    X = int.Parse(creature.Element("X").Value),
                    Y = int.Parse(creature.Element("Y").Value),
                    InitialAttackItem = creature.Element("InitialAttackItem")?.Value,
                    InitialDefenceItem = creature.Element("InitialDefenceItem")?.Value,
                });
            }

            return config;
        }
    }
}
