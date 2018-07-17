using System;
using System.Collections.Generic;

namespace _1_Session
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cant make these, too ABSTRACT!
            
            // Unit p1 = new Unit("Ron");
            // Unit p2 = new Unit("Sally");
            // Unit p3 = new Unit("Dennis");

            Athlete a1 = new Athlete("Martha");
            Athlete a2 = new Athlete("Jane");

            List<IHasName> hasNamers = new List<IHasName>()
            {
                a1, a2, new Building("Grain Silo"), new Building("")
            };


            
            foreach(var p in hasNamers)
            {
                Console.WriteLine($"Name: {p.Name}");
            }
        }
        public static void DamageGroup(IEnumerable<IDamageable> targets)
        {
            foreach(IDamageable target in targets)
            {
                target.TakeDamage(5);
            }
        }
    }
}
