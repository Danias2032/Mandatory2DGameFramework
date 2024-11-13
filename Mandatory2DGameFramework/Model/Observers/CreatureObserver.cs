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
        /// <summary>
        /// Sender en besked fra objektet det er sat på,
        /// når det ændrer tilstand, f.eks. mister HP.
        /// </summary>
        /// <param name="message"></param>
        public void Update(string message)
        {
            Console.WriteLine($"Observer received update: {message}");
        }
    }
}
