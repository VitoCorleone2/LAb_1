using LAb_1;
using System.ComponentModel.Design;
using System.Drawing;
using System.Net.Http.Headers;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;


void PrintCarInfo(Car car)
{
    Console.WriteLine("\nІнформація про автомобіль:");
    Console.WriteLine($"Назва моделі: {car.NameModel}");
    Console.WriteLine($"Бренд: {car.Brand}");
    Console.WriteLine($"Колір: {car.Color}");
    Console.WriteLine($"Максимальна швидкість: {car.MaxSpeed} км/год");
    Console.WriteLine($"Номер: {car.Number}");
    Console.WriteLine($"Вага: {car.Weight} кг");
}

Console.WriteLine("Початок роботи");
List<Car> cars = new List<Car>();
int actualSizeList = 0;
bool repeat = true;

do
{
    Console.WriteLine("Введіть максимальний розмір списку автомобілів");
    if (short.TryParse(Console.ReadLine(), out short sizeList) && sizeList > 0)
    {
        do
        {
            Console.WriteLine("\nВиберіть операцію:\n" +
                " Додати автомобіль -> 1\n Вивести на екран автомобілі -> 2\n Знайти автомобіль -> 3\n" +
                " Видалити автомобіль -> 4\n Демонстрація поведінки класу -> 5\n Вихід із програми -> 0");
            Console.WriteLine("Оберіть операцію:");
            if (!short.TryParse(Console.ReadLine(), out short selection))
            {
                Console.WriteLine("Невірний ввід");
                continue;
            }

            switch (selection)
            {
                case 1:
                    if (actualSizeList < sizeList)
                    {
                        cars.Add(new Car());

                        bool Repeat = false;
                        do
                        {
                            Repeat = false;
                            Console.Write("Введіть назву моделі автомобіля (мінімум 3 символи) -> ");
                            string nameCAR = Console.ReadLine();
                            try
                            {
                                cars[cars.Count - 1].NameModel = nameCAR;
                            }
                            catch (ArgumentNullException)
                            {
                                Repeat = true;
                                Console.WriteLine("Невірний ввід");
                            }                                                                                      
                        } while (Repeat );
                        do
                        {
                            Console.Write("Введіть бренд автомобіля Форд -> 1, Шевроле -> 2, Мазда -> 3, Феррарі -> 4, Міцубісі -> 5, Шкода -> 6, Фольксваген -> 7\n ");
                            if (short.TryParse(Console.ReadLine(), out short selectBrand))                                                         
                                cars[cars.Count-1].Brand = (BrandCar)selectBrand;                              
                            if(cars[cars.Count - 1].Brand == BrandCar.UNKNOWN)
                            Console.WriteLine("Невірний ввід");
                        } while (cars[cars.Count - 1].Brand ==BrandCar.UNKNOWN) ;


                        do
                        {
                            Console.Write("Оберіть  колір автомобіля червоний -> 1, зелений -> 2, синій -> 3, рожевий -> 4, фіолетовий -> 5, золотий -> 6, \nоранжевий -> 7 \n");
                            if (short.TryParse(Console.ReadLine(), out short selectColor))


                                cars[cars.Count - 1].Color = (ColorCar)selectColor;

                            if (cars[cars.Count - 1].Color == ColorCar.UNKNOWN)
                                Console.WriteLine("Невірний ввід");
                        } while (cars[cars.Count - 1].Color == ColorCar.UNKNOWN);
                         do
                        {Repeat=false;
                            Console.Write("Введіть максимальну швидкість автомобіля (від 0 до 500 км/год) -> ");
                            if (int.TryParse(Console.ReadLine(), out int speed))
                            {
                                try
                                {
                                    cars[cars.Count - 1].MaxSpeed = speed;
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    Repeat = true;
                                    Console.WriteLine("Невірний ввід");
                                }
                            }
                            else
                            {
                                Repeat = true;
                                Console.WriteLine("Невірний ввід");
                            }


                        } while (Repeat);
                        do
                        {Repeat = false;
                            Console.Write("Введіть унікальний номер автомобіля (від 1 до 9999) -> ");
                            if (short.TryParse(Console.ReadLine(), out short number))
                            {
                                int chek_number_car = cars.FindIndex(x => x.Number.Equals(number));
                                if (chek_number_car == -1)
                                {
                                    try
                                    {
                                        cars[cars.Count - 1].Number = number;
                                    }
                                    catch (ArgumentOutOfRangeException)
                                    {
                                        Repeat=true;    
                                        Console.WriteLine("Невірний ввід");
                                    }

                                }
                                else
                                {Repeat = true;
                                    Console.WriteLine("Не допустиме значення номера або він уже використовується .");
                                }
                            }
                            else
                            {
                                Repeat = true;
                                Console.WriteLine("Не допустиме значення номера або він уже використовується .");

                            }
                           
                               
                            
                        } while (Repeat);
                        do
                        {
                            Repeat = false;  
                            Console.Write("Введіть вагу автомобіля (від 0 до 5000 кг) -> ");
                            if (float.TryParse(Console.ReadLine(), out float weight) )
                            {
                                try
                                {
                                    cars[cars.Count - 1].Weight = weight;
                                }
                                catch (ArgumentOutOfRangeException)
                                {Repeat = true;
                                    Console.WriteLine("Невірний ввід");
                                    
                                }
                                actualSizeList++;

                            }
                            else
                            {Repeat=true;
                                Console.WriteLine("Невірний ввід");

                            }


                        } while (Repeat);
                    }
                    else
                    {
                        Console.WriteLine("Досягнуто максимальний розмір списку");
                    }
                    break;
                case 2:
                    if (cars.Count > 0) 
                    {
                        for (int i = 0; i < cars.Count; i++) 
                        {
                            PrintCarInfo(cars[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Об'єкти не знайдено");
                    }
                    break;
                case 3:
                    if (cars.Any())
                    {
                        Console.WriteLine("\nВведіть характеристику для пошуку\n" +
                                          "Пошук за назвою -> 1\nПошук за номером -> 2\nСкасувати -> 0");
                        if (short.TryParse(Console.ReadLine(), out short selectCharacterSearch))
                        {
                            switch (selectCharacterSearch)
                            {
                                case 1:
                                    while (true)
                                    {
                                        Console.Write("Введіть назву моделі автомобіля для пошуку (мінімум 3 символи) -> ");
                                        string name = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(name) && name.Length >= 3)
                                        {
                                            Car searchCar = cars.FirstOrDefault(c => c.NameModel.Equals(name, StringComparison.OrdinalIgnoreCase));
                                            if (searchCar==null)
                                            {
                                                Console.WriteLine("Об'єкт не знайдено");
                                            }
                                            else
                                            {
                                                int carIndex = cars.FindIndex(x => x.Equals(searchCar));
                                                Console.WriteLine($"Об'єкт під індексом: {++carIndex}");
                                                PrintCarInfo(searchCar);
                                            }
                                            break;
                                        }
                                        else                                        
                                            Console.WriteLine("Невірний ввід");                                        
                                    }
                                    break;
                                case 2:
                                    while (true)
                                    {
                                        Console.Write("Введіть номер автомобіля для пошуку -> ");
                                        if (short.TryParse(Console.ReadLine(), out short num))
                                        {
                                            Car searchCar = cars.FirstOrDefault(x => x.Number.Equals(num));
                                            if (searchCar != null)
                                            {
                                                int carIndex = cars.FindIndex(x => x.Equals(searchCar));
                                                Console.WriteLine($"Об'єкт під індексом: {++carIndex}");
                                                PrintCarInfo(searchCar);
                                                break;
                                            }
                                            else                                            
                                                Console.WriteLine("Об'єкт не знайдено");  
                                        }
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Невірний ввід");
                                    break;
                            }
                        }
                    }
                    else                    
                        Console.WriteLine("Об'єкти не знайдено");                    
                    break;

                case 4:
                    if (cars.Any())
                    {
                        Console.WriteLine("Виберіть характеристику для пошуку та видалення об'єкта\n" +
                                          "Видалити за назвою -> 1\nВидалити за номером у списку -> 2\nСкасувати -> 0");

                        if (short.TryParse(Console.ReadLine(), out short selectCharacterDel))
                        {
                            switch (selectCharacterDel)
                            {
                                case 1:
                                    while (true)
                                    {
                                        Console.Write("Введіть назву моделі автомобіля (мінімум 3 символи) -> ");
                                        string name = Console.ReadLine();
                                        if (!string.IsNullOrEmpty(name) && name.Length >= 3)
                                        {
                                            Car carToRemove = cars.FirstOrDefault(c => c.NameModel.Equals(name, StringComparison.OrdinalIgnoreCase));

                                            if (carToRemove != null)
                                            {
                                                cars.Remove(carToRemove);
                                                actualSizeList--;
                                                Console.WriteLine($"Автомобіль {name} успішно видалено.");
                                            }
                                            else                                            
                                                Console.WriteLine("Автомобіль не знайдено.");                                            
                                            break; 
                                        }
                                        else                                        
                                            Console.WriteLine("Невірний ввід. Назва моделі повинна мати щонайменше 3 символи.");                                        
                                    }
                                    break;
                                case 2:
                                    while (true)
                                    {
                                        Console.Write("Введіть індекс автомобіля у списку -> ");
                                        if (short.TryParse(Console.ReadLine(), out short num) && num >= 0 && num <= cars.Count)
                                        {
                                            --num;
                                            cars.RemoveAt(num);
                                            actualSizeList--;
                                            Console.WriteLine("Автомобіль успішно видалено.");
                                            break;
                                        }
                                        else
                                        Console.WriteLine("Невірний індекс.");
                                    }
                                    break;

                                case 0:
                                    Console.WriteLine("Операцію скасовано.");
                                    break;
                                default:
                                    Console.WriteLine("Невірний ввід");
                                    break;
                            }
                        }
                    }
                    else                    
                        Console.WriteLine("Об'єкти не знайдено");                    
                    break;
                case 5:
                    if (cars.Any())
                    {
                        Console.WriteLine("Введіть номер автомобіля зі списку, з яким хочете виконати дії");
                        if (short.TryParse(Console.ReadLine(), out short index) && index > 0 && index <= cars.Count)
                        {
                            index--;
                            Console.WriteLine("Що бажаєте зробити з двигуном?\nЗапустити -> 1\nЗупинити -> 2\nПеревірити -> 3");
                            if (short.TryParse(Console.ReadLine(), out short action))
                            {
                                switch (action)
                                {
                                    case 1:
                                        if (cars[index].ChekWorkEngine())
                                        {
                                            Console.WriteLine("Двигун вже працює\nРрррррррррр");
                                        }
                                        else
                                        {
                                            cars[index].EngineStart();
                                            Console.WriteLine("........Ррррррррррр");
                                        }
                                        break;
                                    case 2:
                                        if (cars[index].ChekWorkEngine())
                                        {
                                            cars[index].EngineStop();
                                            Console.WriteLine("Ррррррррррр........");
                                        }
                                        else                                        
                                            Console.WriteLine("Двигун ще не запущено");                                        
                                        break;

                                    case 3:
                                        if (cars[index].ChekWorkEngine())                                        
                                            Console.WriteLine("Двигун працює");                                        
                                        else                                        
                                            Console.WriteLine("Двигун не працює");                                        
                                        break;
                                    default:
                                        Console.WriteLine("Невірний ввід");
                                        break;
                                }
                            }
                        }
                        else                        
                            Console.WriteLine("Невірний номер автомобіля або об'єкти не знайдено");                        
                    }
                    else                    
                        Console.WriteLine("Об'єкти не знайдено");                    
                    break;
                case 0:
                    Console.WriteLine("Завершення роботи");
                    repeat = false;
                    break;
                default:
                    Console.WriteLine("Невірна операція");
                    break;
            }
        } while (repeat);
    }
    else    
        Console.WriteLine("Невірний розмір списку");    
} while (repeat);











