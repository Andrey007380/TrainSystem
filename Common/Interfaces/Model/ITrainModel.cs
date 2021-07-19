using Common.Delegates;
using Common.Dto;
using System.Collections.Generic;

namespace Common.Interfaces.Model
{
    public interface ITrainModel
    {
        event ActioListHandler<CarriageDto> ActionCarriages;
        IReadOnlyDictionary<int, CarriageDto> Carriages { get; }

        void AddCarriage(CarriageDto carriage);
        void RemoveCarriage(CarriageDto carriage);
        void ChangeCarriage(CarriageDto carriageOld, CarriageDto carriageNewe);
        void Save();
    }
}
