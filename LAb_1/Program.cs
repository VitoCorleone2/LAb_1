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
                                        actualSizeList++;
                                        Console.WriteLine("Об'єкт успішно додано ");
                                    }
                                    break;

                                case 2:
                                    {
                                        Repeat = false;
                                        do
                                        {
                                            Console.Write("Введіть назву моделі автомобіля (мінімум 3 символи) -> ");
                                            string nameCAR = Console.ReadLine();
                                            short selectBrand = -1;
                                            short selectColor = -1;

                                            Console.Write("Введіть бренд автомобіля Форд -> 1, Шевроле -> 2, Мазда -> 3, Феррарі -> 4, Міцубісі -> 5, Шкода -> 6, Фольксваген -> 7\n ");
                                            if (short.TryParse(Console.ReadLine(), out short valueBrand)) { selectBrand = valueBrand; }

                                            Console.Write("Оберіть колір автомобіля червоний -> 1, зелений -> 2, синій -> 3, рожевий -> 4, фіолетовий -> 5, золотий -> 6, оранжевий -> 7 \n");
                                            if (short.TryParse(Console.ReadLine(), out short valueColor)) { selectColor = valueColor; }

                                            try
                                            {
                                                cars.Add(new Car(nameCAR, selectBrand, selectColor));
                                                actualSizeList++;
                                                Console.WriteLine("Об'єкт успішно додано ");
                                                Repeat = false; 
                                            }
                                            catch (Exception ex)
                                            {
                                                Repeat = true;
                                                Console.WriteLine("Помилка: " + ex.Message + "\nСпробуйте ще раз.");
                                            }
                                        } while (Repeat);
                                        Console.WriteLine("Об'єкт успішно додано ");
                                    }
                                    break;

                                case 3:
                                    {
                                        Repeat = false;
                                        do
                                        {
                                            Console.Write("Введіть назву моделі автомобіля (мінімум 3 символи) -> ");
                                            string nameCAR = Console.ReadLine();
                                            short selectBrand = -1;
                                            short selectColor = -1;
                                            int speedCar = -1;
                                            short valueNumber = -1;
                                            float valueWeight = -1;

                                            Console.Write("Введіть бренд автомобіля Форд -> 1, Шевроле -> 2, Мазда -> 3, Феррарі -> 4, Міцубісі -> 5, Шкода -> 6, Фольксваген -> 7\n ");
                                            if (short.TryParse(Console.ReadLine(), out short valueBrand)) { selectBrand = valueBrand; }

                                            Console.Write("Оберіть колір автомобіля червоний -> 1, зелений -> 2, синій -> 3, рожевий -> 4, фіолетовий -> 5, золотий -> 6, оранжевий -> 7 \n");
                                            if (short.TryParse(Console.ReadLine(), out short valueColor)) { selectColor = valueColor; }

                                            Console.Write("Введіть максимальну швидкість автомобіля (від 0 до 500 км/год) -> ");
                                            if (int.TryParse(Console.ReadLine(), out int valueSpeed)) { speedCar = valueSpeed; }

                                            Console.Write("Введіть унікальний номер автомобіля (від 1 до 9999) -> ");
                                            if (short.TryParse(Console.ReadLine(), out short number))
                                            {
                                                int chek_number_car = cars.FindIndex(x => x.Number.Equals(number));
                                                if (chek_number_car != -1)
                                                {
                                                    Console.WriteLine("Цей номер уже використовується.");
                                                }
                                                else
                                                {
                                                    valueNumber = number;
                                                }
                                            }

                                            Console.Write("Введіть вагу автомобіля (від 0 до 5000 кг) -> ");
                                            if (float.TryParse(Console.ReadLine(), out float weight)) { valueWeight = weight; }

                                            try
                                            {
                                                cars.Add(new Car(speedCar, valueNumber, valueWeight, nameCAR, selectBrand, selectColor));
                                                actualSizeList++;
                                                Console.WriteLine("Об'єкт успішно додано ");
                                                Repeat = false; 
                                            }
                                            catch (Exception ex)
                                            {
                                                Repeat = true;
                                                Console.WriteLine("Помилка: " + ex.Message + "\nСпробуйте ще раз.");
                                            }
                                        } while (Repeat);
                                        Console.WriteLine("Об'єкт успішно додано ");
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











