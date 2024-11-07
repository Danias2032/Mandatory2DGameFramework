using Mandatory2DGameFramework.model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Interface
{
    public interface IAttackStrategy
    {
        int Attack(Creature creature, Creature target);
    }
}
