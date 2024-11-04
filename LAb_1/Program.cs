using LAb_1;
using System;
using System.ComponentModel.Design;
using System.Drawing;
using System.Net.Http.Headers;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;


void PrintCarInfo(Car car)
{
    
    Console.WriteLine("\nКраїна   Назва    Марка    Колір       Швидкість      Маса");
    Console.WriteLine(car.ToString());   
}

Console.WriteLine("Початок роботи");
List<Car> cars = new List<Car>();
Console.WriteLine("Введіть країну регестрації");
bool correct = false;
do
{
    try
    {
        Car.Country = Console.ReadLine();    
    }
    catch (ArgumentNullException ex)
    {
        correct = true;
        Console.WriteLine("Помилка: " + ex.Message + "\nСпробуйте ще раз.");

    }
} while (correct);
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
                " Видалити автомобіль -> 4\n Демонстрація поведінки класу -> 5\nДемонстрація роботи статичного методу -> 6\n Вихід із програми -> 0");
            Console.WriteLine("Оберіть операцію:");
            if (!short.TryParse(Console.ReadLine(), out short selection))
            {
                Console.WriteLine("Невірний ввід");
                continue;
            }

            switch (selection)
            {
                case 1:
                    if (Car.Count < sizeList)
                    {
                        Console.WriteLine("Оберіть спосіб заповнення інформації про авто для додавання в список " +
                            "\nАвтоматична генерація-1\nВвід назви моделі, марки та кольору-2\nВведення всієї інформації-3\nВідміна операції-0");
                        if(short.TryParse(Console.ReadLine(),out short choose))
                        {
                            bool Repeat = false;
                            switch (choose)
                            {
                                case 1:
                                    {
                                        cars.Add(new Car());
                                        Console.WriteLine("Об'єкт успішно додано ");
                                    }
                                    break;

                                case 2:
                                    {
                                        do
                                        {
                                            Repeat = false;
                                            Console.Write("Введіть інформацію про авто в такому форматі (Для коректного визначення використовуйте англійську): ");
                                            Console.WriteLine("\nНазва , Марка , Колір");

                                            if (!Car.TryParse(Console.ReadLine(), false, out Car obj))
                                            {
                                                Repeat = true;
                                                Console.WriteLine("Невірний формат введених даних");
                                            }
                                            else
                                            {
                                                cars.Add(obj); 
                                                Console.WriteLine("Об'єкт успішно додано ");
                                            }
                                        } while (Repeat);
                                    }
                                    break;

                                case 3:
                                    {
                                        do
                                        {
                                            Repeat = false;
                                            Console.Write("Введіть інформацію про авто в такому форматі (Для коректного визначення використовуйте англійську): ");
                                            Console.WriteLine("\nНазва , Марка , Колір , Максимальна швидкість , Номер , Вага");

                                            if (!Car.TryParse(Console.ReadLine(), true, out Car obj)) 
                                            {
                                                Repeat = true;
                                                Console.WriteLine("Невірний формат введених даних");
                                            }
                                            else
                                            {
                                                cars.Add(obj);
                                                Console.WriteLine("Об'єкт успішно додано ");
                                            }
                                        } while (Repeat);
                                    }
                                    break;

                                default:
                                    break;
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Досягнуто максимальний розмір списку");
                    }
                    break;
                case 2:
                    if (cars.Count > 0)
                    {
                        Console.WriteLine($"Кількість об'єктів->{Car.Count}");
                        Console.WriteLine("\nІнформація про автомобілі:");
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
                                            int searchCar = cars.FindIndex(c => c.NameModel.Equals(name, StringComparison.OrdinalIgnoreCase));
                                            if (searchCar==-1)
                                            {
                                                Console.WriteLine("Об'єкт не знайдено");
                                            }
                                            else
                                            {
                                                int carIndex = cars.FindIndex(x => x.Equals(searchCar));
                                                Console.WriteLine($"Об'єкт під індексом: {++carIndex}");
                                                PrintCarInfo(cars[searchCar]);
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
                                            int searchCar = cars.FindIndex(x => x.Number.Equals(num));
                                            if (searchCar != -1)
                                            {
                                                int carIndex = cars.FindIndex(x => x.Equals(searchCar));
                                                Console.WriteLine($"Об'єкт під індексом: {++carIndex}");
                                                PrintCarInfo(cars[carIndex]);
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
                                            int carToRemove = cars.FindIndex(c => c.NameModel.Equals(name, StringComparison.OrdinalIgnoreCase));

                                            if (carToRemove != -1)
                                            {
                                                cars.Remove(cars[carToRemove]);
                                                Car.Count--;

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
                                            Car.Count--;
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

                            Console.WriteLine("Що бажаєте зробити з авто?\nЗапустити -> 1\nПодорожувати -> 2\nЗупинити -> 3\nПеревірити -> 4\nЗаправити ->5");
                            if (short.TryParse(Console.ReadLine(), out short action))
                            {
                                bool result = true;
                                switch (action)
                                {
                                    case 1:
                                        if (cars[index].CheckWorkEngine())
                                        {
                                            Console.WriteLine("Двигун вже працює\nРрррррррррр");
                                        }
                                        else
                                        {
                                            try
                                            {
                                                cars[index].EngineStartWork();
                                            }
                                            catch (Exception ex)
                                            {
                                                result = false;
                                                Console.WriteLine($"{ex.Message}");
                                            }
                                            if (result) { Console.WriteLine("........РPPPPPPPPPP"); }
                                        }
                                        break;
                                    case 2:
                                        if (cars[index].CheckWorkEngine())
                                        {
                                            Console.WriteLine("Оберіть що хочете зробити.\nПоїхати -> 1\nПовернутися  -> 2\n Відміна-0");
                                            if (short.TryParse(Console.ReadLine(), out short ActionWithEngine))

                                            {

                                                switch (ActionWithEngine)
                                                {
                                                    case 1:
                                                        Console.WriteLine("Оберіть пункт призначення \n найближче місто  - 1 \n Обласний центр  - 2\n Столиця  - 3" +
                                                            "\nМаксимально доступна дистанція  -4 ");
                                                        if (short.TryParse(Console.ReadLine(), out short distance) && distance < 5)
                                                        {
                                                            try
                                                            {
                                                                cars[index].EngineStartTravel(distance);
                                                            }
                                                            catch (ArgumentOutOfRangeException ex)
                                                            {
                                                                result = false;
                                                                Console.WriteLine($"{ex.Message}");
                                                            }

                                                        }
                                                        else
                                                        {
                                                            result = false;
                                                            Console.WriteLine("Не визначений пункт призначення ");
                                                        }
                                                        if (result)
                                                        {
                                                            Console.WriteLine("Прибуто в місце призначення ");
                                                            Console.WriteLine("........РPPPPPPPPPPppppp");
                                                        }
                                                        break;
                                                    case 2:
                                                        try
                                                        {
                                                            cars[index].EngineStartTravel();
                                                        }
                                                        catch (ArgumentOutOfRangeException ex)
                                                        {
                                                            result = false;
                                                            Console.WriteLine($"{ex.Message}");
                                                        }
                                                        if (result)
                                                        {
                                                            Console.WriteLine("Прибуто в місце призначення ");
                                                            Console.WriteLine("........РPPPPPPPPPPppppp");
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("Обрано не можливий варіант ");
                                                        break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Для початку переміщення потрібно запустити двигун");
                                        }
                                        break;
                                    case 3:
                                        if (cars[index].CheckWorkEngine())
                                        {
                                            cars[index].EngineStopWork();
                                            Console.WriteLine("Ррррррррррр........");
                                        }
                                        else                                        
                                            Console.WriteLine("Двигун ще не запущено");                                        
                                        break;

                                    case 4:
                                        if (cars[index].CheckWorkEngine())                                        
                                            Console.WriteLine("Двигун працює");                                        
                                        else                                        
                                            Console.WriteLine("Двигун не працює");                                        
                                        break;
                                        case 5:
                                        cars[index].Refill();
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
                case 6:
                    if (cars.Count >= 2)
                    {
                        bool Repeat;
                        do
                        {
                            Repeat = false;
                            Console.WriteLine("Введіть назву двох автомобілів для порівняння максимальної швидкості");
                            List<short> equalslist = new List<short>();

                            for (int i = 1; i <= 2; i++)
                            {
                                Console.WriteLine($"Назва {i}-го автомобіля:");
                                string name_for_equals = Console.ReadLine();

                                short carforEquals = (short)cars.FindIndex(c => c.NameModel.Equals(name_for_equals, StringComparison.OrdinalIgnoreCase));

                                if (carforEquals == -1)
                                {
                                    Console.WriteLine($"Автомобіль із назвою \"{name_for_equals}\" не знайдено. Спробуйте ще раз.");
                                    Repeat = true;
                                    break;
                                }

                                equalslist.Add(carforEquals);
                            }

                            if (!Repeat)
                            {
                                try
                                {
                                    Car fasterCar = Car.CompareMaxSpeed(cars[equalslist[0]], cars[equalslist[1]]);
                                    Console.WriteLine($"Автомобіль із вищою максимальною швидкістю: {fasterCar.NameModel}");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Сталася помилка: {ex.Message}");
                                    Repeat = true;
                                }
                            }

                        } while (Repeat);
                    }
                    else
                    {
                        Console.WriteLine($"Не достатньо автомобілів для порівняння ");
                    }

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











