using Mandatory2DGameFramework.model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Templates
{
    public abstract class CreatureTemplate
    {
        /// <summary>
        /// Design Pattern: Template
        /// Override i Archer, Monster, Warrior.
        /// </summary>
        /// <returns></returns>
        public abstract Creature CreateCreature();
    }
}
