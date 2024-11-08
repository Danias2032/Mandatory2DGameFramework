using Mandatory2DGameFramework.Interface;
using Mandatory2DGameFramework.Logger;
using Mandatory2DGameFramework.model.attack;
using Mandatory2DGameFramework.model.defence;
using Mandatory2DGameFramework.worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.model.Creatures
{
    public class Creature : ISubject
    {
        private static readonly MyLogger _logger = MyLogger.Instance;
        private List<IObserver> _observers = new List<IObserver>();
        private IAttackStrategy _attackStrategy;

        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public AttackItem? Attack { get; set; }
        public DefenceItem? Defence { get; set; }
        public void SetAttackStrategy(IAttackStrategy strategy) => _attackStrategy = strategy;

        public Creature(string name, int hitPoints, int x, int y, AttackItem? attack = null, DefenceItem? defence = null)
        {
            Name = name;
            HitPoints = 100;
            X = y;
            Y = x;
            HitPoints = hitPoints;
            Attack = attack;
            Defence = defence;
        }

        public void Attach(IObserver observer) => _observers.Add(observer);
        public void Detach(IObserver observer) => _observers?.Remove(observer);
        public void Notify(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }
        //public void Notify() => _observers.ForEach(o => o.Update(this));

        public int Hit(Creature target)
        {
            if (Attack == null)
            {
                _logger.LogWarning($"{Name} has no weapon");
                return 0;
            }

            double distance = Math.Sqrt(Math.Pow(target.X - X, 2) + Math.Pow(target.Y - Y, 2));
            if (distance > Attack.Range)
            {
                _logger.LogInfo($"{Name} is too far from {target.Name} to attack");
                return 0;
            }

            if (_attackStrategy != null)
            {
                return _attackStrategy.Attack(this, target);
            }

            int damage = Attack.Hit;
            target.ReceiveHit(damage);
            _logger.LogInfo($"{Name} hits {target.Name} with {Attack.Name} for {damage} damage");
            return damage;
        }

        public void ReceiveHit(int hit)
        {
            int defensePoints = Defence?.ReduceHitPoints ?? 0;
            int damage = Math.Max(0, hit - defensePoints);
            HitPoints -= damage;
            _logger.LogInfo($"{Name} receives {damage} damage, remaining HP: {HitPoints}");

            if (HitPoints <= 0)
            {
                _logger.LogInfo($"{Name} has been defeated");
            }
        }

        public void Loot(WorldObject obj)
        {
            if (!obj.Lootable)
            {
                _logger.LogInfo($"{obj.Name} cannot be looted.");
                return;
            }
            if (obj is AttackItem attackItem)
            {
                Attack = attackItem;
                _logger.LogInfo($"{Name} loots {attackItem.Name} as a weapon.");
            }
            else if (obj is DefenceItem defenceItem)
            {
                Defence = defenceItem;
                _logger.LogInfo($"{Name} loots {defenceItem.Name} as armor.");
            }
            else
            {
                _logger.LogInfo($"{Name} cannot loot this item.");
            }
        }

        public bool CanReachObject(WorldObject obj)
        {
            return Attack?.Range > 0;
        }

        public IEnumerable<Creature> FindTargetsInRange(World world)
        {
            if (Attack == null) return Enumerable.Empty<Creature>();

            return world.GetCreaturesInRange(X, Y, Attack.Range)
                .Where(c => c != this);
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(HitPoints)}={HitPoints}, {nameof(Attack)}={Attack}, {nameof(Defence)}={Defence}}}";
        }
    }
}
