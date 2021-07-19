using Common.Interfaces.Model;

namespace ConsoleTrainStationUserInterface
{
    public class LocalTrainStationModel
    {
        private readonly ITrainStationModel model;

        public LocalTrainStationModel(ITrainStationModel model)
        {
            this.model = model;
        }

       
    }
    public class LocalTrainModel
    {
        private readonly ITrainModel trainmodel;

        public LocalTrainModel(ITrainModel model)
        {
            this.trainmodel = model;
        }

    }
}
