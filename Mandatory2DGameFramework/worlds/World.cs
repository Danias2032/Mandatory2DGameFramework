using Mandatory2DGameFramework.model.Cretures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.worlds
{
    public class World
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        // world objects
        private List<WorldObject> _worldObjects;
        // world creatures
        private List<Creature> _creatures;

        public World(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            _worldObjects = new List<WorldObject>();
            _creatures = new List<Creature>();
        }

        public IEnumerable<WorldObject> GetLootAbleObjects()
            => _worldObjects.Where(obj => obj.Lootable);

        public IEnumerable<Creature> GetCreaturesInRange(int x, int y, int range)
            => _creatures.Where(
                c => Math.Sqrt(Math.Pow(c.X - x, 2) + Math.Pow(c.Y - y, 2)) <= range);

        public Creature? GetCreatureByName(string name)
            => _creatures.FirstOrDefault(c => c.Name == name);

        public IEnumerable<Creature> GetCreaturesWithHealth(int minHealth)
            => _creatures.Where(
                c => c.HitPoints >= minHealth);

        public bool HasCreatureAt(int x, int y)
            => _creatures.Any(
                c => c.X == x && c.Y == y);

        public IEnumerable<WorldObject> GetObjectsByName(string name)
            => _worldObjects.Where(obj => obj.Name.Contains(name));

        public override string ToString()
        {
            return $"{{{nameof(MaxX)}={MaxX.ToString()}, {nameof(MaxY)}={MaxY.ToString()}}}";
        }

        public void AddCreature(Creature creature) => _creatures.Add(creature);
        public void AddWorldObject(WorldObject obj) => _worldObjects.Add(obj);
        public void RemoveWorldObject(WorldObject obj)
        {
            if (obj.Removeable)
            {
                _worldObjects.Remove(obj);
            }
        }
    }
}
