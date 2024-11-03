using LAb_1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Security;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LAb_1
{
    class Car
    {
        private string name_model = "UNKNOW";
        private static string country = "UNKNOW";
        private BrandCar brand = BrandCar.UNKNOWN;
        private ColorCar color = ColorCar.UNKNOWN;
        private int max_speed;
        private short number;
        private float weight;
        private short fuel = 0;
        private short maximum_tank_volume = 100;
        private bool engine_is_running = false;

        private static int count;

        public static int Count
        {
            get { return count; }
            set { count = value; }
        }

        public static string Country
        {
            get { return country; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length >= 3)
                    country = value;
                else
                    throw new ArgumentNullException("Назва моделі повинна бути не менш ніж 3 символи.");
            }
        }

        public string NameModel
        {
            get { return name_model; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length >= 3)
                    name_model = value;
                else
                    throw new ArgumentNullException("Назва моделі повинна бути не менш ніж 3 символи.");
            }
        }

        public BrandCar Brand
        {
            get { return brand; }
            set
            {
                switch (value)
                {
                    case BrandCar.FORD:
                    case BrandCar.CHEVROLET:
                    case BrandCar.MAZDA:
                    case BrandCar.FERRARI:
                    case BrandCar.MITSUBISHI:
                    case BrandCar.SKODA:
                    case BrandCar.VOLKSWAGEN:
                        brand = value;
                        break;
                    default:
                        brand = BrandCar.UNKNOWN;
                        throw new ArgumentException("Не існуюча марка авто");
                }
            }
        }

        public ColorCar Color
        {
            get { return color; }
            set
            {
                switch (value)
                {
                    case ColorCar.RED:
                    case ColorCar.GREEN:
                    case ColorCar.BLUE:
                    case ColorCar.PINK:
                    case ColorCar.PURPLE:
                    case ColorCar.GOLD:
                    case ColorCar.ORANGE:
                    case ColorCar.UNKNOWN:
                        color = value;
                        break;
                    default:
                        color = ColorCar.UNKNOWN;
                        throw new ArgumentException("Не існуючий колір");
                }
            }
        }

        public int MaxSpeed
        {
            get { return max_speed; }
            set
            {
                if (value > 0 && value <= 500)
                    max_speed = value;
                else
                    throw new ArgumentOutOfRangeException("Не допустиме значення швидкості (повинно бути від 1 до 500).");
            }
        }

        public float Weight
        {
            get { return weight; }
            set
            {
                if (value >= 0 && value <= 5000)
                    weight = value;
                else
                    throw new ArgumentOutOfRangeException("Не можлива вага (повинно бути від 0 до 5000).");
            }
        }

        public short Number
        {
            get { return number; }
            set
            {
                if (value > 0 && value <= 9999)
                    number = value;
                else
                    throw new ArgumentOutOfRangeException("Не допустиме значення номера (повинно бути від 1 до 9999).");
            }
        }

        public short Fuel
        {
            get { return fuel; }
            private set { fuel = value; }
        }

        public bool EngineIsRunning
        {
            get { return engine_is_running; }
            private set { engine_is_running = value; }
        }

        public bool CheckWorkEngine()
        {
            return EngineIsRunning;
        }



        private short distance = 0;
        public short Distance
        {
            get { return distance; }
            private set { distance = value; }
        }
        public void EngineStartWork()
        {
            if (Fuel != 0) { EngineIsRunning = true; }
            else { throw new Exception("Не має палива"); }
        }
        public void EngineStartTravel(short value)
        {
            Distance = value;
            StartTravel();
        }
        public void EngineStartTravel()
        {
            StartTravel();
        }
        private void StartTravel()
        {
            short required_amount_of_fuel = 0;


            if (Fuel == 0)
            {
                throw new ArgumentOutOfRangeException("Паливо відсутнє. Потрібно заправитися!");
            }


            switch (Distance)
            {
                case 1:
                    required_amount_of_fuel = 5;
                    break;
                case 2:
                    required_amount_of_fuel = 10;
                    break;
                case 3:
                    required_amount_of_fuel = 20;
                    break;
                case 4:
                    required_amount_of_fuel = Fuel;
                    break;
            }


            if (Fuel < required_amount_of_fuel)
            {
                throw new ArgumentOutOfRangeException("Для подорожі на обрану дистанцію не вистачає палива, потрібно заправитися!");
            }
            else
            {
                Fuel -= required_amount_of_fuel;
                if (Fuel == 0) { EngineIsRunning = false; }
            }
        }
        public void EngineStopWork()
        {
            EngineIsRunning = false;
        }
        public void Refill()
        {
            Fuel = maximum_tank_volume;
        }

        public Car()
        { Random random = new Random();
            short autonumber = (short)random.Next(1, 10000);
            NameModel = "AutoName";
            Brand = BrandCar.FORD;
            Color = ColorCar.RED;
            MaxSpeed = 180;
            Number = autonumber;
            Weight = 1400;
            Count++;
        }
        public Car(string Name, short ChooseBrand, short ChooseColor)
        {
            {
                Random random = new Random();
                short autonumber = (short)random.Next(1, 10000);
                NameModel = Name;
                Brand = (BrandCar)ChooseBrand;
                Color = (ColorCar)ChooseColor;
                MaxSpeed = 180;
                Weight = 1400;
                Number = autonumber;
                Count++;
            }

          
        }        
        public Car(string NameModel, short ChooseBrand, short ChooseColor,int Speed, short NumberCar, float WeightCar)
          : this(NameModel, ChooseBrand, ChooseColor)
        {
            MaxSpeed = Speed;
            Weight = WeightCar;
            Number = NumberCar;
            Count++;
        }
        public static Car Parse(string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentNullException("Рядок не може бути порожнім");
            char [] chars = {'/', ',', '.', '(',')' ,'|','{','}' } ;
            var parts = s.Split(chars);
            if (parts.Length != 6)
                throw new FormatException("Невірний формат рядка");

            string nameModel = parts[0].Trim();
            short number =short.Parse(parts[1].Trim());
            BrandCar brand = (BrandCar)Enum.Parse(typeof(BrandCar), parts[2].Trim(), true);
            ColorCar color = (ColorCar)Enum.Parse(typeof(ColorCar), parts[3].Trim(), true);
            int maxSpeed = int.Parse(parts[4].Trim());
            float weight = float.Parse(parts[5].Trim());

            return new Car(nameModel, (short)brand, (short)color, maxSpeed, number,   weight);
        }
        public static bool TryParse(string s, out Car obj)
        {
            try
            {
                obj = Parse(s);
                return true;
            }
            catch
            {
                obj = null;
                return false;
            }
        }
        public override string ToString()
        {
            return $"{name_model}, {brand}, {color}, {max_speed}, {weight}";
        }
    }
}









