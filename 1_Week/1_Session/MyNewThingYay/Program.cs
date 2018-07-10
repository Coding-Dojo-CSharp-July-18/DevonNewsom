using System;

namespace MyNewThingYay
{
    class Program
    {
        static void Main(string[] args)
        {
            // ENTRY POINT

            // Variables (primitaves)
            int number = 5;
            long bigNumber = 200;
            float speed = 5.5f;
            double aDouble = 50.4;
            string name = "Devon";
            bool isCool = true;

            int someOtherNumber;
            someOtherNumber = 10;

            // CASTING
            double maxSpeed = speed + aDouble;
            float fMaxSpeed = (float)maxSpeed;

            // WHAT IS THIS?
            int iDouble = (int)aDouble;

            // Variables (complex)
            // array?
            int[] numbers = new int[]
            {
                10, 12, 21, -23, 10
            };

            Console.WriteLine(iDouble);
            Console.WriteLine(fMaxSpeed);
            Console.WriteLine(numbers[0]);
            // [10,12,21,-23,10]
        
        }
    }
}
