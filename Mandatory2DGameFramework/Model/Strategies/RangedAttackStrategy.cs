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
    public class RangedAttackStrategy : IAttackStrategy
    {
        /// <summary>
        /// Afstandsangrebs strategi, 
        /// damage har fall off,
        /// over længere afstand
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
            var distance = Math.Sqrt(Math.Pow(attacker.X - target.X, 2) + Math.Pow(attacker.Y - target.Y, 2));
            int damage = (int)(attacker.Attack.Hit * (1 - distance / (attacker.Attack.Range * 2)));
            target.ReceiveHit(damage);
            MyLogger.Instance.LogInfo($"{attacker.Name} shoots {target.Name} for {damage} damage.");
            return damage;
        }
    }
}
