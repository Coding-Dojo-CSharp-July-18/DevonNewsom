// using System;

using System;

namespace OOPFun
{
    class Program
    {
        static void Main(string[] args)
        {

            Fruit fruit = new Fruit(300, 50);

            System.Console.WriteLine(fruit.Weight);

            Mango m1 = new Mango();

            Console.WriteLine(m1.Weight);


            fruit.Ripen("SUMMER");
            // fruit.Weight = 1;

        }
    }
}
