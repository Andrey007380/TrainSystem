using Common.Dto;
using Common.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using TrainStationModel.TrainModel;

namespace ConsoleTrainStationUserInterface
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {

            ITrainStationModel model = new TrainStationModel.TrainStationModel();
            ITrainModel trainmodel;
            ConsoleKeyInfo key = new ConsoleKeyInfo();

            
            do
            {
                
                Console.Clear();
                Menu();
                key = Console.ReadKey();
                switch (key.KeyChar.ToString())
                {
                    case "1":
                        Console.Clear();
                        model.AddTrain(AddTrain());
                        break;
                    case "2":
                        Console.Clear();
                        try
                        {
                            int id = RemoveTrain();
                            model.RemoveTrain(model.Trains[id]);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Для возвращения в меню нажмите любую клавишу...");
                            Console.ReadKey();
                        }
                        break;
                    case "3":
                        Console.Clear();
                        ShowTrains(model.Trains.Select(x => x.Value).ToList());
                        Console.WriteLine("\n\n");
                        TrainOptions();

                        string keyTraiMenu = Console.ReadLine();
                        switch (keyTraiMenu)
                        {
                            case "1":
                                Console.Write("Введите Id поезда: ");
                                string trainId = Console.ReadLine();

                                try
                                {
                                    var train = model.Trains[Convert.ToInt32(trainId.Trim())];
                                   while (true);
                                }
                                catch
                                {
                                    Console.WriteLine("Поезд не найден.");
                                }
                                
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            } while (key.Key != ConsoleKey.Escape);
           

            Console.ReadKey();
        }


        static void Menu()
        {
            Console.WriteLine("_\tМеню\n" +
                              "1|\tДобавить поезд\n" +
                              "2|\tУдалить поезд\n" +
                              "3|\tСписок поездов\n" +
                              "4|\tВыход\n");
        }

        static TrainDto AddTrain()
        {
           
            string[] separators = { ",", ".", ":", " " };
            var dateTime = new DateTime();

            Console.Write("Введите конечную точку прибытия поезда: ");
            string endPoint = Console.ReadLine();

            while (true)
            {
                Console.Write("Введите дату прибытия: ");
                string date = Console.ReadLine();

                if (!DateTime.TryParse(date.Trim(), out DateTime tempDateTime))
                    Console.WriteLine("Введие дату в формате ДД.ММ.ГГГГ");
                else
                {
                    if (tempDateTime.DayOfYear >= DateTime.Now.DayOfYear && tempDateTime.Year >= DateTime.Now.Year)
                    {
                        dateTime = tempDateTime;
                        break;
                    }
                    else
                        Console.WriteLine("Введённая дата не может быть меньше сегодняшней.");
                }  
            }

            while (true)
            {
                bool isCorrect = true;
                Console.Write("Введите время прибытия: ");
                string time = Console.ReadLine();

                var timeArray = time.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                if (timeArray.Length >= 2)
                {
                    
                    if (double.TryParse(timeArray[0], out double hours) && hours <= 24)
                        dateTime.AddHours(hours);
                    else
                        isCorrect = false;

                    if (double.TryParse(timeArray[1], out double minutes) && minutes <= 60)
                        dateTime.AddMinutes(minutes);
                    else
                        isCorrect = false;
                }
                else
                    isCorrect = false;
                if (isCorrect)
                    break;
                Console.WriteLine("Убедитесь, что Вы ввели время отправления поезда правильно, в формате ЧЧ:ММ");
            }

            return new TrainDto(random.Next(), null, endPoint, dateTime);
        }

        static int RemoveTrain()
        {
            Console.Write("Введите Id поезда, который хотите удалить: ");
            while (true)
            {
                var id = Console.ReadLine();
                if (!int.TryParse(id, out int idInt))
                    Console.Write("Убедитесь, что ввели Id поезда правильно.");
                else
                {
                    return idInt;
                }
            }
        }

        static void ShowTrains(IList<TrainDto> trains)
        {
            foreach (var item in trains)
            {
                Console.WriteLine(item.Id + "\t" + item.EndPoit + "\t" + item.DepartureTime);
            }
        }

        static void TrainOptions()
        {
            Console.WriteLine("1|\tВыбрать поезд\n" +
                              "2|\tВернуть в главное меню\n");
        }



       
    }
}
