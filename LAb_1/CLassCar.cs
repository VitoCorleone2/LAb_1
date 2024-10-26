using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Security;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LAb_1
{

    class Car
    {
        private string name_model = "Unknow";
        private static short CarAutoNumber=0;
        private BrandCar brand = BrandCar.UNKNOWN;
        private ColorCar color = ColorCar.UNKNOWN;
        private int max_speed ;
        private short number ;
        private float weight;
        private bool engine_is_running= false;        
        public string NameModel
        {
            get { return name_model; }
            set { if (!string.IsNullOrEmpty(value) && value.Length >= 3)
                    name_model = value;
                else 
                   throw new ArgumentNullException();
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
                        brand = BrandCar.FORD;
                        break;
                    case BrandCar.CHEVROLET:
                        brand = BrandCar.CHEVROLET;
                        break;
                    case BrandCar.MAZDA:
                        brand = BrandCar.MAZDA;
                        break;
                    case BrandCar.FERRARI:
                        brand = BrandCar.FERRARI;
                        break;
                    case BrandCar.MITSUBISHI:
                        brand = BrandCar.MITSUBISHI;
                        break;
                    case BrandCar.SKODA:
                        brand = BrandCar.SKODA;
                        break;
                    case BrandCar.VOLKSWAGEN:
                        brand = BrandCar.VOLKSWAGEN;
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
            set {

                switch (value)
                {
                    case ColorCar.RED:
                        color = ColorCar.RED;
                        break;
                    case ColorCar.GREEN:
                        color = ColorCar.GREEN;
                        break;
                    case ColorCar.BLUE:
                        color = ColorCar.BLUE;
                        break;
                    case ColorCar.PINK:
                        color = ColorCar.PINK;
                        break;
                    case ColorCar.PURPLE:
                        color = ColorCar.PURPLE;
                        break;
                    case ColorCar.GOLD:
                        color = ColorCar.GOLD;
                        break;
                    case ColorCar.ORANGE:
                        color = ColorCar.ORANGE;
                        break;
                    case ColorCar.UNKNOWN:
                        color = ColorCar.UNKNOWN;
                        break;
                    default:
                        color = ColorCar.UNKNOWN;
                        throw new ArgumentException("Не існуючий колір ");
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
                    throw new ArgumentOutOfRangeException("Не допустиме значення швидкості");
            }
        }       
        public float Weight
        {
            get { return weight; }
            set {if (value >= 0 && value <= 5000)
                weight = value; 
            else
                    throw new ArgumentOutOfRangeException("Не можлива вага ");
            }
        }       
        public short Number
        {
            get { return number; }
            set { if(value > 0 && value <= 9999)
                number = value; 
            else
                    throw new ArgumentOutOfRangeException("Не допустиме значення номера");
            }
        }       
        public bool EngineIsRunning
        {
            get { return engine_is_running; }
           private set { engine_is_running = value; }
        }
        public bool ChekWorkEngine()
        {
            if (EngineIsRunning == true)
                return true;
            return false;
        }
        public void EngineStart()
        {
            EngineIsRunning = true;
        }
        public void EngineStop()
        {
            EngineIsRunning = false;

        }
        public Car()
        {
            NameModel ="AutoName";
            Brand = BrandCar.FORD;
            Color = ColorCar.RED;
            MaxSpeed = 180;
            Number = ++CarAutoNumber;
            Weight = 1400;                               
        }
        public Car(string Name, short ChooseBrand, short ChooseColor)
        {
            NameModel=Name;
            Brand=(BrandCar)ChooseBrand;
            Color=(ColorCar)ChooseColor;
            MaxSpeed = 180;
            Weight = 1400;
            Number = ++CarAutoNumber;
       
        }
        public Car(int Speed, short NumberCar, float WeightCar,  string NameModel, short ChooseBrand, short ChooseColor)
     : this(NameModel, ChooseBrand, ChooseColor)
        {
            MaxSpeed = Speed;
            Weight = WeightCar;
            Number = NumberCar;
        }
    }





}
       
     
       
    


   

