using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQLecture
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {834,2,-23,2,103,-5,42,-1,27};
            int max = numbers.Max();

            List<string> names = new List<string>
            {
                "Sharon",
                "Charlie",
                "Barbara",
                "Molly",
                "Ashton",
                "Marcellus",
                "Marcellus",
                "Molly",
                "Zeleg",
                "Yvonne",
                "Yoda",
                "Bob"
            };

            int maxNameLength = names.Max(name => name.Length);
            string longestName = names.FirstOrDefault(name => name.Length == 100);

            string[] firstHalf = names.Where(name => name.ToLower()[0] < 'm').ToArray();

            // 1 => "1"
            string[] toStringNums = numbers.Select(num => num.ToString()).ToArray();

            List<City> AllCities = Place.GetCities();
            List<State> AllStates = Place.GetStates();

            int highestPopulation = AllCities.Max(city => city.Population);
            City biggestCity = AllCities.FirstOrDefault(city => city.Population == highestPopulation);

            //                       Outer           Inner
            List<State> StatesWithCities = AllStates.Join(AllCities,
                // what joins outer
                s => s.StateCode,
                // what joins inner
                c => c.StateCode,
                // what we want back from two joined objects
                (joinState, joinCity) =>
                {
                    joinState.Cities.Add(joinCity);
                    return joinState;
                }).ToList();

            int maxStatePop = StatesWithCities.Max(st => st.Cities.Sum(c => c.Population));

            // Challenge! find most populous state!
            State mostPopulous = StatesWithCities.SingleOrDefault(
                s => s.Cities.Sum(c => c.Population) == maxStatePop
            );


        }
    }
}
