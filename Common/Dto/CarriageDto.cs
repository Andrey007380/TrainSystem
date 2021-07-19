using System.Collections.Generic;

namespace Common.Dto
{
    public class CarriageDto
    {
        public int Id { get; }
        public IList<PlaceDto> Places { get; }

        public CarriageDto(int id, IList<PlaceDto> places)
        {
            Id = id; Places = places;
        }
    }
}
