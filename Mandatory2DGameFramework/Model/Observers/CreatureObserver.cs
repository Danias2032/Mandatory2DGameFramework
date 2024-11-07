using Mandatory2DGameFramework.Interface;
using Mandatory2DGameFramework.model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.observers
{
    public class CreatureObserver : IObserver
    {
        public void Update(Creature creature)
        {
            Console.WriteLine($"[{creature.Name} now has {creature.HitPoints} HP.");
        }

    }
}
