using Common.Dto;
using Common.Interfaces.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TrainStationModel
{
    public partial class TrainStationModel: ITrainStationModel
    {
        /// <summary>Приватный изменяемый словарь вагонов.</summary> 
        private readonly Dictionary<int, TrainDto> trainDict;

        /// <summary>Публичный неизменяемый словарь вагонов.</summary> 
        public IReadOnlyDictionary<int, TrainDto> Trains { get; }

        public TrainStationModel()
        {
            trainDict = Load<Dictionary<int, TrainDto>>("Train");
            trainDict = new Dictionary<int, TrainDto>();
            Trains = new ReadOnlyDictionary<int, TrainDto>(trainDict);
            
           
        }
    }
}
