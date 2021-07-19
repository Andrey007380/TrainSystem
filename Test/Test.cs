using Common.Dto;
using Common.Interfaces.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainStationModel;
using TrainStationModel.TrainModel;
using Xunit;

namespace Test
{
    public class Test
    {
        Common.Interfaces.Model.TrainStationModel trainStationModel = new TrainStationModel.TrainStationModel();
        Common.Interfaces.Model.ITrainModel trainModel;
        TrainDto trainDto = new TrainDto(1, null, "Борисполь", new DateTime());

        //TrainModelStation
        [Fact]
        void RemoveTrain()
        {
            trainStationModel.AddTrain(trainDto);
            Assert.True(trainStationModel.Trains.Count == 0);
        }
        [Fact]
        void AddTrain()
        {
            trainStationModel.RemoveTrain(trainDto);
            Assert.True(trainStationModel.Trains.Count == 1);
        }

        [Fact]
        void ChangeCarriage()
        {
            TrainDto trainDtonew = new TrainDto(2, null, "Борисполь", new DateTime());
            trainStationModel.ChangeTrain(trainDto, trainDtonew);
            Assert.False(trainDto == trainDtonew);
        }

        //TrainModel

        CarriageDto carriageDto = new CarriageDto(1, null);
        [Fact]
        void RemoveCarriage()
        {
            trainModel.AddCarriage(carriageDto);
            Assert.True(trainModel.Carriages.Count == 0);
        }
        [Fact]
        void AddCarriage()
        {
            trainModel.RemoveCarriage(carriageDto);
            Assert.True(trainModel.Carriages.Count == 1);
        }

        [Fact]
        void ChangeTrain()
        {
            CarriageDto carriageDtoonew = new CarriageDto(2, null);
            trainModel.ChangeCarriage(carriageDto, carriageDtoonew);
            Assert.False(carriageDto == carriageDtoonew);
        }
    }
}
