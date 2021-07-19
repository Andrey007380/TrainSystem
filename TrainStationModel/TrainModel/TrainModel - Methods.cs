using Common.Dto;
using Common.Enums;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainStationModel.TrainModel
{
    public partial class TrainModel
    {
        private static Random random = new Random();

        public void AddCarriage(CarriageDto carriage)
        {
            int id = random.Next();

            while (carriageDict.ContainsKey(id))
                id = random.Next();

            CarriageDto tempCarriage = new CarriageDto(id, carriage.Places);

            carriageDict.Add(id, tempCarriage);

            // Создание события, уведомляющего о добавлениии элемента в коллекцию.
            RaiseActionCarriage(ActionListEnum.Added, carriage);
        }

        /// <summary>Изменение данных вагона.</summary> 
        /// <param name="carriageOld">Старые данные о вагоне.
        /// Должны полностью совпадать с имеющимся в списке.</param> 
        /// <param name="carriageNew">Новые данные о вагоне. ID изменяться не должен!</param> 
        public void ChangeCarriage(CarriageDto carriageOld, CarriageDto carriageNew)
        {
            if (!carriageDict.TryGetValue(carriageOld.Id, out CarriageDto carcar))
                throw new ArgumentException("Вагона с таким ID нет.", nameof(carriageOld));

            if (carcar.Places != carriageOld.Places)
                throw new ArgumentException("Несовпадают данные о вагоне.", nameof(carriageOld));

            if (carriageOld.Id != carriageNew.Id)
                throw new ArgumentException("Идентификатор должен оставаться прежним.", nameof(carriageNew));

            // Замена старых данных на новые
            carriageDict[carriageNew.Id] = carriageNew;

            // Создание события, уведомляющего об изменении элемента в коллекции.
            RaiseActionCarriage(ActionListEnum.Changed, carriageNew);
        }

        public void RemoveCarriage(CarriageDto carriage)
        {
            if (!carriageDict.TryGetValue(carriage.Id, out CarriageDto removeCarriage))
                throw new ArgumentException("Вагона с таким ID нет.", nameof(carriage));

            if (removeCarriage.Places != carriage.Places)
                throw new ArgumentException("Несовпадают данные об удаляемом вагоне", nameof(carriage));

            if (carriage.Places.First(x => x.IsEmpty == false) != null)
                throw new ArgumentException("Удаление вагона с забронированными местами.", nameof(carriage));

            if (!carriageDict.Remove(carriage.Id))
                throw new ArgumentException("Не удалось удалить поезд. Возможно поезда уже нет в списке.", nameof(carriage));

            // Создание события, уведомляющего об удалении элемента из коллекции.
            RaiseActionCarriage(ActionListEnum.Removed, carriage);
        }
        public void Save()
        {
            DataProcessor dataProcessor = new DataProcessor();
            dataProcessor.SaveToFile<IReadOnlyDictionary<int, CarriageDto>>(carriageDict, "Carriage");
        }
        public T Load<T>(string Name)
        {
            T trainlist;
            DataProcessor dataProcessor = new DataProcessor();
            trainlist = dataProcessor.LoadFromFile<T>(Name);
            if (trainlist == null)
            {
                trainlist = default;
            }

            return trainlist;
        }
    }
}
