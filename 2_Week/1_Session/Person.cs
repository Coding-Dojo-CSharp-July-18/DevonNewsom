using System;

namespace _1_Session
{
    public interface IDamageable 
    {
        int Health {get;}
        bool TakeDamage(int amt);
    }
    public interface IHasName
    {
        // MUST HAVE Name property
        string Name {get;}

        void SayName();
    }
    public abstract class Unit : IHasName, IDamageable
    {
        protected int _health = 100;
        public int Health
        {
            get { return _health; }
        }
        public bool TakeDamage(int amt)
        {
            _health -= amt;
            if(_health <= 0)
                return false;
            return true;

        }
        // Astract METHODS/PROPERTIES means children MUST Override4
        // DONT DEFINE, only signature
        public abstract bool NearDeath();

        // Virtual: can be overriden (but not required)
        // DO DEFINE
        public virtual bool IsCool()
        {
            return true;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
        }
        public Unit(string name)
        {
            _name = name;
        }
        public int Age;
        public void SayName()
        {

        }
    }
    public class Athlete : Unit
    {
        public Athlete(string name) : base(name) {}
        public override bool NearDeath()
        {
            return _health < 5;
        }
        public override bool IsCool()
        {
            if(_health < 50)
                return false;
            return true;
        }
    }
    public class Building : IHasName
    {
        public Building(string name)
        {
            _name = name;
        }
        private string _name;
        public string Name
        {
            get { return _name; }
        }
        public void SayName()
        {
            Console.WriteLine($"THis buildings name is: {_name}");
        }
    }
}