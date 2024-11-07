using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Cretures
{
    public class Creature
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        // Todo consider how many attack / defence weapons are allowed
        public AttackItem? Attack { get; set; }
        public DefenceItem? Defence { get; set; }

        public Creature(string name, int hitPoints, int x, int y, AttackItem? attack = null, DefenceItem? defence = null)
        {
            Name = name;
            HitPoints = 100;
            X = y;
            Y = x;
            HitPoints = hitPoints;
            Attack = attack;
            Defence = defence;

        }

        public int Hit(Creature target)
        {
            if (Attack == null)
            {
                Console.WriteLine($"{Name} has no weapon");
                return 0;
            }
            if (Attack != null)
            {
                int damage = Attack.Hit;
                target.ReceiveHit(damage);
                Console.WriteLine($"{Name} hits {target.Name} with {Attack.Name} for {damage} damage");
                return damage;
            }
            else
            {
                Console.WriteLine($"{Name} has no weapon");
                return 0;
            }
        }

        public void ReceiveHit(int hit)
        {
            int defensePoints = Defence?.ReduceHitPoint ?? 0;
            int damage = Math.Max(0, hit - defensePoints);
            HitPoints -= damage;
            Console.WriteLine($"{Name} receives {damage} damage, remaining HP: {HitPoints}");

            if (HitPoints <= 0)
            {
                Console.WriteLine($"{Name} has been defeated");
            }
        }

        public void Loot(WorldObject obj)
        {
            if (!obj.Lootable)
            {
                Console.WriteLine($"{obj.Name} cannot be looted.");
                return;
            }
            if (obj is AttackItem attackItem)
            {
                Attack = attackItem;
                Console.WriteLine($"{Name} loots {attackItem.Name} as a weapon.");
            }
            else if (obj is DefenceItem defenceItem)
            {
                Defence = defenceItem;
                Console.WriteLine($"{Name} loots {defenceItem} as armor.");
            }
            else 
            {
                Console.WriteLine($"{Name} cannot loot this item.");
            }
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(HitPoints)}={HitPoints}, {nameof(Attack)}={Attack}, {nameof(Defence)}={Defence}}}";
        }
    }
}
