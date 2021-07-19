using System;
using System.Collections.Generic;

namespace Common.Dto
{
    public class TrainDto
    {
        public int Id { get; }
        public string EndPoit { get; }
        public DateTime DepartureTime { get; }

        public IList<CarriageDto> Carriages { get; }

        public TrainDto(int id, IList<CarriageDto> carriages, string endPoint, DateTime departureTime)
        {
            Id = id;
            Carriages = carriages;
            EndPoit = endPoint;
            DepartureTime = departureTime;
        }
    }
}
