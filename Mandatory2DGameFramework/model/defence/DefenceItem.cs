using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.defence
{
    public class DefenceItem : WorldObject
    {
        public string Name { get; set; }
        public int ReduceHitPoints { get; set; }

        public DefenceItem()
        {
            Name = string.Empty;
            ReduceHitPoints = 0;
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(ReduceHitPoints)}={ReduceHitPoints}}}";
        }
    }
}
