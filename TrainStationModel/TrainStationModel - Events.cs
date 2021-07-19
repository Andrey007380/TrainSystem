using Common.Delegates;
using Common.Dto;
using Common.Enums;

namespace TrainStationModel
{
    public partial class TrainStationModel
    {
        public event ActioListHandler<TrainDto> ActionTrains;

        private void RaiseActionTrain(ActionListEnum action, TrainDto train)
        {
            ActionTrains?.Invoke(this, action, train);
        }
    }
}
