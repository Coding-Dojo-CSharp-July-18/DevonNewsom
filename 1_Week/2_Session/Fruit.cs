namespace OOPFun
{
    public class Fruit
    {
        // PUT FRUIT THINGS HERE
        
        // Fields (DATA)
        private double _weight;
        private int _calories;
        public Fruit(double weight, int cal)
        {
            _weight = weight;
            _calories = cal;
        }
        // public Fruit()
        // {
        //     _weight = 100;
        //     _calories = 10;
        // }

        // Properties
        public double Weight
        {
            get 
            {
                if(_calories > 100) 
                    return Weight * 2;
                return Weight; 
            }
        }
        public int Calories
        {
            get 
            {
                return _calories;
            }
            private set
            {
                _calories = value;
            }
        }

        // Method 
        public double Ripen(string season)
        {
            int mod = 5;
            if(season == "SUMMER")
                mod = 6;

            _weight += mod;
            // return "SIP";
            return Weight;
        }
        // OVERLOADING METHOD!!!
        public double Ripen()
        {
            _weight += 1;
            return Weight;
        }
    }
    public class Mango : Fruit
    {
        public Mango() : base(200, 75)
        {

        }
        // Auto Intitializer
        public int PitDifficulty {get;set;}
    }

}