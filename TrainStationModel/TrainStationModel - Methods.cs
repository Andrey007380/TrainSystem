using Common.Dto;
using Common.Enums;
using System;
using DAL;
using System.Linq;
using System.Collections.Generic;

namespace TrainStationModel
{
    public partial class TrainStationModel
    {
        private static Random random = new Random();

        public void AddTrain(TrainDto train)
        {
            int id = random.Next();

            while (trainDict.ContainsKey(id))
                id = random.Next();

            TrainDto tempTrain = new TrainDto(id, train.Carriages, train.EndPoit, train.DepartureTime);

            trainDict.Add(id, tempTrain);

            // Создание события, уведомляющего о добавлениии элемента в коллекцию.
            RaiseActionTrain(ActionListEnum.Added, train);
        }

        /// <summary>Изменение данных поезда.</summary> 
        /// <param name="trainOld">Старые данные о поезде.
        /// Должны полностью совпадать с имеющимся в списке.</param> 
        /// <param name="trainNew">Новые данные о поезе. ID изменяться не должен!</param> 
        public void ChangeTrain(TrainDto trainOld, TrainDto trainNew)
        {
            if (!trainDict.TryGetValue(trainOld.Id, out TrainDto carcar))
                throw new ArgumentException("Поезда с таким ID нет.", nameof(trainOld));

            if (carcar.Carriages != trainOld.Carriages)
                throw new ArgumentException("Несовпадают данные о поезде.", nameof(trainOld));

            if (trainOld.Id != trainNew.Id)
                throw new ArgumentException("Идентификатор должен оставаться прежним.", nameof(trainNew));

            // Замена старых данных на новые
            trainDict[trainNew.Id] = trainNew;

            // Создание события, уведомляющего об изменении элемента в коллекции.
            RaiseActionTrain(ActionListEnum.Changed, trainNew);
        }

        public void RemoveTrain(TrainDto train)
        {
            if (!trainDict.TryGetValue(train.Id, out TrainDto removeTrain))
                throw new ArgumentException("Поезда с таким ID нет.", nameof(train));

            if (removeTrain.Carriages != train.Carriages)
                throw new ArgumentException("Несовпадают данные об удаляемом поезде", nameof(train));

            if (!trainDict.Remove(train.Id))
                throw new ArgumentException("Не удалось удалить поезд. Возможно поезда уже нет в списке.", nameof(train));

            // Создание события, уведомляющего об удалении элемента из коллекции.
            RaiseActionTrain(ActionListEnum.Removed, train);
        }
        public void Save()
        {
            DataProcessor dataProcessor = new DataProcessor();
            dataProcessor.SaveToFile(trainDict, "Train");
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
