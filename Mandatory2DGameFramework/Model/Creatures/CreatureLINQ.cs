using Mandatory2DGameFramework.model.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Model.Creatures
{
    public class CreatureLINQ
    {
        public List<Creature> _CreatureList;

        public List<Creature> GetCreaturesWithHitPointsAbove(int threshold)
        {
            return _CreatureList.Where(creature => creature.HitPoints > threshold).ToList();
        }
        public Creature? FindCreatureByName(string name)
        {
            return _CreatureList.FirstOrDefault(creature => creature.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
        public Dictionary<string, List<Creature>> GroupCreaturesByType()
        {
            return _CreatureList
                .GroupBy(creature => creature.GetType().Name)
                .ToDictionary(group => group.Key, group => group.ToList());
        }
        public List<Creature> GetCreaturesOrderedByHitPoints()
        {
            return _CreatureList.OrderByDescending(creature => creature.HitPoints).ToList();
        }
    }
}
