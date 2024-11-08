using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.Creatures;
using Mandatory2DGameFramework.model.defence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Interface
{
    public interface IObserver
    {
        void Update(string message);
        //void Update(Creature creature);
    }
}
