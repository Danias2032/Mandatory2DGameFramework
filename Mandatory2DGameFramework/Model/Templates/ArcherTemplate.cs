﻿using Mandatory2DGameFramework.model.attack;
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
    public class ArcherTemplate : CreatureTemplate
    {
        public override Creature CreateCreature()
        {
            var creature = new Creature
            {
                Name = "Archer",
                HitPoints = 80,
                Attack = new AttackItem
                {
                    Name = "Bow",
                    Hit = 10,
                    Range = 3
                },
                Defence = new DefenceItem
                {
                    Lootable = false
                }
            };
            creature.SetAttackStrategy(new RangedAttackStrategy());
            return creature;
        }
    }
}
