using Common.Delegates;
using Common.Dto;
using System.Collections.Generic;

namespace Common.Interfaces.Model
{
    public interface ITrainStationModel
    {
        event ActioListHandler<TrainDto> ActionTrains;

        IReadOnlyDictionary<int, TrainDto> Trains { get; }

        void AddTrain(TrainDto train);
        void RemoveTrain(TrainDto train);
        void ChangeTrain(TrainDto trainOld, TrainDto trainNewe);
        void Save();

    }
}
