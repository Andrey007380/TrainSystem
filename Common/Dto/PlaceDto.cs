using Common.Enums;
using System;

namespace Common.Dto
{
    public class PlaceDto
    {
        public int Number;
        public PlaceTypeEnum PlaceType { get; }
        public DateTime? DateTime { get; }
        public bool IsEmpty { get; }

        /// <summary> Коструктор для забронированного места. </summary>
        /// <param name="number"> Номер вагона </param>
        /// <param name="placeType"> Тип места </param>
        /// <param name="dateTime"> Дата и время бронирования. </param>
        public PlaceDto(int number, PlaceTypeEnum placeType, DateTime? dateTime)
        {
            Number = number;
            PlaceType = placeType;
            DateTime = dateTime;
            IsEmpty = false;
        }

        /// <summary> Конструктор для незабронированного места. </summary>
        /// <param name="number"> Номер вагона </param>
        /// <param name="placeType"> Тип места </param>
        public PlaceDto(int number, PlaceTypeEnum placeType)
        {
            Number = number;
            PlaceType = placeType;
            IsEmpty = true;
        }
    }
}
