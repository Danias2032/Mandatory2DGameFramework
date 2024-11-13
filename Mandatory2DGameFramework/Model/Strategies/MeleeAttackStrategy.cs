using Mandatory2DGameFramework.Interface;
using Mandatory2DGameFramework.Logger;
using Mandatory2DGameFramework.model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.strategies
{
    public class MeleeAttackStrategy : IAttackStrategy
    {
        /// <summary>
        /// Angrebs strategi for nærkamp,
        /// direkte, ingen fall off, ved afstand.
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int Attack(Creature attacker, Creature target)
        {
            if (attacker.Attack == null)
            { 
                return 0;
            }
            int damage = attacker.Attack.Hit;
            target.ReceiveHit(damage);
            MyLogger.Instance.LogInfo($"{attacker.Name} attacks {target.Name} for {damage} damage.");
            return damage;
        }
    }
}
