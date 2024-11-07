using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.model.strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Templates
{
    public class WarriorTemplate : CreatureTemplate
    {
        public override Creature CreateCreature()
        {
            var creature = new Creature
            (
                name: "Warrior",
                hitPoints: 100,
                x: 0,
                y: 0,
                attack: new AttackItem
                {
                    Name = "Sword",
                    Hit = 15,
                    Range = 1
                },
                defence: new DefenceItem
                {
                    Name = "Shield",
                    ReduceHitPoints = 5
                }
                );
            
            creature.SetAttackStrategy(new MeleeAttackStrategy());
            return creature;
        }
    }
}
