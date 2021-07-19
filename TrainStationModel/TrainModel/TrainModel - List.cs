using Common.Dto;
using Common.Interfaces.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TrainStationModel.TrainModel
{
    public partial class TrainModel: ITrainModel
    {
        /// <summary>Приватный изменяемый словарь вагонов.</summary> 
        private readonly Dictionary<int, CarriageDto> carriageDict;

        /// <summary>Публичный неизменяемый словарь вагонов.</summary> 
        public IReadOnlyDictionary<int, CarriageDto> Carriages { get; }

        public TrainModel(TrainDto train)
        {
            carriageDict = new Dictionary<int, CarriageDto>(train.Carriages.ToDictionary(carriage => carriage.Id));
            carriageDict = Load<Dictionary<int, CarriageDto>>("Carriage");
            Carriages = new ReadOnlyDictionary<int, CarriageDto>(carriageDict);
        }
    }
}
