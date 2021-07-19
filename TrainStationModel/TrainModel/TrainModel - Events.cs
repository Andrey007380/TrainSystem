using Common.Delegates;
using Common.Dto;
using Common.Enums;

namespace TrainStationModel.TrainModel
{
    public partial class TrainModel
    {
        public event ActioListHandler<CarriageDto> ActionCarriages;

        private void RaiseActionCarriage(ActionListEnum action, CarriageDto carriage)
        {
            ActionCarriages?.Invoke(this, action, carriage);
        }
    }
}
